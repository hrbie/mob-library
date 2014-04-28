package com.mobLibrarry.vista;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Intent;
import android.content.res.Resources;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.RatingBar;
import android.widget.Spinner;
import android.widget.TabHost;
import android.widget.TabHost.OnTabChangeListener;
import android.widget.TextView;
import android.widget.Toast;

import com.facebook.HttpMethod;
import com.facebook.Request;
import com.facebook.RequestAsyncTask;
import com.facebook.Session;
import com.facebook.Session.NewPermissionsRequest;
import com.mobLibrarry.R;
import com.mobLibrarry.controlador.LectorGetJSON;
import com.mobLibrarry.modelo.AdapterPuntoVenta;
import com.mobLibrarry.modelo.Opinion_Libros;
import com.mobLibrarry.modelo.Punto_Venta;

public class ActivityInformacionLibro extends Activity{
	
	TextView txtInformacion_NombreLibro;
	
	//Elementos tab 1
	TextView lblISBN;
	TextView lblNombre;
	TextView lblAutor;
	TextView lblEditorial;
	TextView lblPrecio;
	TextView lblAno;
	EditText txtComentario;
	
	//Elementos tab 2
	CheckBox postInFacebook;
	RatingBar calificar_libro;
	
	//Elementos tab 4
	EditText txtCantidad;
	ImageButton btnDisminuir;
	Button btnRealizarPedido;
	ImageButton btnIzquierdo;
	ImageButton btnDerecho;
	
	
	String url_usuario;
	String urlPostPedido;
	
	//Esta Activity se encarga de mostrar en los campos del layout todos los valores obtenidos del resultado de la
	//solicutud de la API, en este caso son los valores del libro seleccionado de la busqueda de libros
	String info_isbn;
	String info_nombre_libro;
	String info_autor_libro;
	String nombreUsuario;
	String info_editorial_libro;
	String info_precio_libro;
	String info_ano_libro;
	String info_calificacion_libro;
	String id_usuario;
	Opinion_Libros opinion_libro;
	
	ArrayList<Punto_Venta> PDVs = new ArrayList<Punto_Venta>();
	String url_PostComentario = "http://moblibrary.azurewebsites.net/api/ListaLibrosAPI/PostLISTA_LIBROS";
	String url_PutComentario = "http://moblibrary.azurewebsites.net//api/ListaLibrosAPI/PutLISTA_LIBROS";
	
	@Override
    protected void onCreate(Bundle savedInstanceState) {
		
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_informacion_libro);
        
       
        
        
        
        
        Bundle extras = getIntent().getExtras();
        id_usuario = extras.getString("id_usuario");
        info_isbn = extras.getString("ISBN");
        info_nombre_libro = extras.getString("NombreLibro");
        info_autor_libro = extras.getString("AutorLibro");
        info_editorial_libro = extras.getString("EditorialLibro");
        info_precio_libro = extras.getString("PrecioLibro");
        info_ano_libro = extras.getString("AnoLibro");
        info_calificacion_libro = extras.getString("CalificacionLibro");
        nombreUsuario = extras.getString("nombreUsuario");
        
        
        
        
        cargarInformacionenLabels(info_autor_libro, info_editorial_libro, info_precio_libro, 
        						info_ano_libro, info_calificacion_libro);
        
        url_usuario = "http://moblibrary.azurewebsites.net/api/UsuarioAPI/GetUSUARIOByUSERNAME/"+nombreUsuario;
        urlPostPedido = "http://moblibrary.azurewebsites.net/api/SolicitudPedidoAPI/PostSOLICITUD_PEDIDO";
		
        txtInformacion_NombreLibro = (TextView) findViewById(R.id.txtInfomracion_NombreLibro);
        txtInformacion_NombreLibro.setText(info_nombre_libro);
        
        txtComentario = (EditText) findViewById(R.id.txtComentario);
		ImageButton btnAgregarMiLista;
		postInFacebook = (CheckBox) findViewById(R.id.chkPostFacebook);
		calificar_libro = (RatingBar) findViewById(R.id.rtbCalificar);
		postInFacebook.setChecked(true);
		
