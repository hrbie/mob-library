/*Clase que sirve como ejemplo de como espero que me llegarian los datos de la BASE DE DATOS
*y como se representarian en este caso
*
*En esta clase se detalla el objeto libreria con sus dos elementos que son mas importantes id para
*ubicar los diferentes catalogos en la libreria y el nombre de la libreria 
*/
package com.moblibrary2.modelo;

public class Libreria {
	//VARIABLES
	private int id;
	private String nombre_libreria;
	
	//CONSTRUCTOR
	public Libreria(int id, String nombre_libreria)
	{
		this.id = id;
		this.nombre_libreria = nombre_libreria;
	}

	//GETTERS AND SETTERS
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getNombreLibreria() {
		return nombre_libreria;
	}

	public void setNombreLibreria(String nombre_libreria) {
		this.nombre_libreria = nombre_libreria;
	}
	
	
}
