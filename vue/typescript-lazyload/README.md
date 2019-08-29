
使用 typescript 时, vue 的几种组件懒加载方法
# 安装

``` 
 yarn install
```

# 运行

``` shell

 npm run dev

```

# [详细说明](http://www.jianshu.com/p/1a3929de9f8f)

# 设置
使用懒加载，需做如下设置:
### tsconfig.json
使用 `import(`.\file.vue`)` 需在`tsconfig.json`中将 `module` 设置为 `esnext`


### webpack.config.js

# 使用动态加载的几种方法

### 全局组件

``` typescript

Vue.component('AsyncCmp', () => import('./AsyncCmp'))

```

### 局部组件
``` typescript
new Vue({
  // ...
  components: {
    'AsyncCmp': () => import('./AsyncCmp')
  }
})
```
``` typescript 

components: {
  UiAlert: () => import('keen-ui').then(({ UiAlert }) => UiAlert)
}

```

### 路由

``` typescript
// Instead of: import Login from './login'
const Login = () => import('./login')

new VueRouter({
  routes: [
    { path: '/login', component: Login }
  ]
})

```
# 博客
