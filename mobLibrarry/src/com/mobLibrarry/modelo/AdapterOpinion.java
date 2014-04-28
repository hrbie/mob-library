package com.mobLibrarry.modelo;

import java.util.ArrayList;

import com.mobLibrarry.R;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class AdapterOpinion extends ArrayAdapter<Opinion_Libros>{
	final private Context context;
	final private ArrayList<Opinion_Libros> opiniones;
	public AdapterOpinion(Context context, ArrayList<Opinion_Libros> opiniones) {

        super(context, R.layout.columnas_resultado, opiniones);

        this.context = context;
        this.opiniones = opiniones;
    }
	
	@Override
    public View getView(int position, View convertView, ViewGroup parent) {

	    LayoutInflater inflater = (LayoutInflater) context
	        .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
	
	    View row_opiniones_view = inflater.inflate(R.layout.columnas_opiniones, parent, false);
	
	    TextView rowNombreUsuario = (TextView) row_opiniones_view.findViewById(R.id.row_nombre_usuario);
	    TextView rowCalificacion = (TextView) row_opiniones_view.findViewById(R.id.row_calificacion);
	    TextView rowComentario = (TextView) row_opiniones_view.findViewById(R.id.row_comentario);
	   
	    rowNombreUsuario.setText(opiniones.get(position).getId_usuario()+"");
	    rowCalificacion.setText(opiniones.get(position).getCalificacion()+"");
	    rowComentario.setText(opiniones.get(position).getOpinion());
	    
	    return row_opiniones_view;
    }

}
