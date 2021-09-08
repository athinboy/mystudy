import 'package:flutter/material.dart';

class LogInScreen extends StatelessWidget {
  LogInScreen({Key? key}) : super(key: key);

  String? userId;
  String? psw;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Center(
      child: Container(
        padding: const EdgeInsets.all(80.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            TextFormField(
              decoration: const InputDecoration(hintText: "用户名"),
              onChanged: (String value) => {userId = value},
            ),
            TextFormField(
              decoration: const InputDecoration(hintText: "密码"),
              obscureText: true,
              onChanged: (String value) => {psw = value},
            ),
            const SizedBox(
              height: 24,
            ),
            ElevatedButton(
              child: const Text('ENTER'),
              onPressed: () {
                print(psw ?? "" + (userId ?? ""));
              },
              style: ElevatedButton.styleFrom(
                primary: Colors.yellow,
              ),
            )
          ],
        ),
      ),
    ));
  }
}
