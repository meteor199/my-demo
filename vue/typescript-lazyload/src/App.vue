<template>
  <div id="app">
    <img src="./assets/logo.png">
    <div>Hello Vue!</div>

    <button @click="setReversal('isShowGlobalComponentEs6')">global-es6</button>
    <global-lazy-es6 v-if='isShowGlobalComponentEs6' />

    <button @click="setReversal('isShowGlobalComponent')">global-es6</button>
    <global-lazy v-if='isShowGlobalComponent' />

    <button @click="setReversal('isShowLocalComponent')">local</button>
    <local-lazy v-if='isShowLocalComponent' />

    <router-link to="/RouterLazy">RouterLazy</router-link>
    <router-link to="/">Go to Home</router-link>
    <router-view></router-view>
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component'
import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter);

@Component({
  router: new VueRouter({
    routes: [
      { path: '/RouterLazy', component:(()=> import("./components/RouterLazy.vue")) as any },
    ]
  }),
  components: {
    'local-lazy': () => import("./components/LocalLazy.vue") as any
  },
  data() {
    return {
      isShowGlobalComponentEs6: false,
      isShowGlobalComponent: false,
      isShowLocalComponent: false,
    }
  },
  methods: {
    setReversal(name) {
      this[name] = !this[name];
    }
  }

})
export default class App extends Vue {

  //所有的 methods,computed,data,filter,都是直接写在 此类中

}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
