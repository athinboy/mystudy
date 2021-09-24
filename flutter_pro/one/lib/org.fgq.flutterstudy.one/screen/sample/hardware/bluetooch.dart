import 'package:flutter/material.dart';
import 'package:flutter_blue/flutter_blue.dart';

class HardWareBlueToochSamplePage extends StatelessWidget {
  const HardWareBlueToochSamplePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    FlutterBlue flutterBlue = FlutterBlue.instance;

    return Center(
      child: TextButton(
        child: Text("百度"),
        onPressed: () {},
      ),
    );
  }
}
