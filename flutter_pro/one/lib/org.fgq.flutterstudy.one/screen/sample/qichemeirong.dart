import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class Pro {
  int id;
  String proName;
  List<Pro> subPros;

  Pro.NewPro(this.id,this.proName,this.subPros);
}

class QicheMeiRongScreen extends StatelessWidget {
  const QicheMeiRongScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Demo'),
        ),
        body: Container(
          width: 800,
          height: 1200,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [for (int i = 0; i < 4; i++) ProjectWidget()],
          ),
        ));
  }
}

class ProjectWidget extends StatefulWidget {
  const ProjectWidget({Key? key}) : super(key: key);

  @override
  State createState() {
    return ProjectWidgetStatue();
  }
}

class ProjectWidgetStatue extends State {
  @override
  Widget build(BuildContext context) {
    Widget header = GestureDetector(
        onTap: () {
          setState(() {
            print("fwewr");
          });
        },
        child: Flex(direction: Axis.horizontal, children: [
          Checkbox(
              value: true,
              onChanged: (bool? value) {
                print(value.toString());
              }),
          Text("Hello")
        ]));

    Widget body = Container(
      child: Column(
        children: [for (int i = 0; i < 5; i++) Text(i.toString())],
      ),
    );

    Flex whole = Flex(
      direction: Axis.vertical,
      children: [header, body],
    );

    return whole;
  }
}
