# SQLServerCopyTable

SQL Server分表程序

一次能分很多表，比如你的表名是 mytable,你要分10张表,就会自动创建表名为mytable_0,mytable_1,mytable_2 ... mytable_9

并且会自动复制索引约束主键外建以及文件组等
