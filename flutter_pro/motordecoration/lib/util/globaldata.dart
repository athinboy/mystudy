import 'dart:async';
import 'dart:convert';

import 'package:motordecoration/model/logindata.dart';

import 'package:shared_preferences/shared_preferences.dart';

class GlobalDataUtil {
  static Future<Login?> getLoginData() async {
    var prefs = await SharedPreferences.getInstance();
    print(prefs.getString("key"));
    String? loginstr = prefs.getString("login");
    Login? login;
    if (loginstr != null && loginstr.isNotEmpty) {
      login = Login.fromJson(jsonDecode(loginstr));
    }

    return Future.value(login);
  }
}
