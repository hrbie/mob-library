package com.mobLibrarry.modelo;

public class Usuario {
	/*
	 public int ID_USUARIO { get; set; }
	public string NOMBRE { get; set; }
	public string APELLIDO1 { get; set; }
	public string APELLIDO2 { get; set; }
	public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
	public string DIRECCION { get; set; }
	public string EMAIL { get; set; }
	public string USERNAME { get; set; }

	 * */
	
	private int id_usuario;
	private String nombre;
	private String apellido1;
	private String apellido2;
	private String fecha_nacimiento;
	private String direccion;
	private String email;
	private String username;
	
	public Usuario(int id_usuario, String nombre, String apellido1,
			String apellido2, String fecha_nacimiento, String direccion,
			String email, String username) {
		super();
		this.id_usuario = id_usuario;
		this.nombre = nombre;
		this.apellido1 = apellido1;
		this.apellido2 = apellido2;
		this.fecha_nacimiento = fecha_nacimiento;
		this.direccion = direccion;
		this.email = email;
		this.username = username;
	}
	
	public int getId_usuario() {
		return id_usuario;
	}
	public void setId_usuario(int id_usuario) {
		this.id_usuario = id_usuario;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public String getApellido1() {
		return apellido1;
	}
	public void setApellido1(String apellido1) {
		this.apellido1 = apellido1;
	}
	public String getApellido2() {
		return apellido2;
	}
	public void setApellido2(String apellido2) {
		this.apellido2 = apellido2;
	}
	public String getFecha_nacimiento() {
		return fecha_nacimiento;
	}
	public void setFecha_nacimiento(String fecha_nacimiento) {
		this.fecha_nacimiento = fecha_nacimiento;
	}
	public String getDireccion() {
		return direccion;
	}
	public void setDireccion(String direccion) {
		this.direccion = direccion;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	
	

}
