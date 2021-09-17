import 'package:flutter/cupertino.dart';

import 'package:flutter/material.dart';
import 'package:transparent_image/transparent_image.dart';

class HeroSamplePage extends StatelessWidget {
  const HeroSamplePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: GestureDetector(
        onTap: () {
          Navigator.push(context, MaterialPageRoute(builder: (content) {
            return const HeroSamplePage2();
          }));
        },
        child: Hero(
            tag: 'imageHero',
            child: FadeInImage.assetNetwork(
                //placeholder: kTransparentImage,
                placeholder: 'asset/gif/loading.gif',
                placeholderCacheWidth: 500,
                image:
                "https://t7.baidu.com/it/u=2291349828,4144427007&fm=193&f=GIF")),
      ),
    );
  }
}

class HeroSamplePage2 extends StatelessWidget {
  const HeroSamplePage2({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: GestureDetector(
        onTap: () {
          Navigator.pop(context);
        },
        child: Center(
          child: Hero(
              tag: "imageHero",
              child: FadeInImage.memoryNetwork(
                  placeholder: kTransparentImage,
                  image:
                  "https://t7.baidu.com/it/u=2291349828,4144427007&fm=193&f=GIF")),
        ),
      ),
    );
  }
}
