<template>
  <div id="app">
    <div id="nav">
      <router-link to="/test">Test-Common</router-link> |
      <router-link to="/RecyleListDemo">RecyleListDemo</router-link> |
    </div>
    <div class="main1">
      <router-view/>
    </div>
  </div>
</template>

<style lang="scss">
html,
body,
#app {
  width: 100%;
  height: 100%;
}
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  display: flex;
  flex-direction: column;
}
#nav {
  padding: 30px;
  height: 30px;
  a {
    font-weight: bold;
    color: #2c3e50;
    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
.main1 {
  flex: 1;
  display: flex;
}
</style>
