package com.mobLibrarry.vista;

import java.util.Arrays;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;

import com.facebook.FacebookException;
import com.facebook.Request;
import com.facebook.Response;
import com.facebook.Session;
import com.facebook.SessionState;
import com.facebook.model.GraphUser;
import com.facebook.widget.LoginButton;
import com.facebook.widget.LoginButton.OnErrorListener;
import com.mobLibrarry.R;


public class ActivityPrincipal extends Activity {

	
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_principal);
		
		//Boton del SDK de Facebook que viene con caracteristicas especiales para facilitar la 
		//autenticacion con facebook
		final LoginButton authButton = (LoginButton) findViewById(R.id.login_button);
		
		//Accion a tomar en caso de error
		authButton.setOnErrorListener(new OnErrorListener() {
			
	       @Override
	       public void onError(FacebookException error) {
	          
	       }
	    });
	     
		//Configuracion de permisos
	    authButton.setReadPermissions(Arrays.asList("basic_info","email"));
	  
	    //Provee un notificacion asincronica de el estado de Session
	    
	    authButton.setSessionStatusCallback(new Session.StatusCallback() {
	         
	        @SuppressWarnings("deprecation")
			@Override
	         public void call(Session session, final SessionState state, Exception exception) {
	          //Autenticacion por medio de la API de Facebook
	          if (session.isOpened()) {                    
	                    Request.executeMeRequestAsync(session,
	                            new Request.GraphUserCallback() {
	                                @Override
	                                public void onCompleted(GraphUser user,Response response) {
	                                    if (user != null) {  
	                                      llamar_activity_menu(findViewById(R.layout.activity_menu),user);
	                                      
	                                    }
	                                }
	                            });
	          }else if(session.isClosed()) {
	                  
	          }
	         }
	        });
	}

	

  @Override
   public void onActivityResult(int requestCode, int resultCode, Intent data) {
    super.onActivityResult(requestCode, resultCode, data);
       Session.getActiveSession().onActivityResult(this, requestCode, resultCode, data);
   }
  
  //Funcion encargada de llamar a activity_menu, se llama desde el boton en el Layout por el metodo OnClick
  public void llamar_activity_menu(View view, GraphUser user) {
		Intent menu = new Intent(this, ActivityMenu.class);
		
		
		//El correo electronico se obtiene haciendo un request especial a la cuenta de facebook
		String correo= user.asMap().get("email").toString();
		
		//El apellido como viene en los dos unidos en un string es necesario separarlos, se separan por medio de la
		//funcion split()
		String cadena = user.getLastName();
		String delimitadores= " ";
		String[] apellidos = cadena.split(delimitadores);
		
		//Se pasan los parametros a la activity ActivityMenu
		menu.putExtra("Nombre", user.getFirstName());
		menu.putExtra("Apellido1", apellidos[0]);
		menu.putExtra("Apellido2", apellidos[1]);
		menu.putExtra("ID_Cuenta", user.getId());
		menu.putExtra("Username", user.getUsername());
		menu.putExtra("Correo", correo);
		
		startActivity(menu);
		}


public void llamar_activity_menu_test(View view) {
	Intent menu = new Intent(this, ActivityMenu.class);
	
	
	//El correo electronico se obtiene haciendo un request especial a la cuenta de facebook
	String correo= "esteban.1703@hotmail.com";
	
	//El apellido como viene en los dos unidos en un string es necesario separarlos, se separan por medio de la
	//funcion split()
	String cadena = "Segura Benavides";
	String delimitadores= " ";
	String[] apellidos = cadena.split(delimitadores);
	
	//Se pasan los parametros a la activity ActivityMenu
	menu.putExtra("Nombre", "Esteban");
	menu.putExtra("Apellido1", apellidos[0]);
	menu.putExtra("Apellido2", apellidos[1]);
	menu.putExtra("ID_Cuenta", "256");
	menu.putExtra("Username", "esteban.segurabenavides");
	menu.putExtra("Correo", correo);
	
	startActivity(menu);
	}
}
