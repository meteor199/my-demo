<template>
  <div class="home">
    <div class="main">
      <div>left:{{list.length}} right:{{listRight.length}}
        <button @click="handleStart">start</button>
      </div>
    </div>
    <div class="left">
      <ul>
        <li v-for="item in list"
          :key="item.key"
          @click="handleClickLeft(item)"
          :class="{active:activeKey==item.key}">{{item.value}}</li>
      </ul>
    </div>
    <div class="right">
      <ul>
        <li v-for="item in listRight"
          :key="item.key"
          @click="activeRightKey=item.key"
          :class="{active:activeRightKey==item.key}">
          <span>{{item.key}}</span>
          <span>{{item.value1}}</span>
          <span>{{item.value2}}</span>
          <span>{{item.value3}}</span>
          <span>{{item.value4}}</span>
          <span>{{item.value5}}</span>
          <span>{{item.value6}}</span>
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts" src="./Test.ts">
</script>

<style lang="scss" scoped>
.home {
  flex: 1;
  position: relative;
  li:hover {
    background: gray;
  }
  text-align: left;
  .main {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    height: 50px;
  }
  .left {
    position: absolute;
    top: 50px;
    left: 0;
    bottom: 0;
    width: 300px;
    overflow-y: scroll;
    border: 1px solid red;
    .active {
      background: blue;
    }
  }
  .right {
    position: absolute;
    top: 50px;
    left: 300px;
    right: 0;
    bottom: 0;
    overflow-y: scroll;
    border: 1px solid blue;
    .active {
      background: blue;
    }
    span {
      padding-left: 20px;
    }
  }
}
</style>

