import Vue from "vue";
import App from "./App.vue";

Vue.config.productionTip = false;

import VueDragResize from "vue-drag-resize";


import iView from 'iview';
import 'iview/dist/styles/iview.css';
Vue.use(iView);

Vue.component("VueDragResize", VueDragResize);
new Vue({
  render: h => h(App)
}).$mount("#app");
