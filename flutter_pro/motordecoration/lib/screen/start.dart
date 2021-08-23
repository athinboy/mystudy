import 'dart:async';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class StartScreen extends StatelessWidget {
  const StartScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Timer.periodic(Duration(seconds: 10), (timer) {
      timer.cancel();
      //Navigator.pushReplacementNamed(context, "/login");
    });

    Image image = Image(
      image: AssetImage('asset/img/minibear.jpg'),
      fit: BoxFit.fill,
    );

    Scaffold scaffold = Scaffold(
        body: Stack(
      children: [
        Center(child: image),
        Center(child: Text("hello2")),
        Row(mainAxisAlignment: MainAxisAlignment.end, children: [SkipWidget()])
      ],
    ));

    return scaffold;
  }
}

class SkipWidget extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return SkipState();
  }
}

class SkipState extends State {
  int _lessSeconds = 10;
  Timer? _time;

  minusTime() {
    setState(() {
      _lessSeconds -= 1;
      if (_lessSeconds == 0) {
        Navigator.popAndPushNamed(context, "/login");
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    if (_time == null) {
      _time = Timer.periodic(Duration(seconds: 1), (timer) {
        minusTime();
      });
    }

    return Container(
      width: 100,
      height: 50,
      margin: EdgeInsets.fromLTRB(0, 20, 50, 0),
      child: TextButton(
          onPressed: () => {Navigator.popAndPushNamed(context, "/login")},
          child: Text("($_lessSeconds)秒跳过")),
    );
  }
}
