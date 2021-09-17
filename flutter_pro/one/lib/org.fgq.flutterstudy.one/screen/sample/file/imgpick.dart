import 'dart:io';

import 'package:flutter/cupertino.dart';

import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';

class ImagePickSamplePage extends StatefulWidget {
  const ImagePickSamplePage({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() {
    return ImagePickSampleState();
  }
}

class ImagePickSampleState extends State {
  List<Widget> columnChildren = <Widget>[];
  XFile? image;
  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    columnChildren.clear();

    TextButton textButton = TextButton(
      child: Text("选择图片"),
      onPressed: () async {
        image = null;
        ImagePicker _picker = ImagePicker();
        image = await _picker.pickImage(source: ImageSource.gallery);

        setState(() {});
        print(image!.path);
        didChangeDependencies();
      },
    );



    columnChildren.add(Text(
      "请选择图片",
      style: TextStyle(),
    ));
    columnChildren.add(textButton);

    textButton = TextButton(
      child: Text("拍照"),
      onPressed: () async {
        image = null;
        ImagePicker _picker = ImagePicker();
        image = await _picker.pickImage(source: ImageSource.camera);

        setState(() {});
        print(image!.path);
        didChangeDependencies();
      },
    );
    columnChildren.add(Text(
      "请拍照",
      style: TextStyle(),
    ));
    columnChildren.add(textButton);




    if (image != null) {
      columnChildren.add(Image.file(
        File(image!.path),
        scale: 0.5,
        width: 400,
        height: 300,
      ));
      columnChildren.add(Text("图片路径:${image!.path}",
          style: TextStyle(
              fontSize: 15, decorationStyle: TextDecorationStyle.solid)));
    }
    return Scaffold(
        body: Center(
            child: Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: columnChildren,
    )));
  }
}
