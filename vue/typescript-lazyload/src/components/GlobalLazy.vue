<template>
  <div >
   Global Lazy!
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component'
import Vue from 'vue'
//需使用类装载器加载store,components,props


@Component({
  props: {
  },
  components: {

  },
})
export default class GlobalLazy extends Vue {
  data() {
    return {
      isShowGlobalComponent: false,
      isShowLocalComponent: false,
    }
  }


  //所有的 methods,computed,data,filter,都是直接写在 此类中
  destroyed() {
    console.log("destoryed");
  }
}
</script>

<style>

</style>
