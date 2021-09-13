package com.example.myapplication;//package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;
import io.flutter.embedding.android.FlutterActivity;
import io.flutter.embedding.engine.FlutterEngine;
import io.flutter.embedding.engine.FlutterEngineCache;
import io.flutter.embedding.engine.dart.DartExecutor;

import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    public FlutterEngine flutterEngine;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Instantiate a FlutterEngine.
        flutterEngine = new FlutterEngine(this);

        // Start executing Dart code to pre-warm the FlutterEngine.
        flutterEngine.getDartExecutor().executeDartEntrypoint(
                DartExecutor.DartEntrypoint.createDefault());
        FlutterEngineCache
                .getInstance()
                .put("my_engine_id", flutterEngine);

    }

    public void jumtToFlutter_Click(View view) {

        startActivity(
                FlutterActivity
                        .withCachedEngine("my_engine_id")
                        .build(view.getContext())
                        //.withNewEngine()
//                        .initialRoute("/my_route")
//                        .build(view.getContext())
        );
    }
}