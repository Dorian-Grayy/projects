package com.example.scaner10;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.os.StrictMode;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.sql.PreparedStatement;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class Scanner extends AppCompatActivity {

    TextView textView1;
    EditText editText = null;
    TextView textView2;
    TextView textView3;
    EditText editText2 = null;

    private String ID;
    private String NAME;
    private String PRICE;
    private String COUNT;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_scaner);

        textView1 = (TextView) findViewById(R.id.textViewInfo1);
        editText = (EditText) findViewById(R.id.editTextPoisk);
        textView2 = (TextView) findViewById(R.id.textViewInfo2);
        textView3 = (TextView) findViewById(R.id.textViewInfo3);
        editText2 = (EditText) findViewById(R.id.editTextCount1);

        //!!!!!Чтобы работали запросы к серверу!!!!!
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
    }

    @SuppressLint("SetTextI18n")
    public void onClickScan2(View view) {
        String id = editText.getText().toString();

        //обработка нажатия клавиши
        if (id.length() == 0) {
            Toast.makeText(this, "Заполните поле!", Toast.LENGTH_LONG).show();
        } else {
            downloadInfo(id);
        }
        editText.setText("");
    }

    public void downloadInfo(String id) {

        String url = "http://192.168.0.88/inven?barcode=" + id;
        //String url = "http://192.168.100.253/inven?barcode=" + id;
        try {
            HttpURLConnection con = (HttpURLConnection) (new URL(url)).openConnection();
            con.setRequestMethod("GET");
//                con.setDoInput(true);
//                con.setDoOutput(true);
            con.setRequestProperty("Content-length", "0");
            con.setUseCaches(false);
            con.setAllowUserInteraction(false);
            con.connect();

            if (con.getResponseCode() == 200) {
                //Получаем контент
                BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream()));
                StringBuilder sb = new StringBuilder();
                String line;
                while ((line = br.readLine()) != null) {
                    sb.append(line).append("\n");
                }
                br.close();

                //преобразуем в json
                JSONObject result = new JSONObject(sb.toString());

                //выдергиваем нужные значения
                ID = result.getString("id");
                NAME = result.getString("name");
                PRICE = result.getString("price");
                COUNT = result.getString("count");

                //выводим в активность
                textView1.setText(NAME);
                textView2.setText(PRICE);
                textView3.setText(COUNT);

            }

            //закрываем сооединение
            con.disconnect();

        } catch (Throwable t) {
            t.printStackTrace();
        }
    }

    public void onClickIns(View view) {

        String Count = editText2.getText().toString();

        if (Count.equals("")){
            Count="1";
        }
        SQLiteDatabase db = getBaseContext().openOrCreateDatabase("app.db", MODE_PRIVATE, null);
        db.execSQL("CREATE TABLE IF NOT EXISTS pokupki (id TEXT, name TEXT, price TEXT, count TEXT, UNIQUE(name))");
        db.execSQL("INSERT OR IGNORE INTO pokupki VALUES ('"+ID+"','"+NAME+"','"+PRICE+"','"+Count+"')");
        db.close();

    }

    public void onClickExit(View view) {
        finish();
    }
}
