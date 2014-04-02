package com.moblibrary2.vista;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class ActivityMenu extends Activity{
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activty_menu);
	}

	public void llamar_activity_buscar(View view) {
		Intent buscar = new Intent(this, ActivityBuscar.class);
		startActivity(buscar);
		}
}
