/*En esta clase se incluirian los datos que llegaran de la base de datos pero como aun no se hay
conexion con base de datos se agregaran valores "dummy" para la realizacion de pruebas, e 
intentando mantener la facilidad para la adaptabilidad a la hora de que alla conexion*/


package com.moblibrary2.modelo;

import java.util.ArrayList;


public class TestDBO {
	
	public ArrayList<Libreria> getLibrerias()
	{
		ArrayList<Libreria> librerias = new ArrayList<Libreria>();
		
		Libreria libreria1 = new Libreria(0, "Lehmann");
		Libreria libreria2 = new Libreria(1, "Internacional");
		Libreria libreria3 = new Libreria(2, "Alajuela");
		Libreria libreria4 = new Libreria(3, "Clips");
		Libreria libreria5 = new Libreria(4, "Palacio del Libro");
		Libreria libreria6 = new Libreria(5, "The Placer of Read");
		
		librerias.add(libreria1);
		librerias.add(libreria2);
		librerias.add(libreria3);
		librerias.add(libreria4);
		librerias.add(libreria5);
		librerias.add(libreria6);
		
		return librerias;
		
	}
	
	public ArrayList<Libro> getLibros()
	{
		ArrayList<Libro> paises = new ArrayList<Libro>();
		
		Libro libro1 = new Libro(1,"Yo soy Malala", "Crhis Lamber", "UCR","2010");
		Libro libro2 = new Libro(2,"La guerra del fin del mundo", "Mario Vargas Llosa","UCR", "1986");
		Libro libro3 = new Libro(3,"El diario de Ana Frank", "Ana Frank","UCR", "1944");
		Libro libro4 = new Libro(4,"Grandes Pechos, Amplias Caderas", "Mo Yang","UCR", "2003");
		Libro libro5 = new Libro(5,"Historia de Costa Rica", "Esteban Segura","UCR", "2030");
		Libro libro6 = new Libro(6,"Yo soy Malala", "Crhis Lamber","UCR", "2010");
		Libro libro7 = new Libro(7,"La guerra del fin del mundo", "Mario Vargas Llosa","UCR", "1986");
		Libro libro8 = new Libro(8,"El diario de Ana Frank", "Ana Frank","UCR", "1944");
		Libro libro9 = new Libro(9,"Grandes Pechos, Amplias Caderas", "Mo Yang","UCR", "2003");
		Libro libro10 = new Libro(10,"Grandes Pechos, Amplias Caderas", "Mo Yang","UCR", "2003");
		Libro libro11 = new Libro(11,"Yo soy Malala", "Crhis Lamber", "UCR","2010");
		Libro libro12 = new Libro(12,"La guerra del fin del mundo", "Mario Vargas Llosa","UCR", "1986");
		Libro libro13 = new Libro(13,"El diario de Ana Frank", "Ana Frank","UCR", "1944");
		Libro libro14 = new Libro(14,"Grandes Pechos, Amplias Caderas", "Mo Yang","UCR", "2003");
		Libro libro15 = new Libro(15,"Grandes Pechos, Amplias Caderas", "Mo Yang","UCR", "2003");
		
		paises.add(libro1);
		paises.add(libro2);
		paises.add(libro3);
		paises.add(libro4);
		paises.add(libro5);
		paises.add(libro6);
		paises.add(libro7);
		paises.add(libro8);
		paises.add(libro9);
		paises.add(libro10);
		paises.add(libro11);
		paises.add(libro12);
		paises.add(libro13);
		paises.add(libro14);
		paises.add(libro15);
		
		return paises;
		
	}
	
	

}
