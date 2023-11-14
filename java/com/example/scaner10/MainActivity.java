package com.example.scaner10;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ActivityNotFoundException;
import android.content.Intent;
import android.content.res.AssetManager;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.widget.Toast;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void onClickScan(View view) {
        Intent intent = new Intent(this, Scanner.class);
        startActivity(intent);
    }

    public void onClickOrder(View view) {
        Intent intent = new Intent(this, Order.class);
        startActivity(intent);
    }

    public void onClickScan2(View view) {
        Intent intent = new Intent(this, Scaner_2.class);
        startActivity(intent);
    }

    public void onClickInfo(View view) {
        Intent intent = new Intent(this, PDF.class);
        startActivity(intent);
    }
}