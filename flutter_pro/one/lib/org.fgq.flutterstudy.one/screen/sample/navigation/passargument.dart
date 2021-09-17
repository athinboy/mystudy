import 'package:flutter/material.dart';

class NavigationDataArgument {
  String? data;
  NavigationDataArgument.of(String data) {
    this.data = data;
  }
}

class NavigationDataResult {
  String? data;
  NavigationDataResult.of(String data) {
    this.data = data;
  }
}

class NavigationDataSamplePage extends StatelessWidget {
  NavigationDataArgument? argument;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
          child: ElevatedButton(
        child: Text("turn to next screen"),
        onPressed: () async {
          final result = await Navigator.push(
              context,
              MaterialPageRoute(
                  settings: RouteSettings(
                      arguments: NavigationDataArgument.of(
                          DateTime.now().toIso8601String())),
                  builder: (context) {
                    return NavigationDataSamplePage2();
                  }));
          if (result != null) {
            ScaffoldMessenger.of(context)
              ..removeCurrentSnackBar()
              ..showSnackBar(SnackBar(content: Text('$result')));
          }
        },
      )),
    );
  }
}

class NavigationDataSamplePage2 extends StatelessWidget {
  NavigationDataArgument? argument;
  @override
  Widget build(BuildContext context) {
    argument =
        ModalRoute.of(context)?.settings.arguments as NavigationDataArgument;

    return Scaffold(
        body: Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text("get Argument:" +
              (argument == null ? "" : argument!.data.toString())),
          ElevatedButton(
            child: Text("turn to last screen"),
            onPressed: () {
              Navigator.pop(
                  context, "result is :" + (DateTime.now().toIso8601String()));
            },
          )
        ],
      ),
    ));
  }
}
