<template>
  <div >
   Local Lazy!
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component'
import Vue from 'vue'

@Component({
  props: {
  },
  components: {

  },
})
export default class LocalLazy extends Vue {


  //所有的 methods,computed,data,filter,都是直接写在 此类中
  destroyed() {
    console.log("destoryed");
  }
}
</script>

<style>

</style>
