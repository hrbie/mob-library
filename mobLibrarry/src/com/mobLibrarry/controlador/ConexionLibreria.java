package com.mobLibrarry.controlador;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONObject;

import com.mobLibrarry.modelo.Libreria;

public class ConexionLibreria {
	ArrayList<Libreria> librerias = new ArrayList<Libreria>();
	public ArrayList<Libreria> getLibreria(String result)
	{
		try {
	    	//Todos los objetos recibidos se manejar como JSONArray para su facil tratamiento descomposicion
	        JSONArray respuestaArrayJSON = new JSONArray(result);
	        
	        //Se recorre el JSONArray para ir armando las "entidades necesarias para manejarlas"
	        for(int i=0; i<respuestaArrayJSON.length();i++)
	        {
	        	//Se arma cada elemento dentro del JSONArray como JSONObject para ir obteniendo los valores
	        	JSONObject respuestaJSON = respuestaArrayJSON.getJSONObject(i);
	        	int id_libreria = respuestaJSON.getInt("ID_LIBRERIA");
	            String nombre_libreria = respuestaJSON.getString("NOMBRE");
	            String descripcion = respuestaJSON.getString("DESCRIPCION");
	            Libreria libreria = new Libreria(id_libreria, nombre_libreria, descripcion);
	            librerias.add(libreria);
	        }

			
			
	    } catch (Exception e) {
	        
	    }
		return librerias; 
	}
}
