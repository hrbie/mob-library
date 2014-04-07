package com.moblibrary2.modelo;



import java.util.ArrayList;
import android.content.Context;
import android.graphics.Color;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class AdapterLibreria extends ArrayAdapter<Libreria> {

	private Context contexto;
	
	private ArrayList<Libreria> librerias;
	
	
	public AdapterLibreria(Context context, int textViewResourceId, ArrayList<Libreria> librerias){
		super(context, textViewResourceId, librerias);
		this.contexto = context;
		this.librerias = librerias;
		
	}
	
	public int getNumeroElementos() {
		return librerias.size();
	}
	
	public Libreria getItem(int posicion) {
		return librerias.get(posicion);
	}
	
	public long getItemId(int posicion) {
		return posicion;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub
		TextView lblElementoSeleccionado = new TextView(contexto);
		lblElementoSeleccionado.setTextColor(Color.BLACK);
		
		lblElementoSeleccionado.setText(librerias.get(position).getNombreLibreria());
		
		return lblElementoSeleccionado;
	}
	
    @Override
    public View getDropDownView(int position, View convertView,
            ViewGroup parent) {
        TextView lblLibrerias = new TextView(contexto);
        lblLibrerias.setTextColor(Color.BLACK);
        lblLibrerias.setText(librerias.get(position).getNombreLibreria());

        return lblLibrerias;
	}
	
	
	
	
}

/*REFERENCIAS: 
*http://stackoverflow.com/questions/1625249/android-how-to-bind-spinner-to-custom-object-list
*/