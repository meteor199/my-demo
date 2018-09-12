<template>
  <div class="home">
    <div class="main">
      <div>left:{{list.length}} right:{{listRight.length}}
        <button @click="handleStart">start</button>
      </div>
    </div>
    <recycle-list :items="list"
      class="left"
      :buffer="200"
      :item-height="30">
      <!-- For each item -->
      <template slot-scope="{ item, index, active }">
        <!-- Reactive dynamic height -->
        <div :class="{item:true,active:activeKey==item.key}"
          @click="handleClickLeft(item)">
          {{ item.value }}
        </div>
      </template>
    </recycle-list>

    <recycle-list :items="listRight"
      class="right"
      :buffer="200"
      :item-height="30">
      <!-- For each item -->
      <template slot-scope="{ item, index, active }">
        <!-- Reactive dynamic height -->
        <div :class="{item:true,active:activeRightKey==item.key}"
          @click="activeRightKey=item.key">
          <span>{{item.key}}</span>
          <span>{{item.value1}}</span>
          <span>{{item.value2}}</span>
          <span>{{item.value3}}</span>
          <span>{{item.value4}}</span>
          <span>{{item.value5}}</span>
          <span>{{item.value6}}</span>
        </div>
      </template>
    </recycle-list>
  </div>
</template>

<script lang="ts" src="./RecyleListDemo.ts">
</script>

<style lang="scss" scoped>

/deep/ .item-view:hover {
  background: #4fc08d;
  color: white;
}
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
    .item {
      padding-left: 20px;
      height: 30px;
    }
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
    .item {
      padding-left: 20px;
      height: 30px;
    }
    span {
      padding-left: 20px;
    }
  }
}
</style>

