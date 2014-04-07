package com.moblibrary2.vista;

import java.util.ArrayList;

import org.w3c.dom.Text;


import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.EditText;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

public class ActivityResultados extends Activity{
	TableLayout tabla_resultados;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activty_resultados);
		
		Bundle extras = getIntent().getExtras();
		String nombre = extras.getString("nombreLibreria");
		String tipoBuscar = extras.getString("tipoBuscar");
		String buscar = extras.getString("Buscar");
		
		
		TextView lblLibreria = (TextView) findViewById(R.id.lblNombreLibreria);
		TextView lblBuscar = (TextView) findViewById(R.id.lblBusqueda);
		
		lblLibreria.setText(nombre);
		lblBuscar.setText(buscar);
		
		tabla_resultados=(TableLayout)findViewById(R.id.tabla_resultados);
		
		llenarTablaResultados();
	}
	
void llenarTablaResultados() {
		  
      TableRow row;
      TextView lblNombreLibro, lblAutorLibro, lblAnoLibro;
      
      
      com.moblibrary2.modelo.TestDBO lista_paises = new com.moblibrary2.modelo.TestDBO();
      ArrayList<com.moblibrary2.modelo.Libro> paises = lista_paises.getLibros();
      
      
      for (int current = 0; current < paises.size(); current++) {
          row = new TableRow(this);

          lblNombreLibro = new TextView(this);
          lblNombreLibro.setTextColor(getResources().getColor(android.R.color.black));
          lblAutorLibro = new TextView(this);
          
          lblAutorLibro.setTextColor(getResources().getColor(android.R.color.black));
          lblAnoLibro= new TextView(this);
          lblAnoLibro.setTextColor(getResources().getColor(android.R.color.black));

          lblNombreLibro.setText(paises.get(current).getNombreLibro());
          lblAutorLibro.setText(paises.get(current).getAutorLibro());
          lblAnoLibro.setText(paises.get(current).getAno());
          
          final int id = paises.get(current).getId();
          final String nombre = paises.get(current).getNombreLibro();
          final String autor = paises.get(current).getAutorLibro();
          final String ano = paises.get(current).getAno();
          
          lblNombreLibro.setClickable(true);
          lblNombreLibro.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Toast.makeText(ActivityResultados.this, "ID: " + id + "\nNombre: "
						+ nombre+"\nAutor: "+autor+"\nAño: "+ano ,Toast.LENGTH_SHORT).show();
			}
		});
          
          lblNombreLibro.setTypeface(null, 1);
          lblAutorLibro.setTypeface(null, 1);
          lblAnoLibro.setTypeface(null, 1);

          lblNombreLibro.setTextSize(20);
          lblAutorLibro.setTextSize(20);
          lblAnoLibro.setTextSize(20);

          lblNombreLibro.setWidth(80);
          lblAnoLibro.setWidth(80);
          lblNombreLibro.setPadding(10, 20, 0, 0);
          lblAnoLibro.setPadding(0, 20, 0, 0);
         
          row.addView(lblNombreLibro);
          row.addView(lblAutorLibro);
          row.addView(lblAnoLibro);

          tabla_resultados.addView(row, new TableLayout.LayoutParams(
                  LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));
          
      }
  }
	
}
