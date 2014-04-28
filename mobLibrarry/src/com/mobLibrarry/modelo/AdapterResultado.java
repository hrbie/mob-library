package com.mobLibrarry.modelo;

import java.util.ArrayList;

import com.mobLibrarry.R;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.RatingBar;
import android.widget.TextView;


public class AdapterResultado extends ArrayAdapter<Libro>{
	private final Context context;
    private final ArrayList<Libro> libros;
	public AdapterResultado(Context context, ArrayList<Libro> libros) {

        super(context, R.layout.columnas_resultado, libros);

        this.context = context;
        this.libros = libros;
    }
	
	 @Override
	    public View getView(int position, View convertView, ViewGroup parent) {
 
	        LayoutInflater inflater = (LayoutInflater) context
	            .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

	        View row_resultado_view = inflater.inflate(R.layout.columnas_resultado, parent, false);

	        //Se muestra
	        TextView rowNombreLibro = (TextView) row_resultado_view.findViewById(R.id.row_nombre_libro);
	        TextView rowAutor = (TextView) row_resultado_view.findViewById(R.id.row_autor);
	        RatingBar rtbCalificacion = (RatingBar) row_resultado_view.findViewById(R.id.rtbColumnaResultado_Calificar);
	        
	        //No se muestra
	        TextView rowAno = (TextView) row_resultado_view.findViewById(R.id.row_ano);
	        TextView rowCalificacion = (TextView) row_resultado_view.findViewById(R.id.row_calificacion);
	        TextView rowPrecio = (TextView) row_resultado_view.findViewById(R.id.row_precio);
	        TextView rowEditorial = (TextView) row_resultado_view.findViewById(R.id.row_editorial);
	        TextView rowId = (TextView) row_resultado_view.findViewById(R.id.row_id);

	        //Se muestra
	        rowNombreLibro.setText(libros.get(position).getNombreLibro());
	        rowAutor.setText(libros.get(position).getAutorLibro());
	        
	        
	      //No se muestra
	        rtbCalificacion.setRating(Float.parseFloat(libros.get(position).getCalificacion()));
	        rtbCalificacion.setEnabled(false);
	        rtbCalificacion.setFocusable(false);
	        rtbCalificacion.setClickable(false);
	        //rtbCalificacion.setVisibility(View.GONE);
	        
	        rowAno.setText(libros.get(position).getAno());
	        rowAno.setVisibility(View.GONE);
	        rowEditorial.setText(libros.get(position).getEditorialLibro());
	        rowEditorial.setVisibility(View.GONE);
	        rowCalificacion.setText(libros.get(position).getCalificacion());
	        rowCalificacion.setVisibility(View.GONE);
	        rowPrecio.setText(libros.get(position).getPrecio());
	        rowPrecio.setVisibility(View.GONE);
	        rowId.setText(libros.get(position).getId()+"");
	        rowId.setVisibility(View.GONE);

	        // 5. retrn rowView
	        return row_resultado_view;
	    }

}


