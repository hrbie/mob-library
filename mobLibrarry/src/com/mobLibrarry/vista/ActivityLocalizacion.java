package com.mobLibrarry.vista;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.graphics.Point;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.Spinner;
import android.widget.TabHost;
import android.widget.Toast;

import com.google.android.gms.maps.CameraUpdate;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.GoogleMap.OnMapLongClickListener;
import com.google.android.gms.maps.Projection;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.CameraPosition;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.mobLibrarry.R;
import com.mobLibrarry.controlador.ConexionLibreria;
import com.mobLibrarry.controlador.LectorGetJSON;
import com.mobLibrarry.modelo.AdapterLibreria;
import com.mobLibrarry.modelo.AdapterPuntoVenta;
import com.mobLibrarry.modelo.Libreria;
import com.mobLibrarry.modelo.Punto_Venta;

public class ActivityLocalizacion extends FragmentActivity {
	private ArrayList<Libreria> librerias = new ArrayList<Libreria>();
	ArrayList<Punto_Venta> PDVs = new ArrayList<Punto_Venta>();
	String url_Libreria;
	String url_Tienda = "http://moblibrary.azurewebsites.net/api/PuntoVentaAPI/GetPUNTO_VENTA";
	
	ImageButton btnMiLocalizacion;
	 String username;
	Button btnUbicarLibreria;
	@Override
	protected void onCreate(Bundle arg0) {
		// TODO Auto-generated method stub
		super.onCreate(arg0);
		
		Bundle extras = getIntent().getExtras();
        username = extras.getString("Username");
        
		setContentView(R.layout.activity_localizacion);
		cargarTabs();
		
		url_Libreria = getString(R.string.url_Libreria);
		new getLibreriaREST().execute(url_Libreria);
		
		new GetLectorPuntoVentaREST().execute(url_Tienda);
	}
	
	private void ubicarLibreria( double latitud,double longitud, String nomreLibreria)
    {
    	final GoogleMap mapa = ((SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map)).getMap();
        
       
        mapa.clear();	    
        LatLng ubicacionLibreria = new LatLng(latitud,longitud);   
        CameraPosition camPos = new CameraPosition.Builder()
                .target(ubicacionLibreria)   //Ubicacion asignada por la latitud y longitud pasada por parametros
                .zoom(11)         //Acercamiento de la camara
                .build();
         
        CameraUpdate camUpd3 =
        	    CameraUpdateFactory.newCameraPosition(camPos);
        	 
        	mapa.animateCamera(camUpd3);
        
       mostrarMarcador(mapa, latitud, longitud, nomreLibreria);
        	mapa.setOnMapLongClickListener(new OnMapLongClickListener() {
        	    @Override
				public void onMapLongClick(LatLng point) {
        	        Projection proj = mapa.getProjection();
        	        Point coord = proj.toScreenLocation(point);
        	 
        	        Toast.makeText(
        	            ActivityLocalizacion.this,
        	            "Ubicacion\n" +
        	            "Lat: " + point.latitude + "\n" +
        	            "Lng: " + point.longitude + "\n" +
        	            "X: " + coord.x + " - Y: " + coord.y,
        	            Toast.LENGTH_SHORT).show();
        	    }
        	});
        	
        	
    }

	private void mostrarMarcador(GoogleMap mapa,double lat, double lng, String titulo)
    {
        mapa.addMarker(new MarkerOptions()
            .position(new LatLng(lat, lng))
            .title("Libreria: " + titulo));
        
    }
	
