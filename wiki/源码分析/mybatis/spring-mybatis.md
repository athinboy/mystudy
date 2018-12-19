
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

2. org.mybatis.spring.mapper.MapperFactoryBean 此类需要SqlSessionFactoryBean。继承自SqlSessionDaoSupport，SqlSessionDaoSupport 类引用 SqlSessionTemplate 类。

3. SqlSessionFactoryBean 引用 SqlSessionFactoryBuilder 。SqlSessionFactoryBuilder 返回 DefaultSqlSessionFactory 。DefaultSqlSessionFactory返回 DefaultSqlSession 。

4. 飞。
