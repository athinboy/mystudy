class Login {
  String userId = "";
  String userName = "";

  static Login fromJson(dynamic jsonDecode) {
    Login login = Login();
    login.userId = jsonDecode["userId"];
    login.userName = jsonDecode["userName"];
    return login;
  }

  Map<String, dynamic> toJson() => {
        'userId': userId,
        'userName': userName,
      };
}
