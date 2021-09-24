import 'package:flutter/material.dart';
import 'package:geolocator/geolocator.dart';

class HardWareGeolocatorSamplePage extends StatelessWidget {
  const HardWareGeolocatorSamplePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: TextButton(
        child: Text("定位"),
        onPressed: () async {
          bool serviceEnabled;
          LocationPermission permission = await Geolocator.checkPermission();
          serviceEnabled = await Geolocator.isLocationServiceEnabled();
          if (!serviceEnabled) {
            return Future.error('Location services are disabled.');
          }

          Position position = await Geolocator.getCurrentPosition();
          print(position.toJson());
        },
      ),
    );
  }
}
