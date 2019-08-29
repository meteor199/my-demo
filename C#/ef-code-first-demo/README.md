
ef 基于 现有数据库 的code first 的示例

[代码优先的现有数据库](https://docs.microsoft.com/zh-cn/ef/ef6/modeling/code-first/workflows/existing-database)

设置数据库连接
```
    public BloggingContext(string s)
    {
        this.Database.Connection.ConnectionString = s;
    }

```