# 总结

输出：
```
Sgin:0  count:8
Sgin:1  count:8
Sgin:2  count:8
Sgin:3  count:8
Sgin:4  count:8
```
在channel的autoAck为true时，每个客户端拿到的消息数量是一样的。因为客户端瞬间接受了等数量（8）的信息。