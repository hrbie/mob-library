package com.mobLibrarry.controlador;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.StatusLine;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

public class LectorGetJSON {
	public String getJSONFeed(String URL) {
        StringBuilder stringBuilder = new StringBuilder();
        HttpClient httpCliente = new DefaultHttpClient();
        HttpGet httpGet = new HttpGet(URL);
        try {
            HttpResponse response = httpCliente.execute(httpGet);
            StatusLine statusLine = response.getStatusLine();
            int statusCode = statusLine.getStatusCode();
            if (statusCode == 200) {
                HttpEntity entidad = response.getEntity();
                InputStream inputStream = entidad.getContent();
                BufferedReader reader = new BufferedReader(
                        new InputStreamReader(inputStream));
                String linea;
                while ((linea = reader.readLine()) != null) {
                    stringBuilder.append(linea);
                }
                inputStream.close();
            } else {
                return "error 1";
            }
        } catch (Exception e) {
            return "error 2";
        }        
        return stringBuilder.toString();
    }
}