		cargarTabs();
        
		Button btnCalificar=(Button) findViewById(R.id.btnCalificar_Libro);
		btnCalificar.setOnClickListener(new OnClickListener() {
	
			@Override
			public void onClick(View v) {
				String comentario = txtComentario.getText()+"";
				
				String mensaje =comentario + "\nCalificacion: "
						+ calificar_libro.getRating()+" de 5 puntos";
						
            	if(postInFacebook.isChecked())
            	{
            		publicarPost(v, mensaje);
            		
            		if(opinion_libro == null)
            		{
            			new PostLectorComentariosREST().execute(url_PostComentario);
            		}
            		{
            			new PutLectorComentariosREST().execute(url_PutComentario);
            		}
            		
            		Toast.makeText(getApplicationContext(), "El comentario se realizo correctamente", Toast.LENGTH_SHORT);
            		
            	}
            	else
            	{
            		if(opinion_libro == null)
            		{
            			new PostLectorComentariosREST().execute(url_PostComentario);
            		}
            		{
            			new PutLectorComentariosREST().execute(url_PutComentario);
            		}
            	}
			}
		});
		
		btnAgregarMiLista = (ImageButton) findViewById(R.id.btnAgregarMiLista);
		btnAgregarMiLista.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View arg0) {
				// TODO Auto-generated method stub
				Toast.makeText(getApplicationContext(),"El libro se agrego correctamente a la lista",Toast.LENGTH_SHORT).show();
				
			}
		});
		
		//Cargar elementos tab4
		txtCantidad = (EditText) findViewById(R.id.txtCantidadEjemplares);
        btnDisminuir = (ImageButton) findViewById(R.id.btnDisminuir);
        btnRealizarPedido = (Button) findViewById(R.id.btnRealizarPedido); 
        
        
        txtCantidad.setEnabled(false);
        btnDisminuir.setEnabled(false);
        
        txtCantidad.setText("0");
        
        btnRealizarPedido.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View view) {
				
				
			}
		});
        	final String[] estados_posibles = {"Pendiente","Leyendo","Leido"};
        	final TextView lblEstados = (TextView) findViewById(R.id.lblEstados_Posibles);
        	lblEstados.setText("Pendiente");
        	btnIzquierdo = (ImageButton) findViewById(R.id.btnMover_Izquierdo);
        	btnIzquierdo.setOnClickListener(new OnClickListener() {
			
        	int local = 0;
        	@Override
			public void onClick(View view) {
				if(local==0)
				{
					local=2;
				}
				else
				{
					local = local-1;
				}
				lblEstados.setText(estados_posibles[local]);
				
			}
		});
        	
        	btnDerecho = (ImageButton) findViewById(R.id.btnMover_Derecho);
        	btnDerecho.setOnClickListener(new OnClickListener() {
        		int local = 0;
    			@Override
    			public void onClick(View view) {
    				if(local==2)
    				{
    					local=0;
    				}
    				else
    				{
    					local = local+1;
    				}
    				lblEstados.setText(estados_posibles[local]);
    				
    			}
    		});
        
        String url = crearUr_getComentariobyUsuario(id_usuario, info_isbn);
		new GetLectorComentario().execute(url);
 }
	 
	public void cargarTabs()
	{
		Resources res = getResources();
		TabHost tabs=(TabHost)findViewById(android.R.id.tabhost);
		tabs.setup();
		 
		TabHost.TabSpec spec=tabs.newTabSpec("tabInformacion");
		spec.setContent(R.id.tab1);
		spec.setIndicator("",
		    res.getDrawable(R.drawable.informacion));
		tabs.addTab(spec);
		 
		spec=tabs.newTabSpec("mitab2");
		spec.setContent(R.id.tab2);
		spec.setIndicator("",
		    res.getDrawable(R.drawable.comentarios));
		
		tabs.addTab(spec);
		
		 
		spec=tabs.newTabSpec("mitab3");
		spec.setContent(R.id.tab3);
		spec.setIndicator("",
		    res.getDrawable(R.drawable.proximo));
		tabs.addTab(spec);
		tabs.setCurrentTab(0);
		
		spec=tabs.newTabSpec("mitab4");
		spec.setContent(R.id.tab4);
		spec.setIndicator("",
		    res.getDrawable(R.drawable.pedidos));
		tabs.addTab(spec);
		tabs.setCurrentTab(0);
		tabs.setOnTabChangedListener(new OnTabChangeListener() {
			
			@Override
			public void onTabChanged(String id_tab) {
				if(id_tab.equals("mitab2"))
				{
					
					
					if(opinion_libro==null)
					{
						
					}
					{
						RatingBar rtbCalificar = (RatingBar) findViewById(R.id.rtbCalificar);
						txtComentario.setText(opinion_libro.getOpinion());
						rtbCalificar.setRating(opinion_libro.getCalificacion());
						rtbCalificar.setEnabled(true);
						
					}
					
				}
				if(id_tab.equals("mitab4"))
				{
					Toast.makeText(getApplicationContext(), "toast 4",Toast.LENGTH_SHORT).show();
					String url = "http://moblibrary.azurewebsites.net/api/PuntoVentaAPI/GetPUNTO_VENTA";
					
					new GetLectorPuntoVentaREST().execute(url);
					
					btnRealizarPedido=(Button) findViewById(R.id.btnRealizarPedido);
					btnRealizarPedido.setOnClickListener(new OnClickListener() {
						
						@Override
						public void onClick(View arg0) {
							Toast.makeText(getApplicationContext(), "Su pedido se proceso correctamente",  Toast.LENGTH_SHORT).
							show();
							
							new PostLectorPedidoREST().execute(urlPostPedido);
							
						}
					});
					
				}
				
			}
		});
	}
	
	
	public void cargarInformacionenLabels(String info_autor_libro,String info_editorial_libro,
		String info_precio_libro, String info_ano_libro, String info_calificacion_libro) {
		lblISBN = (TextView) findViewById(R.id.lblInformacion_ISBN2);
        lblNombre = (TextView) findViewById(R.id.lblInformacion_NombrelLibro);
        lblAutor = (TextView) findViewById(R.id.lblInformacion_AutorLibro);
        lblEditorial = (TextView) findViewById(R.id.lblInformacion_EditorialLibro);
        lblPrecio = (TextView) findViewById(R.id.lblInformacion_Precio);
        lblAno = (TextView) findViewById(R.id.lblInformacion_AnoLibro);
        //TextView lblCalificacion = (TextView) findViewById(R.id.lblInforamcion_CalificacionLibro);
        RatingBar rtbCalificacion = (RatingBar)findViewById(R.id.rtbInformacion_CalificacionGeneral);
        
        lblISBN.setText(info_isbn);
        lblNombre.setText(info_nombre_libro);
        lblAutor.setText(info_autor_libro);
        lblEditorial.setText(info_editorial_libro);
        lblPrecio.setText(info_precio_libro);
        lblAno.setText(info_ano_libro);
        rtbCalificacion.setRating(Integer.parseInt(info_calificacion_libro));
        rtbCalificacion.setEnabled(false);
        //lblCalificacion.setText(info_calificacion_libro);
		
	}
	
	public void aumentar(View view)
	{
		String cantidad = txtCantidad.getText()+"";
		int cantidad_ejemplares = Integer.parseInt(cantidad) + 1; 
		txtCantidad.setText(cantidad_ejemplares+"");
		if(cantidad_ejemplares==0)
		{
			btnDisminuir.setEnabled(false);
		}
		else
		{
			btnDisminuir.setEnabled(true);
		}
	}
	
	public void disminuir(View view)
	{
		
		
		String cantidad = txtCantidad.getText()+"";
		
		int cantidad_ejemplares = Integer.parseInt(cantidad) - 1; 
		txtCantidad.setText(cantidad_ejemplares+"");
		if(cantidad_ejemplares==0)
		{
			btnDisminuir.setEnabled(false);
		}
		else
		{
			btnDisminuir.setEnabled(true);
		}
	}
	
	 
	 public void llamar_activity_ver_comentarios(View view) {
			Intent verComentarios = new Intent(this, ActivityVerComentarios.class);
			verComentarios.putExtra("ISBN", info_isbn);
			verComentarios.putExtra("NombreLibro", info_nombre_libro);
			verComentarios.putExtra("nombreUsuario", nombreUsuario);
			startActivity(verComentarios);
		}
	 
	 public void publicarPost(View view,String mensaje) {
			final Bundle parametros = new Bundle();
			parametros.putString("name", "https://moblibrary.azurewebsites.net/");
			parametros.putString("link", "https://moblibrary.azurewebsites.net/");
			//parametros.putString('picture', '');
			parametros.putString("caption", "mobLibrary");
			parametros.putString("message", mensaje);
			parametros.putString("description", info_nombre_libro);
			final List<String> PERMISSIONS = Arrays.asList("publish_stream");
			if (Session.getActiveSession() != null) {
			    NewPermissionsRequest autorizacionRequest = new Session.NewPermissionsRequest(this, PERMISSIONS);
			    Session.getActiveSession().requestNewPublishPermissions(autorizacionRequest);
			    this.runOnUiThread(new Runnable() {
				    @Override
				    public void run() {
				        Request request = new Request(Session.getActiveSession(), "me/feed", parametros, HttpMethod.POST);
				        RequestAsyncTask task = new RequestAsyncTask(request);
				        task.execute();
				    }
				});
			}
		}

	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data) {
	    super.onActivityResult(requestCode, resultCode, data);
	   Session.getActiveSession().onActivityResult(this, requestCode, resultCode, data);
	}
	
	public void llamar_activity_buscar(View view) {
		Intent buscar = new Intent(this, ActivityBuscar.class);
		buscar.putExtra("nombreUsuario", nombreUsuario);
		startActivity(buscar);
	}
	
	private String getDate()

    {
        Calendar cal = new GregorianCalendar();
        Date date = cal.getTime();
        SimpleDateFormat simple_date_format = new SimpleDateFormat("MM/dd/yyyy");

        String formatteDate = simple_date_format.format(date);

        return formatteDate;

    }
	
	private class PostLectorComentariosREST extends AsyncTask
	<String,Integer,Boolean> {
     @Override
	protected Boolean doInBackground(String... urls) {
     	
     	boolean resul = true;
     	try {
     		//Se va hacer un post
             HttpPost request = new HttpPost(url_PostComentario);
             
             //En caso de ser de la primera o segunda forma
             //request.setHeader("Accept", "application/json");
             //request.setHeader("Content-type", "application/json");
             
             
             //Primera Forma
             // Build JSON string
             /*JSONObject comentario = new JSONObject();
             
            
            
             comentario.put("id_usuario", 1);
             comentario.put("isbn", 1);
             comentario.put("calificacion", 1);
             comentario.put("opinion", "me gusta esta aplicacion");*/
             
             
             //Segunda Forma
             /*JSONStringer comentario = new JSONStringer().object()
             		.key("id_usuario").value(1)
             		.key("isbn").value(1)
             		.key("calificacion").value(1)
             		.key("opinion").value("india")
             		.endObject();*/
             
             //Tercera Forma
             List<NameValuePair> comentario = new ArrayList<NameValuePair>();
             comentario.add(new BasicNameValuePair("id_usuario", id_usuario+""));
             comentario.add(new BasicNameValuePair("isbn", info_isbn));
             comentario.add(new BasicNameValuePair("calificacion", (int) Math.floor(calificar_libro.getRating())+""));
             comentario.add(new BasicNameValuePair("opinion", txtComentario.getText()+""));
             request.setEntity(new UrlEncodedFormEntity(comentario));

             HttpClient httpClient = new DefaultHttpClient();
             HttpResponse response = httpClient.execute(request);

             String respStr = EntityUtils.toString(response.getEntity());
             if(!respStr.equals("true"))
                 resul = false;
             
             
             

      } catch (Exception e) {
     	 resul = false;
     	 Toast.makeText(getApplicationContext(),"Error "+e.getMessage() , Toast.LENGTH_SHORT).show();
      }
     	return resul;
     }
     
     protected void onPostExecute(String result) {
         try {
             
     		
         } catch (Exception e) {
         	Toast.makeText(getApplicationContext(),"Error "+e.getMessage() , Toast.LENGTH_SHORT).show();
         }          
     }
	}
	
	
	private class PutLectorComentariosREST extends AsyncTask
	<String,Integer,Boolean> {
     @Override
	protected Boolean doInBackground(String... urls) {
     	
     	boolean resul = true;
     	try {
     		//Se va hacer un put
             HttpPut request = new HttpPut(urls[0]);
             
             List<NameValuePair> comentario = new ArrayList<NameValuePair>();
             comentario.add(new BasicNameValuePair("id_usuario", id_usuario+""));
             comentario.add(new BasicNameValuePair("isbn", info_isbn));
             comentario.add(new BasicNameValuePair("calificacion", (int) Math.floor(calificar_libro.getRating())+""));
             comentario.add(new BasicNameValuePair("opinion", txtComentario.getText()+""));
             comentario.add(new BasicNameValuePair("estado", "PENDIENTE"));
             request.setEntity(new UrlEncodedFormEntity(comentario));

             HttpClient httpClient = new DefaultHttpClient();
             HttpResponse response = httpClient.execute(request);

             String respStr = EntityUtils.toString(response.getEntity());
             if(!respStr.equals("true"))
                 resul = false;
             
             
             

      } catch (Exception e) {
     	 resul = false;
     	 Toast.makeText(getApplicationContext(),"Error "+e.getMessage() , Toast.LENGTH_SHORT).show();
      }
     	return resul;
     }
     
     protected void onPostExecute(String result) {
         try {
             
     		
         } catch (Exception e) {
         	Toast.makeText(getApplicationContext(),"Error "+e.getMessage() , Toast.LENGTH_SHORT).show();
         }          
     }
	}
	
	private class GetLectorPuntoVentaREST extends AsyncTask
    <String, Void, String> {
        @Override
		protected String doInBackground(String... urls) {
        	LectorGetJSON lectorJSON = new LectorGetJSON();
            return lectorJSON.getJSONFeed(urls[0]);
        }
        @Override
		protected void onPostExecute(String result) {
            
        	try {
                JSONArray respuestaArrayJSON = new JSONArray(result);
               
                for(int i=0; i<respuestaArrayJSON.length();i++)
                {
                	JSONObject respuestaJSON = respuestaArrayJSON.getJSONObject(i);
                	int id_PDV = respuestaJSON.getInt("ID_PDV");
                	int id_libreria = respuestaJSON.getInt("ID_LIBRERIA");
                    String nombre_libreria = respuestaJSON.getString("NOMBRE");
                    String direccion = respuestaJSON.getString("DIRECCIÓN");
                    String telefono = respuestaJSON.getString("TELEFONO");
                    double latitud = respuestaJSON.getDouble("LATITUD");
                    double longitud = respuestaJSON.getDouble("LONGITUD");
                    Punto_Venta pdv = new Punto_Venta(id_PDV, id_libreria, nombre_libreria, direccion, telefono, latitud,
                    								longitud);
                    PDVs.add(pdv);
                }
                
//--------------------- INTERFAZ -------------------------------------------------------------
                Activity context = ActivityInformacionLibro.this;
                AdapterPuntoVenta adapter_PDV = 
                new AdapterPuntoVenta(context, android.R.layout.simple_spinner_item, PDVs);
        		Spinner spnPuntoVenta = (Spinner) findViewById(R.id.spnPuntoVenta);
        		spnPuntoVenta.setAdapter(adapter_PDV);
        		
        		
        		
        		
            } catch (Exception e) {
            	Toast.makeText(getApplicationContext(),"Error "+e.getMessage() , Toast.LENGTH_SHORT).show();
            }          
        }
    }
	
	private class GetLectorComentario extends AsyncTask
    <String, Void, String> {
        @Override
		protected String doInBackground(String... urls) {
        	LectorGetJSON lectorJSON = new LectorGetJSON();
            return lectorJSON.getJSONFeed(urls[0]);
        }
        @Override
		protected void onPostExecute(String result) {
            
        	try {
                JSONArray respuestaArrayJSON = new JSONArray(result);
               
                for(int i=0; i<respuestaArrayJSON.length();i++)
                {
                	JSONObject respuestaJSON = respuestaArrayJSON.getJSONObject(i);
                	int id_tabla = respuestaJSON.getInt("$id");
                	int id_usuario = respuestaJSON.getInt("ID_USUARIO");
                	long isbn = respuestaJSON.getLong("ISBN");
                    int calificacion = respuestaJSON.getInt("CALIFICACION");
                    String opinion = respuestaJSON.getString("OPINION");
                    String estado = respuestaJSON.getString("ESTADO");
                    
                    opinion_libro = new Opinion_Libros(id_tabla,id_usuario, isbn, calificacion, opinion, estado);
                    
                }
                
//--------------------- INTERFAZ -------------------------------------------------------------
                Activity context = ActivityInformacionLibro.this;
                AdapterPuntoVenta adapter_PDV = 
                new AdapterPuntoVenta(context, android.R.layout.simple_spinner_item, PDVs);
        		Spinner spnPuntoVenta = (Spinner) findViewById(R.id.spnPuntoVenta);
        		spnPuntoVenta.setAdapter(adapter_PDV);
        		
        		
        		
        		
            } catch (Exception e) {
            	Toast.makeText(getApplicationContext(),"Error "+e.getMessage() , Toast.LENGTH_SHORT).show();
            }          
        }
    }
	
	private class PostLectorPedidoREST extends AsyncTask
	<String,Integer,Boolean> {
        @Override
		protected Boolean doInBackground(String... urls) {
        	boolean resul = true;
        	try {

                HttpPost request = new HttpPost(urls[0]); //REVISAR ESTA PARTE
               
                List<NameValuePair> pedido = new ArrayList<NameValuePair>();
                pedido.add(new BasicNameValuePair("id_usuario", id_usuario));
                pedido.add(new BasicNameValuePair("id_libreria", PDVs.get(0).getId_libreria()+""));
                pedido.add(new BasicNameValuePair("id_pdv", PDVs.get(0).getID_PDV()+""));
                pedido.add(new BasicNameValuePair("isbn", info_isbn));
                pedido.add(new BasicNameValuePair("fecha", getDate()));
                pedido.add(new BasicNameValuePair("estado", "PENDIENTE"));
                pedido.add(new BasicNameValuePair("cantidad", txtCantidad.getText().toString()));
                request.setEntity(new UrlEncodedFormEntity(pedido));

                HttpClient httpClient = new DefaultHttpClient();
                HttpResponse response = httpClient.execute(request);

                String respStr = EntityUtils.toString(response.getEntity());
                if(!respStr.equals("true"))
                    resul = false;
                
                
                

         } catch (Exception e) {
        	 resul = false;
        	 Toast.makeText(getApplicationContext(),"Error "+e.getMessage() , Toast.LENGTH_SHORT).show();
         }
        	return resul;
        }
	}
	
	
	
	private String crearUr_getComentariobyUsuario(String id_usuario, String isbn)
	{
		//Se va armando el URL paso a paso para ser enviado al API con la url completa
    	Uri url_sin_formar = new Uri.Builder()
        .scheme("https")
        .authority("moblibrary.azurewebsites.net")
        .path("api/ListaLibrosAPI/GetLISTA_LIBROSByLibroAndUsuario")
        .appendQueryParameter("id_usuario", id_usuario)
        .appendQueryParameter("isbn", isbn)
        .build();
    	return url_sin_formar.toString();
	}

}
