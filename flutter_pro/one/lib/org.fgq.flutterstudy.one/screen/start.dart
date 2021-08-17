import 'dart:async';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/login.dart';

import 'newhome.dart';

class StartScreen extends StatelessWidget {
  const StartScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    print('StartScreen.build');
    Timer timer = Timer.periodic(Duration(seconds: 10), (timer) {
      timer.cancel();
      Navigator.push(context,
          MaterialPageRoute(builder: (context) => const LogInScreent()));
    });

    Image image = Image(image: AssetImage('asset/img/minibear.jpg'));

    Scaffold scaffold = Scaffold(
        body: Stack(
      children: [
        Center(child: Text("hello2")),
        BottomAppBar(
          child: Text("广告"),
        )
      ],
    ));

    return scaffold;
  }
}
