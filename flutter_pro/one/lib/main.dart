import 'package:flutter/material.dart';

import 'org.fgq.flutterstudy.one/screen/myapp.dart';
import 'org.fgq.flutterstudy.one/screen/sample/qichemeirong.dart';
import 'org.fgq.flutterstudy.one/screen/start.dart';

// void main() {
//   runApp(MyApp());
// }

void main() {
  runApp(
    const MaterialApp(
      title: 'Returning Data',
      home: QicheMeiRongScreen(
        pros: [
          Pro.newPro(1, "二手车翻新施工&车检核单", [
            "洗车",
            "发动机舱翻新镀膜",
            "发动机舱镀膜",
            "漆面镀膜",
            "内部清洗",
            "车内除臭去味",
            "大灯镀膜",
            "玻璃镀膜",
            "轮胎清洗"
          ]),
          Pro.newPro(2, "家具整齐家具整齐家具整齐家具整齐家具整齐家具整齐", [
            "暂未发现新增本土病例与国内其他地区疫情有关联",
            "塔利班二把手时隔20年重返阿富汗:当地民众夹道欢迎",
            "俄媒：塔利班武装人员向阿富汗抗议民众开火，致2死12伤"
          ])
        ],
      ),
      //home: MyApp(),
      routes: {},
    ),
  );
}
