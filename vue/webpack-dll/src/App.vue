<template>
  <div id="app">
    <img src="./assets/logo.png">
    <div>Hello Vue!</div>
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component'
import Vue from 'vue'
import $ from "jquery"
//需使用类装载器加载store,components,props


@Component({
  props: {
  },
  components: {

  },
})
export default class App extends Vue {
  //所有的 methods,computed,data,filter,都是直接写在 此类中
  destroyed() {
    console.log("destoryed");
  }
  async created() {
    $(() => {
      console.log("aa")
    })

  }
}
</script>

<style scoped>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
