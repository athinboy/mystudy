package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;
import io.flutter.embedding.android.FlutterActivity;

import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


    }

    public void jumtToFlutter_Click(View view) {

        startActivity(
                FlutterActivity
                        .withNewEngine()
                        .initialRoute("/my_route")
                        .build(view.getContext())
        );
    }
}