import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/hardware/bluetooch.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/hardware/geolocator.dart';

import '../sampleitem.dart';

List<SampleItem> hardwareSampleItems = [
  SampleItem(
      "蓝牙", "", "/sample/hardware/bluetooch", HardWareBlueToochSamplePage()),
  SampleItem(
      "定位", "", "/sample/hardware/geolocator", HardWareGeolocatorSamplePage())
];

List<int> s = [...hardwareSampleItems.map((e) => e.desc.length)];

class HardwareSampleIndexScreen extends StatelessWidget {
  const HardwareSampleIndexScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GridView.count(
      crossAxisCount: 4,
      children: [
        for (var i = 0; i < hardwareSampleItems.length; i++)
          new TextButton(
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => hardwareSampleItems[i].widget));
              },
              child: Text(hardwareSampleItems[i].text))
      ],
    );
  }
}
