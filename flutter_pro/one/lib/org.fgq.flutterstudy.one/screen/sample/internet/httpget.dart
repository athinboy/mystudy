import 'package:flutter/cupertino.dart';
import 'package:http/http.dart' as http;

import 'package:flutter/material.dart';

class HttpGetPage extends StatelessWidget {
  const HttpGetPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: TextButton(
        child: Text("百度"),
        onPressed: () {
          Future<http.Response> future =
              http.get(Uri.parse('http://www.baidu.com'));
          future
              .then((value) => print(value.body))
              .onError((error, stackTrace) => null);
        },
      ),
    );
  }
}
