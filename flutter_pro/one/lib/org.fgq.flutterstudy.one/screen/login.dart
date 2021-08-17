import 'package:flutter/material.dart';

class LogInScreent extends StatefulWidget {
  const LogInScreent({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() {
    // TODO: implement createState
    return LogInStatus();
  }
}

class LogInStatus extends State<LogInScreent> {
  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return Container(
      child: Center(
        child: Text("Hello"),
      ),
    );
  }

  @override
  void setState(VoidCallback fn) {
    super.setState(fn);
  }
}
