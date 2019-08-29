一个扩展的 winform 的treeview控件，fork 自[Advanced TreeView for .NET](https://www.codeproject.com/Articles/14741/WebControls/#_comments)

主要添加一个 ProcessBar控件

# FolderBrowser 添加列的方式：
1. 在属性中的集合的对话框中添加 ProcessBar类型的列。
2. 在`FolderBrowser.Designer.cs` 中添加新的列`treeColumn4`。
3. 修改`treeColumn4`的属性并添加到`treeView`(参照`treeColumn3`修改)。
4. 在`BaseItem`数据模型中添加列