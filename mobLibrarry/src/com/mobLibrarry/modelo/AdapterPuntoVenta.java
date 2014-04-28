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

public class AdapterPuntoVenta extends ArrayAdapter<Punto_Venta>{
	private Activity contexto;
	
	private ArrayList<Punto_Venta> PDVs;
	
	public AdapterPuntoVenta(Activity context, int textViewResourceId, ArrayList<Punto_Venta> PDVs){
		super(context, textViewResourceId, PDVs);
		this.contexto = context;
		this.PDVs = PDVs;
	}
	
	public int getNumeroElementos() {
		return PDVs.size();
	}
	
	@Override
	public Punto_Venta getItem(int posicion) {
		return PDVs.get(posicion);
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
		
		lblElementoSeleccionado.setText(PDVs.get(position).getNombre_libreria());
		
		return lblElementoSeleccionado;
	}
	
    
     @Override
    public View getDropDownView(int position, View convertView,
            ViewGroup parent) 
     {
    	View row = convertView;
        if(row == null)
        {
            LayoutInflater inflater = contexto.getLayoutInflater();
            row = inflater.inflate(R.layout.spinner_layout, parent, false);
        }
        
        TextView lblElementoSeleccionado  = (TextView) row.findViewById(R.id.nombreLibreria);
		lblElementoSeleccionado.setTextColor(Color.BLACK);
        lblElementoSeleccionado.setText(PDVs.get(position).getNombre_libreria());

        
        return row;
	}
}