	public void cargarTabs()
	{
		Resources res = getResources();
		final TabHost tabs=(TabHost)findViewById(android.R.id.tabhost);
		tabs.setup();
		 
		TabHost.TabSpec spec=tabs.newTabSpec("tabInformacion");
		spec.setContent(R.id.tab1);
		spec.setIndicator("",
		    res.getDrawable(R.drawable.ubicar_libreria));
		tabs.addTab(spec);
		 
		spec=tabs.newTabSpec("tabMapa");
		spec.setContent(R.id.tab2);
		spec.setIndicator("",
		    res.getDrawable(R.drawable.mapa));
		tabs.addTab(spec);
		
		final Spinner spnTienda = (Spinner) findViewById(R.id.spnLocalizacion_Tienda);
		
		
		btnUbicarLibreria = (Button) findViewById(R.id.btnLocalizacion_Ubicar);
		btnUbicarLibreria.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				ubicarLibreria(PDVs.get(spnTienda.getSelectedItemPosition()).getLatitud(), 
						PDVs.get(spnTienda.getSelectedItemPosition()).getLongitud(), 
						PDVs.get(spnTienda.getSelectedItemPosition()).getNombre_libreria());
				tabs.setCurrentTab(1);
				
			}
		});
		 
	}
	
	
	 private class getLibreriaREST extends AsyncTask
	    <String, Void, String> {
	    	LectorGetJSON lectorJSON = new LectorGetJSON();
	    	
	    	ConexionLibreria conexion_librerias = new ConexionLibreria();
	        @Override
			protected String doInBackground(String... urls) {
	            return lectorJSON.getJSONFeed(urls[0]);
	        }
	        @Override
			protected void onPostExecute(String result) {
	            try {
	            	librerias = conexion_librerias.getLibreria(result);
	                //Se muesta en interfaz el resultado obtenido del request que se le ha hecho al servidor por medio
	                //del API
	                alistarInterfaz(librerias);
	        		
	        		
	            } catch (Exception e) {
	                
	            }          
	        }
	    }
	 
	 private void alistarInterfaz(ArrayList<Libreria> librerias)
	 {
		Context context = getApplicationContext();
        AdapterLibreria adapter_libreria = 
        new AdapterLibreria(this, android.R.layout.simple_spinner_item, librerias);
		Spinner spnLibreria = (Spinner) findViewById(R.id.spnLocalizacion_Libreria);
		spnLibreria.setAdapter(adapter_libreria);
	 }
	 
	 private class GetLectorPuntoVentaREST extends AsyncTask
	    <String, Void, String> {
	        @Override
			protected String doInBackground(String... urls) {
	        	LectorGetJSON lectorJSON = new LectorGetJSON();
	            return lectorJSON.getJSONFeed(urls[0]);
	        }
	        @Override
			protected void onPostExecute(String result) {
	            
	        	try {
	                JSONArray respuestaArrayJSON = new JSONArray(result);
	               
	                for(int i=0; i<respuestaArrayJSON.length();i++)
	                {
	                	JSONObject respuestaJSON = respuestaArrayJSON.getJSONObject(i);
	                	int id_PDV = respuestaJSON.getInt("ID_PDV");
	                	int id_libreria = respuestaJSON.getInt("ID_LIBRERIA");
	                    String nombre_libreria = respuestaJSON.getString("NOMBRE");
	                    String direccion = respuestaJSON.getString("DIRECCIÓN");
	                    String telefono = respuestaJSON.getString("TELEFONO");
	                    double latitud = respuestaJSON.getDouble("LATITUD");
	                    double longitud = respuestaJSON.getDouble("LONGITUD");
	                    Punto_Venta pdv = new Punto_Venta(id_PDV, id_libreria, nombre_libreria, direccion, telefono, latitud,
	                    								longitud);
	                    PDVs.add(pdv);
	                }
	                
	//--------------------- INTERFAZ -------------------------------------------------------------
	                Activity context = ActivityLocalizacion.this;
	                AdapterPuntoVenta adapter_PDV = 
	                new AdapterPuntoVenta(context, android.R.layout.simple_spinner_item, PDVs);
	        		Spinner spnPuntoVenta = (Spinner) findViewById(R.id.spnLocalizacion_Tienda);
	        		spnPuntoVenta.setAdapter(adapter_PDV);
	        		
	        		
	        		
	        		
	            } catch (Exception e) {
	            	Toast.makeText(getApplicationContext(),"Error "+e.getMessage() , Toast.LENGTH_SHORT).show();
	            }          
	        }
	    }
	 
	 //Localizacion Actual
	 private LocationManager locManager;
	 private LocationListener locListener;
	 ArrayList<Double> coordenadas_actuales = new ArrayList<Double>();
	 private ArrayList<Double> comenzarLocalizacion()
	    {
	    	//Obtenemos una referencia al LocationManager
	    	locManager = 
	    		(LocationManager)getSystemService(Context.LOCATION_SERVICE);
	    	
	    	//Obtenemos la última posición conocida
	    	final Location loc = 
	    		locManager.getLastKnownLocation(LocationManager.GPS_PROVIDER);
		    	coordenadas_actuales.add(0,loc.getLatitude());
		    	coordenadas_actuales.add(1,loc.getLongitude());
	    	
	    	//Nos registramos para recibir actualizaciones de la posición
	    	locListener = new LocationListener() {
		    	@Override
				public void onLocationChanged(Location location) {
		    		//ubicarLibreria(loc.getLongitude(), loc.getLatitude(), "Usted esta aqui");
		    	}
		    	@Override
				public void onProviderDisabled(String provider){
		    		
		    	}
		    	@Override
				public void onProviderEnabled(String provider){
		    		
		    	}
		    	@Override
				public void onStatusChanged(String provider, int status, Bundle extras){
		    		
		    	}
	    	};
	    	
	    	locManager.requestLocationUpdates(
	    			LocationManager.GPS_PROVIDER, 30000, 0, locListener);
	    	
	    	return coordenadas_actuales;
	    }
	 
	 @Override
		public boolean onCreateOptionsMenu(Menu menu) {
			getMenuInflater().inflate(R.menu.activity_menu_localizar, menu);
			return true;
		}
	 
	 @Override
		public boolean onOptionsItemSelected(MenuItem item) {
			
			switch (item.getItemId()) {
			case R.id.menu_buscar:
	        	Intent buscar = new Intent(this, ActivityBuscar.class);
	    		
	    		buscar.putExtra("nombreUsuario", username);
	    		startActivity(buscar);
	            return true;
			
	        case R.id.menu_localizar:
	        	ArrayList<Double> coordenadas = comenzarLocalizacion();
				Double latitud = coordenadas.get(0);
				Double longitud = coordenadas.get(1);
				ubicarLibreria(latitud, longitud, "Usted se encuentra aqui");
				for (int i = 0; i < PDVs.size(); i++) {
					ubicar_especial(PDVs.get(i).getLatitud(), PDVs.get(i).getLongitud(), PDVs.get(i).getNombre_libreria());
				}
	            return true;
	        
	        default:
	            return super.onOptionsItemSelected(item);
			}
		}
	 //ubicar_especial(PDVs.get(i).getLatitud(), PDVs.get(i).getLongitud(), PDVs.get(i).getNombre_libreria());
	 
	 private void ubicar_especial( double latitud,double longitud, String nombreLibreria)
	    {
	    	final GoogleMap mapa = ((SupportMapFragment) getSupportFragmentManager()
	                .findFragmentById(R.id.map)).getMap();
	        
	       
	        //mapa.clear();	    
	        
	       mostrarMarcador(mapa, latitud, longitud, nombreLibreria);
	        	mapa.setOnMapLongClickListener(new OnMapLongClickListener() {
	        	    @Override
					public void onMapLongClick(LatLng point) {
	        	        Projection proj = mapa.getProjection();
	        	        Point coord = proj.toScreenLocation(point);
	        	 
	        	        Toast.makeText(
	        	            ActivityLocalizacion.this,
	        	            "Ubicacion\n" +
	        	            "Lat: " + point.latitude + "\n" +
	        	            "Lng: " + point.longitude + "\n" +
	        	            "X: " + coord.x + " - Y: " + coord.y,
	        	            Toast.LENGTH_SHORT).show();
	        	    }
	        	});
	        	
	        	
	    }
}



