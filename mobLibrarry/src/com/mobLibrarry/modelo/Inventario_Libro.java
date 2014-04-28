package com.mobLibrarry.modelo;

public class Inventario_Libro {
	private int id_libreria;
	private int id_PDV;
	private int isbn;
	private int cantidad_disponible;
	
	public Inventario_Libro(int id_libreria, int id_PDV, int isbn, int cantidad_disponible) {
		super();
		this.id_libreria = id_libreria;
		this.id_PDV = id_PDV;
		this.isbn = isbn;
		this.cantidad_disponible = cantidad_disponible;
	}

	public int getId_libreria() {
		return id_libreria;
	}

	public void setId_libreria(int id_libreria) {
		this.id_libreria = id_libreria;
	}

	public int getId_PDV() {
		return id_PDV;
	}

	public void setId_PDV(int id_PDV) {
		this.id_PDV = id_PDV;
	}

	public int getIsbn() {
		return isbn;
	}

	public void setIsbn(int isbn) {
		this.isbn = isbn;
	}

	public int getCantidad_disponible() {
		return cantidad_disponible;
	}

	public void setCantidad_disponible(int cantidad_disponible) {
		this.cantidad_disponible = cantidad_disponible;
	}
	
	

}
