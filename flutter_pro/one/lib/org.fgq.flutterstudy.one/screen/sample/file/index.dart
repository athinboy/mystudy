import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/file/imgpick.dart';

import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/sampleitem.dart';

List<SampleItem> fileSampleItems = [
  SampleItem("imagePick", "", "/sample/file/imagepick", ImagePickSamplePage())
];

List<int> s = [...fileSampleItems.map((e) => e.desc.length)];

class FileSampleIndexScreen extends StatelessWidget {
  const FileSampleIndexScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GridView.count(
      crossAxisCount: 4,
      children: [
        for (var i = 0; i < fileSampleItems.length; i++)
          new TextButton(
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => fileSampleItems[i].widget));
              },
              child: Text(fileSampleItems[i].text))
      ],
    );
  }
}
