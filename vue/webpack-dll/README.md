
# 安装

``` 
 yarn install
```

# 运行
```
 npm run dev
```


# 说明
使用 webpack dll 方式打包

1. 添加 webpack.dll.config.js
2. 打包 dll 
```
webpack --config webpack.dll.config.js -p
```
3. webpack.config.js 中引用 dll
``` js
  //...
  plugins: [
    new webpack.DllReferencePlugin({
      context: __dirname,
      manifest: require('./dist/vendor-manifest.json')
    })
  ]
```
4. 在index.html 中引用对应dll