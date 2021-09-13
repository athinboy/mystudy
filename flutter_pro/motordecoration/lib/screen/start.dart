import 'dart:async';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:motordecoration/model/logindata.dart';
import 'package:motordecoration/util/globaldata.dart';

class StartScreen extends StatelessWidget {
  const StartScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {


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
  Login? login = Login();

  skipToNext() {
    _time?.cancel();

    if (login == null || login!.userId.isEmpty) {
      Navigator.popAndPushNamed(context, "/login");
    } else {
      Navigator.popAndPushNamed(context, "/login");
    }
  }

  minusTime() {
    if (!this.mounted) {
      return;
    }
    setState(() {
      print(_lessSeconds);
      if (_lessSeconds == 10) {
        GlobalDataUtil.getLoginData().then((value) => login = value);
      }

      _lessSeconds -= 1;

      if (_lessSeconds == 0) {
        print(login?.toJson().toString());
        skipToNext();
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
          onPressed: () {
            skipToNext();
          },
          child: Text("($_lessSeconds)秒跳过")),
    );
  }
}
