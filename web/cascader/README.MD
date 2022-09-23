# 测试说明

- 编译ts
  
``` sql
cd src
tsc
browserify ./js/cascader.js -o ../dist/cascader.js // win cmd: tsc &&  browserify ./js/cascader.js -o ../dist/cascader.js

```

- dom id层级结构

``` sql
jqcascader_iname_menu
        |
        |-------jqcascader_iname_1   --> jqcascader_iname_1-menu
        |           |
        |           |--jqcascader_iname_1_1--> jqcascader_iname_1_1-menu
        |           |--jqcascader_iname_1_2--> jqcascader_iname_1_2-menu
        |           |--jqcascader_iname_1_3--> jqcascader_iname_1_3-menu
        |                              |
        |                              |--jqcascader_iname_1_3_1  -->  jqcascader_iname_1_3_1-menu
        |                              |--jqcascader_iname_1_3_2  -->  jqcascader_iname_1_3_2-menu
        |
        |-------jqcascader_iname_2   --> jqcascader_iname_2-menu
        |           |
        |           |--jqcascader_iname_2_1--> jqcascader_iname_2_1-menu
        |           |--jqcascader_iname_2_2--> jqcascader_iname_2_2-menu
        |           |--jqcascader_iname_2_3--> jqcascader_iname_2_3-menu
        |                              |
        |                              |--jqcascader_iname_2_3_1  -->  jqcascader_iname_2_3_1-menu
        |                              |--jqcascader_iname_2_3_2  -->  jqcascader_iname_2_3_2-menu

                    
```
