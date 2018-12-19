###
通过SqlSessionFactory获取SqlSession。
SqlSession具有子类：

* DefaultSqlSession：最常用
* SqlSessionManager: 很少使用
* SqlSessionTemplate：spring-mybatis中使用

##  DefaultSqlSession

* DefaultSqlSession中对数据库的操作都要用到Executorl类。
对映射Mapper接口和Mapper XML文件的分析结果存储在org.apache.ibatis.session.Configuration的mappedStatements中。其中：类+方法名为key。MappedStatement为value。

* Executorl类通过操作MappedStatement来执行数据库操作。

* ji。
