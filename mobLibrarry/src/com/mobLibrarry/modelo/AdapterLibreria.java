package com.mobLibrarry.modelo;

import java.util.ArrayList;

import com.mobLibrarry.R;


import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class AdapterLibreria  extends ArrayAdapter<Libreria>{
	private Activity contexto;
	
	private ArrayList<Libreria> librerias;
	
	public AdapterLibreria(Activity context, int textViewResourceId, ArrayList<Libreria> librerias){
		super(context, textViewResourceId, librerias);
		this.contexto = context;
		this.librerias = librerias;
		
	}
	
	public int getNumeroElementos() {
		return librerias.size();
	}
	
	@Override
	public Libreria getItem(int posicion) {
		return librerias.get(posicion);
	}
	
	@Override
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
    	View row = convertView;
        if(row == null)
        {
            LayoutInflater inflater = contexto.getLayoutInflater();
            row = inflater.inflate(R.layout.spinner_layout, parent, false);
        }
        
        TextView lblLibrerias = (TextView) row.findViewById(R.id.nombreLibreria);
        lblLibrerias.setTextColor(Color.BLACK);
        lblLibrerias.setText(librerias.get(position).getNombreLibreria());

        
        return row;
	}
}
