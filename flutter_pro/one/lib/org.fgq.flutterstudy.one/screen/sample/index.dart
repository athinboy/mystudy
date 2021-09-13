import 'package:flutter/material.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/file/index.dart';
import 'package:flutter_pro/org.fgq.flutterstudy.one/screen/sample/internet/index.dart';

import 'internet/httpget.dart';

class SampleIndexScreen extends StatelessWidget {
  SampleIndexScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return DefaultTabController(
        length: 3,
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
                  Tab(text: "文件")
                ],
                isScrollable: true,
              ),
            ),
            body: const SafeArea(
                bottom: false,
                child: TabBarView(children: [
                  InternetSampleIndexScreen(),
                  HttpGetPage(),
                  FileSampleIndexScreen()
                ]))));
  }
}
