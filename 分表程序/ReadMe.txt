1.先要在需要分表的库中执行sp_ScriptTable.sql脚本创建存储过程
2.然后打开GenerateScripts.exe
3.输入连接字符串
4.点击加载表
5.选择要分表的主表
6.点击开始分表

因为文件组不能删除了再创建，否则会出现错误，需要对数据库进行备份后才能继续
System.Data.SqlClient.SqlException (0x80131904): 只有执行了下一个 BACKUP LOG 操作后，才能重用文件。如果数据库正在参与某个可用性组，则只有在主可用性副本的截断 LSN 已越过该文件的删除 LSN 且后续 BACKUP LOG 操作已完成后，才能重用删除的文件。

参考下面文章
https://bbs.csdn.net/topics/260080534