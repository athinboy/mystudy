import 'package:flutter/cupertino.dart';

import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';

class ImagePickSamplePage extends StatelessWidget {
  const ImagePickSamplePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: TextButton(
        child: Text("选择图片"),
        onPressed: () async {
          ImagePicker _picker = ImagePicker();
          final XFile? image =
              await _picker.pickImage(source: ImageSource.gallery);
          print(image!.path);
        },
      ),
    );
  }
}
