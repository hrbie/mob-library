package com.mobLibrarry.modelo;

public class ProximoLeer {
	//{"$id":"1","ID_USUARIO":5,"ISBN":1,"CALIFICACION":5,"OPINION":"esta es una opinion",
	//"ESTADO":"PENDIENTE","LIBRO":null,"USUARIO":null}
	private int usuario;
	private int isbn;
	private String estado;
	
	public ProximoLeer(int usuario, int isbn, String estado) {
		super();
		this.usuario = usuario;
		this.isbn = isbn;
		this.estado = estado;
	}

	public int getUsuario() {
		return usuario;
	}

	public void setUsuario(int usuario) {
		this.usuario = usuario;
	}

	public int getIsbn() {
		return isbn;
	}

	public void setIsbn(int isbn) {
		this.isbn = isbn;
	}

	

	public String getEstado() {
		return estado;
	}

	public void setEstado(String estado) {
		this.estado = estado;
	}
	
	
	
}
