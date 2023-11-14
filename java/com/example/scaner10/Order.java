package com.example.scaner10;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Parcel;
import android.os.StrictMode;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Order extends AppCompatActivity {

    TextView textView;
    TextView textView2;
    GridView gvMain;
    EditText editText;
    ArrayList selectedCategories = new ArrayList<>();

    public static ArrayList<String> ArrayOfOrder = new ArrayList<String>();

    ArrayAdapter<String> adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order);

        //!!!!!Чтобы работали запросы к серверу!!!!!
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        textView2 = (TextView)  findViewById(R.id.textViewNumber);
        gvMain = (GridView) findViewById(R.id.gvMain);
        editText = (EditText) findViewById(R.id.editTextDel);
        adjustGridView();
        int i = 0;
        double pr = 0;
        double cnt = 0;
        double sum = 0;
        String[] inven = new String[0];
        textView = (TextView) findViewById(R.id.textViewItog);
        SQLiteDatabase db = getBaseContext().openOrCreateDatabase("app.db", MODE_PRIVATE, null);
       try{
           Cursor cursor = db.rawQuery("SELECT * FROM pokupki;", null);
           inven = new String[cursor.getCount()*3];
           if (cursor.getCount()>0){
        if (cursor.moveToFirst()) {
            do {
                inven[i] = cursor.getString(1);
                i++;
                inven[i] = cursor.getString(2);
                pr=Double.parseDouble(inven[i]);
                i++;
                inven[i] = cursor.getString(3);
                cnt = Double.parseDouble(inven[i]);
                sum+=pr*cnt;
                i++;
            } while (cursor.moveToNext());
            cursor.close();
        }
        adapter = new ArrayAdapter(this,android.R.layout.simple_list_item_1,inven);
        gvMain.setAdapter(adapter);
        textView.setText(String.valueOf(sum));
    }else{
        Toast toast = Toast.makeText(this, "Пусто! Добавте товар", Toast.LENGTH_LONG);
        toast.show();
    }
            cursor.close();
            db.close();
}catch (Exception e){
        Toast toast = Toast.makeText(this, "Пусто! Добавте товар", Toast.LENGTH_LONG);
        toast.show();
        }
        String[] finalInven = inven;
        gvMain.setOnItemClickListener(new AdapterView.OnItemClickListener() {
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            int firstPos = gvMain.getFirstVisiblePosition();
            View tv = gvMain.getChildAt(position - firstPos);
            //Toast.makeText(this, "You Clicked at position" + position + " " + inven[+position] + "firstPos " + firstPos, Toast.LENGTH_SHORT).show(); //debug

            //меняет цвет выбранным ячейкам
            if (selectedCategories.contains(finalInven[+position]) == false) {//add the item if it doesn't exist
                selectedCategories.add(finalInven[+position]);
                tv.setBackgroundColor(Color.parseColor("#9CBECD"));
            } else { //remove the item if it already exists, as the user is removing it by touching it again
                selectedCategories.remove(finalInven[+position]);
                tv.setBackgroundColor(Color.parseColor("#598A9F"));
            }
            //показывает в тоасте позицию элемента (0,1...,9), надо сделать так, чтобы в переменную запоминалось
            //значение позиции, значение искать в бд и удалять строку
                /*String a = String.valueOf(position);
                Toast.makeText(getApplicationContext(), a, Toast.LENGTH_SHORT).show();*/
        }
    });
    }
    public void onClickDelete(View view) {
        DatabaseHelper mDBHelper = new DatabaseHelper(this);
        String id = editText.getText().toString();
        SQLiteDatabase mdb;
        mdb = mDBHelper.getWritableDatabase();
        mdb.execSQL("DELETE FROM pokupki WHERE id =" + id);
        mdb.close();
        try {
            mDBHelper.updateDataBase();
        } catch (IOException mIOException) {
            throw new Error("UnableToUpdateDatabase");
        }
        int i = 0;
        double pr = 0;
        double cnt = 0;
        double sum = 0;
        String[] inven = new String[0];
        textView = (TextView) findViewById(R.id.textViewItog);
        SQLiteDatabase db = getBaseContext().openOrCreateDatabase("app.db", MODE_PRIVATE, null);
        try{
            Cursor cursor = db.rawQuery("SELECT * FROM pokupki;", null);
            inven = new String[cursor.getCount()*3];
            if (cursor.getCount()>0){
                if (cursor.moveToFirst()) {
                    do {
                        inven[i] = cursor.getString(1);
                        i++;
                        inven[i] = cursor.getString(2);
                        pr=Double.parseDouble(inven[i]);
                        i++;
                        inven[i] = cursor.getString(3);
                        cnt = Double.parseDouble(inven[i]);
                        sum+=pr*cnt;
                        i++;
                    } while (cursor.moveToNext());
                    cursor.close();
                }
                adapter = new ArrayAdapter(this,android.R.layout.simple_list_item_1,inven);
                gvMain.setAdapter(adapter);
                textView.setText(String.valueOf(sum));
            }else{
                Toast toast = Toast.makeText(this, "Пусто! Добавте товар", Toast.LENGTH_LONG);
                toast.show();
            }
            cursor.close();
            db.close();
        }catch (Exception e){
            Toast toast = Toast.makeText(this, "Пусто! Добавте товар", Toast.LENGTH_LONG);
            toast.show();
        }
    }
    @Override
    protected void onSaveInstanceState(@NonNull Bundle outState) {
        super.onSaveInstanceState(outState);
    }
    @Override
    protected void onRestoreInstanceState(@NonNull Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
    }
    public void onClickInsert(View view) {
        Intent intent = new Intent(this, Scaner_2.class);
        startActivity(intent);
    }

    public void onClickQr(View view) {
        String ID;

        SQLiteDatabase db = getBaseContext().openOrCreateDatabase("app.db", MODE_PRIVATE, null);
        Cursor cursor = db.rawQuery("SELECT * FROM pokupki;", null);

        //количество позиций в заказе
        int countRow = cursor.getCount();
        String Json = "[\n";
        int i = 0;
        if (cursor.moveToFirst()) {
            do {
                i++;
                //Json += "{\"id_orderdetail\":" + cursor.getString(0) + ",\n";
                Json += "{\"name\":\"" + cursor.getString(1) + "\",\n";
                Json += "\"price\":" + cursor.getString(2) + ",\n";
                Json += "\"count\":" + cursor.getString(3) + "}";
                Json += (i == countRow) ? "\n" :",\n";
            } while (cursor.moveToNext());
            cursor.close();
        }
        Json += "]";

        cursor.close();

        try{
            //Очитстить таблицу!!!
            db.execSQL("DROP TABLE IF EXISTS pokupki");
        }
        catch (Throwable t) {
            t.printStackTrace();
        }

        db.close();

        //POST запрос
        String url = "http://192.168.0.88/order";
        try {
            HttpURLConnection con = (HttpURLConnection) (new URL(url)).openConnection();
            con.setRequestMethod("POST");
            con.setRequestProperty("Content", "application/json");
            con.setUseCaches(false);
            con.setInstanceFollowRedirects( false );
            con.setDoOutput(true);

            //Собираем тело запроса
            OutputStream os = con.getOutputStream();
            os.write(Json.getBytes());
            os.flush();
            os.close();

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

                //выдергиваем номер заказа!
                ID = result.getString("id_order");

                //выводим в активность
                textView2.setText("Заказ №" + ID);
            }

            //закрываем сооединение
            con.disconnect();

        } catch (Throwable t) {
            t.printStackTrace();
        }
        Toast toast = Toast.makeText(this, "Заказ отправлен!", Toast.LENGTH_LONG);
        toast.show();

    }

    private void adjustGridView() {
        gvMain.setNumColumns(3);
        gvMain.setVerticalSpacing(5);
        gvMain.setHorizontalSpacing(5);
    }

    public void onClickExit(View view) {
        finish();
    }
}