<template>
  <div id="app" style="width:1000;heigit:700">
    <button @click="handleExport">导出</button>
    <VueDragResize :isActive="true" :w="1000" :h="600">
      <FillTable
        ref="table"
        style="width:100%;height:100%"
        :columns="columns1"
        :data="data1"
        :fill="true"
        @on-row-dblclick="handleDblClick"	
      >
        <template #name="{ row }">
          <strong>{{ row.name }}--ddd</strong>
        </template>
        <template #address="{ row }">
          <strong>{{ getAddress(row) }}</strong>
        </template>
      </FillTable>
    </VueDragResize>
  </div>
</template>

<script lang="ts" src="./App.ts">
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
