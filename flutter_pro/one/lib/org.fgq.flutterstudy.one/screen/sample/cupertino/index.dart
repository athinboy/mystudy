import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/cupertino/all.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/sampleitem.dart';


List<SampleItem> cupertinoSampleItems = [
  SampleItem("all", "", "/sample/cupertino/all", CupertinoAllSamplePage())
];

List<int> s = [...cupertinoSampleItems.map((e) => e.desc.length)];

class CupertinoSampleIndexScreen extends StatelessWidget {
  const CupertinoSampleIndexScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GridView.count(
      crossAxisCount: 4,
      children: [
        for (var i = 0; i < cupertinoSampleItems.length; i++)
          new TextButton(
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => cupertinoSampleItems[i].widget));
              },
              child: Text(cupertinoSampleItems[i].text))
      ],
    );
  }
}
