package com.mobLibrarry.controlador;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONObject;

import com.mobLibrarry.modelo.Libro;

public class ConexionLibro {
	
	ArrayList<Libro> libros = new ArrayList<Libro>();
	public ArrayList<Libro> getLibro(String result)
	{
		try {
        	//Array recibido del request hecho al servidor de la aplicacion
            JSONArray respuestaArrayJSON = new JSONArray(result);
            
            
            for(int i=0; i<respuestaArrayJSON.length();i++)
            {
            	//Se crea una entidad libro con cada elemento obtenido del JSONArray para 
            	//su facil manejo
            	JSONObject respuestaJSON = respuestaArrayJSON.getJSONObject(i);
            	
            	//Se analiza cada elemento del JSONObject para ir buscando coincidencias y obeniendo
            	//los valores
            	int isbn = respuestaJSON.getInt("ISBN");
                String nombre_libro = respuestaJSON.getString("NOMBRE");
                String autor_libro = respuestaJSON.getString("AUTOR");
                String editorial_libro = respuestaJSON.getString("EDITORIAL");
                String precio_libro = respuestaJSON.getString("PRECIO");
                String anio_libro = respuestaJSON.getString("ANIO");
                String calificacion_libro = respuestaJSON.getString("CALIFICACION");
                
           
                Libro libro = new Libro(isbn, nombre_libro, autor_libro, 
                		editorial_libro,precio_libro, anio_libro,calificacion_libro);
                libros.add(libro);
            }
		}
		
    	catch (Exception e) {
        
    	}
		
		return libros;
	}
}
