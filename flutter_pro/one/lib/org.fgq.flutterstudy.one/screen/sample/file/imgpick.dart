import 'package:flutter/cupertino.dart';
import 'package:http/http.dart' as http;

import 'package:flutter/material.dart';

class ImagePickSamplePage extends StatelessWidget {
  const ImagePickSamplePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: TextButton(
        child: Text("选择图片"),
        onPressed:  () async {

        },
      ),
    );
  }
}
