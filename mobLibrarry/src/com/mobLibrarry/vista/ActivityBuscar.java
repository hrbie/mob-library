package com.mobLibrarry.vista;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.mobLibrarry.R;
import com.mobLibrarry.controlador.ConexionLibreria;
import com.mobLibrarry.controlador.LectorGetJSON;
import com.mobLibrarry.modelo.AdapterLibreria;
import com.mobLibrarry.modelo.Libreria;


public class ActivityBuscar extends Activity {
	private ArrayList<Libreria> librerias = new ArrayList<Libreria>();
	
	
	private String nombreUsuario;
	private String url_Libreria;
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_buscar);
        
        //Se obtienen los parametros enviados desde el activity anterior
        Bundle extras = getIntent().getExtras();
        nombreUsuario = extras.getString("nombreUsuario");
        
        Spinner spinner = (Spinner) findViewById(R.id.spnTipoBusqueda);
    
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this,
        R.array.opciones_busqueda, android.R.layout.simple_spinner_item);
     
        spinner.setAdapter(adapter);
        
     
     	//URL necesaria para realizar la conexion con el servidor
        //http://moblibrary.azurewebsites.net/api/CadenaLibreriasAPI/GetCADENA_LIBRERIAS
        url_Libreria = getString(R.string.url_Libreria);
		new getLibreriaREST().execute(url_Libreria);
    }
 
    
    public void llamar_activity_resultados(View view) {
		
		Intent resultado = new Intent(this, ActivityResultadoBuscar.class);
		Spinner spnLibrera = (Spinner) findViewById(R.id.spnLibreria);
		EditText palabraBuscar = (EditText) findViewById(R.id.txtBuscar);
		
		Libreria libreria = librerias.get(spnLibrera.getSelectedItemPosition());
		
		
		String idLibreria = libreria.getId()+"";
		String buscar = palabraBuscar.getText().toString();
		Spinner spnTipoBusqueda = (Spinner) findViewById(R.id.spnTipoBusqueda);
		String tipoBusqueda = spnTipoBusqueda.getSelectedItem().toString();
		
		
		//Se pasn por parametro los valores obtenidos de los elementos de interfaz
		resultado.putExtra("tipoBuscar", tipoBusqueda);
		resultado.putExtra("palabraBuscar", buscar);
		resultado.putExtra("nombreLibreria", libreria.getNombreLibreria());
		resultado.putExtra("idLibreria", idLibreria);
		resultado.putExtra("nombreUsuario", nombreUsuario);
		startActivity(resultado);
    }
    
    private void alistarInterfaz(ArrayList<Libreria> librerias)
	 {
        AdapterLibreria adapter_libreria = 
        new AdapterLibreria(this, android.R.layout.simple_spinner_item, librerias);
		Spinner spnLibreria = (Spinner) findViewById(R.id.spnLibreria);
		spnLibreria.setAdapter(adapter_libreria);
	 }
    
    //Clase privada necesaria para realizar la conexion asincronico con el Backend por medio de Request que se
    //le hacen al servidor esta clase ejecuta dos metodos, el doInBackgroud se ejecuta antes de llamar al API y 
    //onPostExecute se ejecuta despues de conectar con la API y se utiliza para manejar la informacion recibida
    //desde el servidor
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
            	
            	//Error con la conexion o no hay librerias disponibles
            	if(librerias.isEmpty())
            	{
            		Toast.makeText(getApplicationContext(), "Error de Conexion de Internet, intentelo mas tarde",
                    		Toast.LENGTH_SHORT).show();
            	}
                //Se muesta en interfaz el resultado obtenido del request que se le ha hecho al servidor por medio
                //del API
                alistarInterfaz(librerias);
                
            } catch (Exception e) {
                Toast.makeText(getApplicationContext(), "Error de Conexion de Internet, intentelo mas tarde",
                		Toast.LENGTH_LONG).show();
            }          
        }
    }

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// TODO Auto-generated method stub
		getMenuInflater().inflate(R.menu.activity_menu_pantallas, menu);
		return true;
	}
 }
