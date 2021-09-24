import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/cupertino/index.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/file/index.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/hardware/index.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/internet/index.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/navigation/index.dart';

class SampleIndexScreen extends StatelessWidget {
  SampleIndexScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return DefaultTabController(
        length: 5,
        child: Scaffold(
            appBar: AppBar(
              title: const Text("示例"),
              bottom: const TabBar(
                tabs: [
                  Tab(
                    text: "网络",
                  ),
                  Tab(
                    text: "导航",
                  ),
                  Tab(text: "文件"),
                  Tab(text: "Cupertino"),
                  Tab(
                    text: "硬件",
                  )
                ],
                isScrollable: true,
              ),
            ),
            body: const SafeArea(
                bottom: false,
                child: TabBarView(children: [
                  InternetSampleIndexScreen(),
                  NavigationSampleIndexScreen(),
                  FileSampleIndexScreen(),
                  CupertinoSampleIndexScreen(),
                  HardwareSampleIndexScreen()
                ]))));
  }
}
