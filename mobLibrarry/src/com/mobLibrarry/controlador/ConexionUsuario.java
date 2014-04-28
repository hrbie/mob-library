package com.mobLibrarry.controlador;

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

public class ConexionUsuario {
	Boolean result;
	public Boolean PostUsuario(String url,String nombre, String apellido1, 
			String apellido2, String correo, String username)
	{
		try {
			result = true;
			 //Aqui se instancia la clase HttpPost para realizar eviar la solicitud de Post al servidor
	        HttpPost request = new HttpPost(url);
	        
	        //Se aagregan los parametros que llevara la URL completa para hacerle solicitud a la API
	        List<NameValuePair> info_usuario = new ArrayList<NameValuePair>();
	        info_usuario.add(new BasicNameValuePair("nombre", nombre));
	        info_usuario.add(new BasicNameValuePair("apellido1", apellido1));
	        info_usuario.add(new BasicNameValuePair("apellido2", apellido2));
	        info_usuario.add(new BasicNameValuePair("email", correo));
	        info_usuario.add(new BasicNameValuePair("username", username));
	        request.setEntity(new UrlEncodedFormEntity(info_usuario));
	        
	        //Se crea un cliente con la clase HttpClient y se le envia por medio del HttpResponse con el request
	        //armado
	        HttpClient httpClient = new DefaultHttpClient();
	        HttpResponse response = httpClient.execute(request);
	        
	        //Se recbe la respuesta de la solicitud esta pare es principalmente para verificar que se realizo 
	        //correctamente el request
	        String respStr = EntityUtils.toString(response.getEntity());
	        if(!respStr.equals("true"))
	            result = false;
		} catch (Exception e) {
			
		}
		return result;
			
		
	}

}
