import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/index.dart';

class SampleApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Provider Demo',
      initialRoute: '/index',
      routes: {'/index': (context) => SampleIndexScreen()},
    );
  }
}
