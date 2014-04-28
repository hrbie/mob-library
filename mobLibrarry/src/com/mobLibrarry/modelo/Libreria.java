package com.mobLibrarry.modelo;

public class Libreria {
	//VARIABLES
	private int id;
	private String nombre_libreria;
	private String descripcion;
	
	//CONSTRUCTOR
	public Libreria(int id, String nombre_libreria, String descripcion)
	{
		this.id = id;
		this.nombre_libreria = nombre_libreria;
		this.descripcion = descripcion;
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

	public String getDescripcion() {
		return descripcion;
	}

	public void setDescripcion(String descripcion) {
		this.descripcion = descripcion;
	}
			 
}
