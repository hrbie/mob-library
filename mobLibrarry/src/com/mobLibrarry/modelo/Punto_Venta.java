package com.mobLibrarry.modelo;

public class Punto_Venta {
	private int id_PDV;
	private int id_libreria;
	private String nombre_libreria;
	private String direccion;
	private String telefono;
	private double latitud;
	private double longitud;
	
	public Punto_Venta(int id_PDV,int id_libreria, String nombre_libreria,
			String direccion, String telefono, double latitud, double longitud) {
		super();
		this.id_PDV = id_PDV;
		this.id_libreria = id_libreria;
		this.nombre_libreria = nombre_libreria;
		this.direccion = direccion;
		this.telefono = telefono;
		this.latitud = latitud;
		this.longitud = longitud;
	}
	
	public int getID_PDV()
	{
		return id_PDV;
	}
	
	public void setID_PDV(int id_PDV)
	{
		this.id_PDV = id_PDV;
	}
	
	public int getId_libreria() {
		return id_libreria;
	}

	public void setId_libreria(int id_libreria) {
		this.id_libreria = id_libreria;
	}

	public String getNombre_libreria() {
		return nombre_libreria;
	}

	public void setNombre_libreria(String nombre_libreria) {
		this.nombre_libreria = nombre_libreria;
	}

	public String getDireccion() {
		return direccion;
	}

	public void setDireccion(String direccion) {
		this.direccion = direccion;
	}

	public String getTelefono() {
		return telefono;
	}

	public void setTelefono(String telefono) {
		this.telefono = telefono;
	}

	public double getLatitud() {
		return latitud;
	}

	public void setLatitud(double latitud) {
		this.latitud = latitud;
	}

	public double getLongitud() {
		return longitud;
	}

	public void setLongitud(double longitud) {
		this.longitud = longitud;
	}

	
}
