package com.mobLibrarry.vista;


import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.facebook.Request;
import com.facebook.Response;
import com.facebook.Session;
import com.facebook.SessionState;
import com.facebook.model.GraphUser;
import com.facebook.widget.LoginButton;
import com.mobLibrarry.R;
import com.mobLibrarry.controlador.ConexionUsuario;
import com.mobLibrarry.controlador.LectorGetJSON;
import com.mobLibrarry.modelo.Usuario;

public class ActivityMenu extends Activity {
	private TextView info_usuario;
	String nombre;
	String apellido1;
	String apellido2;
	String id_cuenta;
	String username;
	String correo;
	//"http://moblibrary.azurewebsites.net/api/UsuarioAPI/PostUSUARIO";
	String urlPostInfoUsuario = "http://moblibrary.azurewebsites.net/api/UsuarioAPI/PostUSUARIO";
	String url_usuario;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_menu);
		
		
		
		Bundle extras = getIntent().getExtras();
        nombre = extras.getString("Nombre");
        apellido1 = extras.getString("Apellido1");
        apellido2 = extras.getString("Apellido2");
        id_cuenta = extras.getString("ID_Cuenta");
        username = extras.getString("Username");
        correo = extras.getString("Correo");
        
        String apellidos = apellido1 +" "+apellido2;
        
        String nombre_completo = nombre + " "+apellidos;
        
        //info_usuario = (TextView) findViewById(R.id.lblIDUsuario);
        //info_usuario.setText(nombre_completo);
        
        //url_usuario = "http://moblibrary.azurewebsites.net/api/UsuarioAPI/GetUSUARIOByUSERNAME/"+username;
        //new GetInfoUsuarioREST().execute(url_usuario);
        
        LoginButton authButton = (LoginButton) findViewById(R.id.login_button);
		authButton.setSessionStatusCallback(new Session.StatusCallback() {
        @SuppressWarnings("deprecation")
		@Override
         public void call(Session session, SessionState state, Exception exception) {
          
    		//En caso de cerrar sesion se redirige la pagina al inicio de la aplicaion para solicitar
        	//autentucarse otra vez
			if (session.isClosed()) {                    
	            Request.executeMeRequestAsync(session,
                new Request.GraphUserCallback() {
                    @Override
                    public void onCompleted(GraphUser user,Response response) {
                           
                    	Intent menu = new Intent(getApplicationContext(),ActivityPrincipal.class);
                		startActivity(menu);
                        
                    }
                });
			}
        }
	});
		
		//new PostUsuarioREST.execute(urlPostInfoUsuario); 
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.activity_menu, menu);
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
        
        default:
            return super.onOptionsItemSelected(item);
		}
	}
	
	
	//Metodo que se encarga de llamar a la activity ActivityBuscar
	public void llamar_activity_buscar(View view) {
		Intent buscar = new Intent(this, ActivityBuscar.class);
		
		buscar.putExtra("nombreUsuario", username);
		startActivity(buscar);
	}
	
	public void llamar_activity_localizacion(View view) {
		Intent localizacion = new Intent(this, ActivityLocalizacion.class);
		
		localizacion.putExtra("nombreUsuario", username);
		startActivity(localizacion);
	}
	
	public void llamar_activity_editar(View view) {
		Intent editar = new Intent(this, ActivityEditar.class);
		editar.putExtra("nombreUsuario", username);
		startActivity(editar);
	}
	
	public void llamar_activity_recomendar(View view) {
		Intent recomendar = new Intent(this, ActivityRecomendaciones.class);
		recomendar.putExtra("nombreUsuario", username);
		startActivity(recomendar);
	}
	//Clase privada necesaria para realizar la conexion asincronico con el Backend por medio de Request que se
    //le hacen al servidor esta clase ejecuta dos metodos, el doInBackgroud se ejecuta antes de llamar al API y 
    //onPostExecute se ejecuta despues de conectar con la API y se utiliza para manejar la informacion recibida
    //desde el servidor. Esta clase se encarga de hacer Post en el servidor por medio de HtpPost
	private class PostUsuarioREST extends AsyncTask
	<String,Integer,Boolean> {
        @Override
		protected Boolean doInBackground(String... urls) {
        	
        	boolean resul = true;
        	try {
        		ConexionUsuario conexion_usuario = new ConexionUsuario();
        		resul = conexion_usuario.PostUsuario(urlPostInfoUsuario, nombre, apellido1, apellido2, correo, username);
                

         } catch (Exception e) {
        	 resul = false;
        	 Toast.makeText(getApplicationContext(),"Error de Conexion "+e.getMessage() , Toast.LENGTH_SHORT).show();
         }
        	return resul;
        }
	}
	
	
	
}
