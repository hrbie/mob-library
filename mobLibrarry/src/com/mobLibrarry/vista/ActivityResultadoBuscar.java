package com.mobLibrarry.vista;


import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;
import android.widget.TableLayout;
import android.widget.TextView;

import com.mobLibrarry.R;
import com.mobLibrarry.controlador.ConexionLibro;
import com.mobLibrarry.controlador.LectorGetJSON;
import com.mobLibrarry.modelo.AdapterResultado;
import com.mobLibrarry.modelo.Libro;
import com.mobLibrarry.modelo.Usuario;

public class ActivityResultadoBuscar extends Activity {
	ArrayList<Libro> libros = new ArrayList<Libro>();
	
	Usuario usuario;
	String nombreUsuario;
	
	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_resultado_busqueda);
        
        
        
        //Se obtienen los parametros de enviados desde la activity anterior
        Bundle extras = getIntent().getExtras();
        String buscarPor = extras.getString("tipoBuscar");
        String palabraBuscar = extras.getString("palabraBuscar");
        String nombreLibreria = extras.getString("nombreLibreria");
        String idLibreria = extras.getString("idLibreria");
        nombreUsuario = extras.getString("nombreUsuario");
        
        TextView lblNombreLibreria = (TextView) findViewById(R.id.lblNombreLibreria);
        
        lblNombreLibreria.setText(nombreLibreria);
        
        
        String url_usuario = "http://moblibrary.azurewebsites.net/api/UsuarioAPI/GetUSUARIOByUSERNAME/"+nombreUsuario;
        new GetInfoUsuarioREST().execute(url_usuario); 
        
        //Seccion el usuario seleccione la opcion de busquead asi se ira entrando en los diferentes tipos de 
        //busqueda que se pueden hacer
        String urlGetBuscar;
        if(buscarPor.equals("Nombre de libro"))
        {
        	//Se va armando el URL paso a paso para ser enviado al API con la url completa
        	
        	urlGetBuscar = crearUrl(idLibreria,palabraBuscar,"GetLIBROByLibreriaAndKeyword");
        	
        	//Se llama asincronicamente el metodo LectorLibroRest con la url completa para que se encarge de 
        	//manejar el envio y recibo de datos con el servidor
        	new getLibroREST().execute(urlGetBuscar);
        }
        else if(buscarPor.equals("Nombre de autor"))
        {
        	//Se va armando el URL paso a paso para ser enviado al API con la url completa
        	urlGetBuscar = crearUrl(idLibreria,palabraBuscar,"GetLIBROByLibreriaAndAutor");
        	
        	//Se llama asincronicamente el metodo LectorLibroRest con la url completa para que se encarge de 
        	//manejar el envio y recibo de datos con el servidor
        	new getLibroREST().execute(urlGetBuscar);
        }
        else if(buscarPor.equals("Editorial"))
        {
        	//Se va armando el URL paso a paso para ser enviado al API con la url completa
        	
        	urlGetBuscar = crearUrl(idLibreria,palabraBuscar,"GetLIBROByLibreriaAndEditorial");
        	
        	//Se llama asincronicamente el metodo LectorLibroRest con la url completa para que se encarge de 
        	//manejar el envio y recibo de datos con el servidor
        	new getLibroREST().execute(urlGetBuscar);
        }
        else if(buscarPor.equals("Año"))
        {
        	
        	urlGetBuscar = "http://moblibrary.azurewebsites.net/api/LibroAPI/GetLIBROByAnio/" + palabraBuscar;
        	
        	//Se llama asincronicamente el metodo LectorLibroRest con la url completa para que se encarge de 
        	//manejar el envio y recibo de datos con el servidor
        	new getLibroREST().execute(urlGetBuscar);
        }
        
    }
	
	private String crearUrl(String idLibreria, String palabraBuscar, String parte_url)
	{
		//Se va armando el URL paso a paso para ser enviado al API con la url completa
    	Uri url_sin_formar = new Uri.Builder()
        .scheme("https")
        .authority("moblibrary.azurewebsites.net")
        .path("api/LibroAPI/"+parte_url)
        .appendQueryParameter("id_libreria", idLibreria)
        .appendQueryParameter("nombre", palabraBuscar)
        .build();
    	return url_sin_formar.toString();
	}
	
	
	private void alistarInterfaz(ArrayList<Libro> libros)
	{
		//Se muestra en la lista los resultados obtenidos del request hecho al servidor
        AdapterResultado adapter = new AdapterResultado(ActivityResultadoBuscar.this, libros);
    	
        ListView listView = (ListView) findViewById(R.id.lstResultados);
    	listView.setOnItemClickListener(new OnItemClickListener(){

    		@Override
        		public void onItemClick(AdapterView<?> arg0, View v, int arg2,
    				long arg3)
    			{
	    			// TODO Auto-generated method stub
	    			TextView nombre_libro = (TextView) v.findViewById(R.id.row_nombre_libro);
	    			TextView autor_libro = (TextView) v.findViewById(R.id.row_autor);
	    			TextView ano_libro = (TextView) v.findViewById(R.id.row_ano);
	    			
	    			TextView editorial_libro = (TextView) v.findViewById(R.id.row_editorial);
	    			TextView precio_libro = (TextView) v.findViewById(R.id.row_precio);
	    			TextView calificacion_libro = (TextView) v.findViewById(R.id.row_calificacion);
	    			TextView id_libro = (TextView) v.findViewById(R.id.row_id);
	    			
	    			String strIDLibro = id_libro.getText()+"";
	    			String strNombreLibro = nombre_libro.getText()+"";
	    			String strAutorLibro = autor_libro.getText()+"";
	    			String strEditorialLibro = editorial_libro.getText()+"";
	    			String strPrecioLibro = precio_libro.getText()+"";
	    			String strAnoLibro = ano_libro.getText()+"";
	    			String strCalificacion = calificacion_libro.getText()+"";
	    			
					String[] info_libro = new String[7];
					info_libro[0] = strIDLibro;
					info_libro[1] = strNombreLibro;
					info_libro[2] = strAutorLibro;
					info_libro[3] = strEditorialLibro;
					info_libro[4] = strPrecioLibro;
					info_libro[5] = strAnoLibro;
					info_libro[6] = strCalificacion;
					
					llamar_activity_info_libro(findViewById(R.layout.activity_resultado_busqueda), info_libro);
				}
    		});
        
    		listView.setAdapter(adapter);
    	
		}
	
	//Metodo que abre la activity ActivityInformacionLibro y se le pasan como parametros los valores necesarios
	//para su funcionamiento
		public void llamar_activity_info_libro(View view, String[] info_libro) {
			Intent libro_seleccionado = new Intent(this, ActivityInformacionLibro.class);
			libro_seleccionado.putExtra("ISBN", info_libro[0]);
			libro_seleccionado.putExtra("NombreLibro", info_libro[1]);
			libro_seleccionado.putExtra("AutorLibro", info_libro[2]);
			libro_seleccionado.putExtra("EditorialLibro", info_libro[3]);
			libro_seleccionado.putExtra("PrecioLibro", info_libro[4]);
			libro_seleccionado.putExtra("AnoLibro", info_libro[5]);
			libro_seleccionado.putExtra("CalificacionLibro", info_libro[6]);
			libro_seleccionado.putExtra("nombreUsuario", nombreUsuario);
			libro_seleccionado.putExtra("id_usuario", usuario.getId_usuario()+"");
			startActivity(libro_seleccionado);
		}
	
		private class getLibroREST extends AsyncTask<String, Void, String>{
		
			LectorGetJSON lectorJSON = new LectorGetJSON();
		    @Override
			protected String doInBackground(String... urls) {
		    	
		        return lectorJSON.getJSONFeed(urls[0]);
		    }
		    @Override
			protected void onPostExecute(String result) {
		        try {
		        	ConexionLibro conexion_libro = new ConexionLibro();
		        	libros = conexion_libro.getLibro(result);
	        		
	//-------------------------------------- Interfaz ------------------------------------------------------------	
		            alistarInterfaz(libros);
		            }
		        	catch (Exception e) {
		            
		        	}          
		    	}
		}
		
		private class GetInfoUsuarioREST extends AsyncTask
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
		            	int id_usuario = respuestaJSON.getInt("ID_USUARIO");
		                String nombre_usuario = respuestaJSON.getString("NOMBRE");
		                String apellido1_usuario = respuestaJSON.getString("APELLIDO1");
		                String apellido2_usuario = respuestaJSON.getString("APELLIDO2");
		                String fecha_nacimiento_usuario = respuestaJSON.getString("FECHA_NACIMIENTO");
		                String direccion_usuario = respuestaJSON.getString("DIRECCION");
		                String email_usuario= respuestaJSON.getString("EMAIL");
		                String username_usuario = respuestaJSON.getString("USERNAME");
		                
		                usuario = new Usuario(id_usuario, nombre_usuario, apellido1_usuario, 
		                		  apellido2_usuario,fecha_nacimiento_usuario, direccion_usuario,email_usuario,
		                		  username_usuario);
	                 }
		            }
		        	catch (Exception e) {
		            String error = e.getMessage();
		            error.toString();
		        	}          
		    	}
			}
		
}
