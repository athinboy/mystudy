import 'package:flutter/material.dart';
import 'package:motordecoration/screen/login.dart';
import 'package:motordecoration/screen/start.dart';

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    // Using MultiProvider is convenient when providing multiple objects.

    return MaterialApp(
      title: 'Provider Demo',
      initialRoute: '/',
      routes: {
        '/': (context) => StartScreen(),
        '/login': (context) => LogInScreen()
      },
    );
  }
}
