package com.mobLibrarry.modelo;

public class Libro {
	private int id;
	private String nombreLibro;
	private String autorLibro;
	private String editorialLibro;
	private String precio;
	private String ano;
	private String calificacion;
	
	public Libro(int id, String nombreLibro, String autorLibro, String editorialLibro,String precio, 
			String ano, String calificacion) {
		
		this.id = id;
		this.nombreLibro = nombreLibro;
		this.autorLibro = autorLibro;
		this.editorialLibro = editorialLibro;
		this.precio = precio;
		this.ano = ano;
		this.calificacion = calificacion;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getNombreLibro() {
		return nombreLibro;
	}

	public void setNombreLibro(String nombreLibro) {
		this.nombreLibro = nombreLibro;
	}

	public String getAutorLibro() {
		return autorLibro;
	}

	public void setAutorLibro(String autorLibro) {
		this.autorLibro = autorLibro;
	}

	public String getEditorialLibro() {
		return editorialLibro;
	}

	public void setEditorialLibro(String editorialLibro) {
		this.editorialLibro = editorialLibro;
	}
	
	public String getAno() {
		return ano;
	}

	public void setAno(String ano) {
		this.ano = ano;
	}

	public String getPrecio() {
		return precio;
	}

	public void setPrecio(String precio) {
		this.precio = precio;
	}

	public String getCalificacion() {
		return calificacion;
	}

	public void setCalificacion(String calificacion) {
		this.calificacion = calificacion;
	}

	
	
}
