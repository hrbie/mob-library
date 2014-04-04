package com.moblibrary2.vista;

import java.util.ArrayList;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import com.moblibrary2.modelo.AdapterLibreria;
import com.moblibrary2.modelo.Libreria;
import com.moblibrary2.modelo.TestDBO;

public class ActivityBuscar extends Activity {
	
	private Spinner spnLibreria;
	private Spinner spnTipoBusqueda;
	
	AdapterLibreria adapter_libreria;
	ArrayAdapter<?> adapter_tipo_busqueda;
	TestDBO test_DBO = new TestDBO();
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_buscar);
		
		/*e llenana los valores a mostrar del spnLibreria en este caso los valores son traidos de base de datos a la que se 
		 encuentra asociado la aplicacion*/
		ArrayList<Libreria> librerias = test_DBO.getLibrerias();
		
		adapter_libreria = new AdapterLibreria(this, android.R.layout.simple_spinner_item, librerias);

		spnLibreria = (Spinner) findViewById(R.id.spnLibreria);
		spnLibreria.setAdapter(adapter_libreria);
	
		spnLibreria.setOnItemSelectedListener(new OnItemSelectedListener() {
		
			public void onItemSelected(AdapterView<?> parentView, View selectedItemViewed,
					int position, long id){
				Libreria libreria = adapter_libreria.getItem(position);
				Toast.makeText(ActivityBuscar.this, "ID: " + libreria.getId() + "\nNombre: "
				+ libreria.getNombreLibreria(), Toast.LENGTH_SHORT).show();
				
			}
			
			public void onNothingSelected(AdapterView<?> parentView) {
			
			}
		});
		
		/*Se llenana los valores a mostrar del spnTipoBusqueda en este caso los valores son traidos de la carpeta res del proyecto
		del documento XML array_buscar_por*/
		spnTipoBusqueda = (Spinner) findViewById(R.id.spnTipoBusqueda);
		adapter_tipo_busqueda = ArrayAdapter.createFromResource(
				this, R.array.tipo_busqueda,android.R.layout.simple_spinner_dropdown_item);
		adapter_tipo_busqueda.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spnTipoBusqueda.setAdapter(adapter_tipo_busqueda);
		
		
		
		
			
	}
}
