import Vue from 'vue'
import App from './App.vue'

declare var require : (filename,resolve)=>any;

Vue.component('global-lazy', (resolve) => require(['./components/GlobalLazy.vue'], resolve))
Vue.component('global-lazy-es6', () => import("./components/GlobalLazyEs6.vue") as any)



new Vue({
  el: '#app',
  render: h => h(App)
})
