import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/internet/httpget.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/sampleitem.dart';

List<SampleItem> internetSampleItems = [
  SampleItem("http_get", "", "/sample/http/get", HttpGetPage())
];

List<int> s = [...internetSampleItems.map((e) => e.desc.length)];

class InternetSampleIndexScreen extends StatelessWidget {
  const InternetSampleIndexScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GridView.count(
      crossAxisCount: 4,
      children: [
        for (var i = 0; i < internetSampleItems.length; i++)
          new TextButton(
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => internetSampleItems[i].widget));
              },
              child: Text(internetSampleItems[i].text))
      ],
    );
  }
}
