import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/navigation/hero.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/navigation/passargument.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/sampleitem.dart';
import 'package:transparent_image/transparent_image.dart';

List<SampleItem> navigationSampleItems = [
  SampleItem("hero", "", "/sample/navigation/hero", HeroSamplePage()),
  SampleItem("导航传参", "", "/sample/navigation/data", NavigationDataSamplePage())
];

List<int> s = [...navigationSampleItems.map((e) => e.desc.length)];

class NavigationSampleIndexScreen extends StatelessWidget {
  const NavigationSampleIndexScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GridView.count(
      crossAxisCount: 4,
      children: [
        for (var i = 0; i < navigationSampleItems.length; i++)
          new TextButton(
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => navigationSampleItems[i].widget));
              },
              child: Text(navigationSampleItems[i].text))
      ],
    );
  }
}
