package com.mobLibrarry.vista;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.widget.EditText;
import android.widget.TextView;

import com.mobLibrarry.R;
import com.mobLibrarry.controlador.LectorGetJSON;
import com.mobLibrarry.modelo.Usuario;

public class ActivityEditar extends Activity {
	String nombreUsuario;
	String url_usuario;
	
	ArrayList<Usuario> usuarios=new ArrayList<Usuario>();
	Usuario usuario;
	 EditText txtNombre; 
     EditText txtApellido1; 
     EditText txtApellido2; 
     EditText txtCorreo; 
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_editar_perfil);
		
		Bundle extras = getIntent().getExtras();
        nombreUsuario = extras.getString("nombreUsuario");
        
        url_usuario = "http://moblibrary.azurewebsites.net/api/UsuarioAPI/GetUSUARIOByUSERNAME/"+nombreUsuario;
        
        //new GetInfoUsuarioREST().execute(url_usuario);
        
        txtNombre = (EditText) findViewById(R.id.txtEditarNombre);
        txtApellido1 = (EditText) findViewById(R.id.txtEditarApellido1);
        txtApellido2 = (EditText) findViewById(R.id.txtEditarApellido2);
        txtCorreo = (EditText) findViewById(R.id.txtEditarCorreo);
        
        txtNombre.setEnabled(false);
        txtApellido1.setEnabled(false);
        txtApellido2.setEnabled(false);
        txtCorreo.setEnabled(false);
        
        new GetInfoUsuarioREST().execute(url_usuario);
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
                 
                 txtNombre.setText(usuario.getNombre());
                 txtApellido1.setText(usuario.getApellido1());
                 txtApellido2.setText(usuario.getApellido2());
                 txtCorreo.setText(usuario.getEmail());
	            }
	        	catch (Exception e) {
	        		String error=e.getMessage();
	        		error.toString();
	        	}          
	    	}
		}
}
