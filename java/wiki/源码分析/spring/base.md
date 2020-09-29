
* BeanFactory
* BeanPostProcessor
* InstantiationAwareBeanPostProcessor
* BeanNameAware
* BeanFactoryAware
* FactoryBean
* BeanPostProcessor
* InitializingBean
* ContextLoaderListener
* WebApplicationContextUtils
* ServletContext : Defines a set of methods that a servlet uses to communicate with its servlet container, for example, to get the MIME type of a file, dispatch requests, or write to a log file.
There is one context per "web application" per Java Virtual Machine. (A "web application" is a collection of servlets and content installed under a specific subset of the server's URL namespace such as /catalog and possibly installed via a .war file.)




```yuml
// {type:class}
// {direction:topDown}
[BeanFactory]^[ListableBeanFactory]
[ListableBeanFactory]^[ApplicationContext]

[BeanFactory]^[HierarchicalBeanFactory]
[HierarchicalBeanFactory]^[ApplicationContext]

[ApplicationContext]^[WebApplicationContext]


```


```
Class         [Customer]
Directional   [Customer]->[Order]
Bidirectional [Customer]<->[Order]
Aggregation   [Customer]+-[Order] or [Customer]<>-[Order]
Composition   [Customer]++-[Order]
Inheritance   [Customer]^[Cool Customer], [Customer]^[Uncool Customer]
Dependencies  [Customer]uses-.->[PaymentStrategy]
Cardinality   [Customer]<1-1..2>[Address]
Labels        [Person]customer-billingAddress[Address]
Notes         [Address]-[note: Value Object]
Full Class    [Customer|Forename;Surname;Email|Save()]
Color splash  [Customer{bg:orange}]<>1->*[Order{bg:green}]
```