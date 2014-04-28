package com.mobLibrarry.modelo;




public class Opinion_Libros {
	private int id_tabla;
    private int id_usuario; 
    private long isbn;
    private int calificacion;
    private String opinion;
    private String estado;
    
    public Opinion_Libros(int id_usuario, long isbn, int calificacion, String opcion) {
    	this.id_usuario = id_usuario;
    	this.isbn = isbn;
    	this.calificacion = calificacion;
    	this.opinion = opcion;
		
	}
    
    public Opinion_Libros(int id_usuario, long isbn, int calificacion, String opcion, String estado) {
    	this.id_usuario = id_usuario;
    	this.isbn = isbn;
    	this.calificacion = calificacion;
    	this.opinion = opcion;
    	this.estado = estado;
		
	}
    
    public Opinion_Libros(int id_tabla, int id_usuario, long isbn, int calificacion, String opcion, String estado) {
    	this.id_tabla = id_tabla;
    	this.id_usuario = id_usuario;
    	this.isbn = isbn;
    	this.calificacion = calificacion;
    	this.opinion = opcion;
    	this.estado = estado;
		
	}

	public int getId_usuario() {
		return id_usuario;
	}

	public void setId_usuario(int id_usuario) {
		this.id_usuario = id_usuario;
	}

	public long getIsbn() {
		return isbn;
	}

	public void setIsbn(long isbn) {
		this.isbn = isbn;
	}

	public int getCalificacion() {
		return calificacion;
	}

	public void setCalificacion(int calificacion) {
		this.calificacion = calificacion;
	}

	public String getOpinion() {
		return opinion;
	}

	public void setOpinion(String opinion) {
		this.opinion = opinion;
	}

	public String getEstado() {
		return estado;
	}

	public void setEstado(String estado) {
		this.estado = estado;
	}

	public int getId_tabla() {
		return id_tabla;
	}

	public void setId_tabla(int id_tabla) {
		this.id_tabla = id_tabla;
	}
    
	
    

}
