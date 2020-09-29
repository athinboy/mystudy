
##  基本点

spring-mybatis的主要任务是把spring中对数据库的操作引导到mybatis原有的功能上去。

### 1、支持autowired 等注入Mapper。

### 2、支持配置mybatis。

1. 支持autowired 等注入Mapper 接口类。

* org.mybatis.spring.mapper.MapperFactoryBean 配置哪个接口需要支持spring声明式构造。
* org.mybatis.spring.mapper.MapperScannerConfigurer 配置哪些包下的类需要支持spring的声明式构造。

2. 支持配置mybatis。

* org.mybatis.spring.SqlSessionFactoryBean ：配置mybatis的数据源、xml文件、配置文件等等。

### 类介绍

1. org.mybatis.spring.mapper.MapperScannerConfigurer 此类中调用 ClassPathMapperScanner 类。ClassPathMapperScanner 类中 mapperFactoryBean默认为 MapperFactoryBean 。

2. org.mybatis.spring.mapper.MapperFactoryBean 此类需要 SqlSessionFactoryBean 。 SqlSessionFactoryBean 继承自SqlSessionDaoSupport，SqlSessionDaoSupport 类引用 SqlSessionTemplate 类。

3. SqlSessionFactoryBean 引用 SqlSessionFactoryBuilder 。SqlSessionFactoryBuilder 返回 DefaultSqlSessionFactory 。DefaultSqlSessionFactory返回 DefaultSqlSession 。

4. SqlSessionTemplate 类包含 SqlSession 类的代理类， 代理类中获取正确的DefaultSqlSession，  将对SqlSession 的调用转换为对 DefaultSqlSession 的调用。
 



 ```yuml
 // {type:class}
// {direction:topDown}
[note:这是正式的mybats-spring源码分析{bg:write}]
 [SqlSessionTemplate]-[note: fwe]
 
 [DefaultSqlSessionFactory]-[note:返回DefaultSqlSession]
[ClassPathMapperScanner]-[note:见代码1 修改mapper类的定义]



 [SqlSession]^[SqlSessionTemplate]
 [SqlSessionTemplate]-.->[SqlSessionInterceptor]
 [SqlSessionTemplate]-.->[SqlSessionFactoryBean]
[SqlSessionFactoryBean]-.->[DefaultSqlSessionFactory]
[SqlSessionInterceptor]-.->[DefaultSqlSession]
 [SqlSession]^[DefaultSqlSession]
 [SqlSession]^[SqlSessionManager]

 [DaoSupport]^[SqlSessionDaoSupport]
 [SqlSessionDaoSupport]^[MapperFactoryBean]
 [SqlSessionDaoSupport]-.->[SqlSessionTemplate]
[MapperFactoryBean]-.->[SqlSessionFactoryBean]

 [FactoryBean<SqlSessionFactory>]^[SqlSessionFactoryBean]
 [SqlSessionFactoryBuilder]
 [SqlSessionFactoryBean]-.->[SqlSessionFactoryBuilder]
 [SqlSessionFactoryBuilder]-.->[DefaultSqlSessionFactory]
 [DefaultSqlSessionFactory]-.->[DefaultSqlSession]
 [spring.xml]++-[SqlSessionFactoryBean]
[spring.xml]++-[MapperFactoryBean]
[spring.xml]++-[MapperScannerConfigurer]
[spring.xml]++-[SqlSessionTemplate]

[MapperScannerConfigurer]-.-> [ClassPathMapperScanner]

[ClassPathMapperScanner]-.->[MapperFactoryBean]
 ```


 



 ```yuml
// {direction:topDown}
// {type:class}
[note:spring中允许autowire mapper接口 ]
[MapperFactoryBean]-[note:getObject()方法变相调用]
[MapperProxyFactory]
[ClassPathMapperScanner]-[note:见 代码1：]
[MapperScannerConfigurer]-.-> [ClassPathMapperScanner]
[ClassPathMapperScanner]-.->[MapperFactoryBean]
 ```

 ```yuml
 // {type:sequence}
 

[Spring]>[MapperScannerConfigurer]
 [MapperScannerConfigurer] postProcessBeanDefinitionRegistry() >[ClassPathMapperScanner]
 [ClassPathMapperScanner]scan().>[ClassPathMapperScanner]
[ClassPathMapperScanner]processBeanDefinitions() .>[ClassPathMapperScanner]
[ClassPathMapperScanner].>[MapperScannerConfigurer]
[ MapperScannerConfigurer]>[Spring]
[Spring]getObject()>[MapperFactoryBean]
[MapperFactoryBean]getSqlSession()>[SqlSession]
[SqlSession]getConfiguration()>[SqlSession]
[SqlSession]getMapper()>[Configuration]


[Configuration]获取缓存的Mapper代理>[MapperRegistry]
[MapperRegistry]>[MapperProxyFactory]
[MapperProxyFactory]>[MapperRegistry]

[MapperRegistry]Mapper的代理>[Configuration]

[Configuration].>[SqlSession]
[SqlSession].>[MapperFactoryBean]
[MapperFactoryBean].>[Spring]



 ```



代码1：
``` 
processBeanDefinitions:
definition.getPropertyValues().add("mapperInterface", definition.getBeanClassName()); definition.setBeanClass(this.mapperFactoryBean.getClass());
```

 


