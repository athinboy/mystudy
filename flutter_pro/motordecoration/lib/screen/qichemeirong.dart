import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class Pro {
  final int id;
  final String proName;
  final List<String>? subPros;

  const Pro.newPro(this.id, this.proName, this.subPros);

  Pro(this.id, this.proName, this.subPros);
}

class QicheMeiRongScreen extends StatelessWidget {
  final List<Pro> pros;

  const QicheMeiRongScreen({Key? key, required this.pros}) : super(key: key);

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
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              for (int i = 0; i < pros.length; i++)
                ProjectWidget(
                  pro: pros[i],
                )
            ],
          ),
        ),
        floatingActionButton: FloatingActionButton(
          onPressed: () {},
          tooltip: 'Increment',
          child: Icon(Icons.add),
        ));
  }
}

class ProjectWidget extends StatefulWidget {
  final Pro pro;

  const ProjectWidget({Key? key, required this.pro}) : super(key: key);

  @override
  State createState() {
    return ProjectWidgetStatue(pro);
  }
}

class ProjectWidgetStatue extends State {
  ProjectWidgetStatue(this.pro);

  final Pro pro;
  bool selected = false;
  bool expanded = false;

  @override
  Widget build(BuildContext context) {
    Widget header = GestureDetector(
        onTap: () {
          setState(() {
            expanded = !expanded;
          });
        },
        child: Flex(direction: Axis.horizontal, children: [
          Checkbox(
              value: selected,
              onChanged: (bool? value) {
                setState(() {
                  selected = !selected;
                });
              }),
          Text(pro.proName)
        ]));

    Widget body = Container(
      padding: const EdgeInsets.fromLTRB(20.0, 10, 20.0, 20.0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          for (int i = 0; i < pro.subPros!.length; i++)
            Text(
              pro.subPros![i],
              style: TextStyle(letterSpacing: 1),
            )
        ],
      ),
    );

    Flex whole = Flex(
      direction: Axis.vertical,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: expanded
          ? [header, body]
          : [
              header,
            ],
    );

    return whole;
  }
}
