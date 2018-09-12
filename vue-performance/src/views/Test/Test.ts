import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src

@Component({
    components: {
        HelloWorld,
    },
})
export default class Home extends Vue {

    public list: any[] = [];
    public activeKey = 1;
    public activeRightKey = 1;
    public listRight: any[] = [];
    public mounted() {
        //
    }
    public handleStart() {
        console.log('start push');
        for (let i = 0; i < 5000; i++) {
            this.list.push({
                key: i,
                value: i + '',
            });
        }
        console.log('push end');

        setInterval(() => {
            const index = parseInt((Math.random() * this.list.length) + '', 0);
            if (this.list[index].value.length > 10) {
                this.list[index].value = this.list[index].value.substring(0, 5);
            } else {
                this.list[index].value += 'a';
            }
        }, 1);
    }
    public handleClickLeft(item: any) {
        this.activeKey = item.key;
        this.$nextTick(() => {
            this.listRight = [];
            for (let i = 0; i < 1000; i++) {
                this.listRight.push({
                    key: item.key + '' + i,
                    value: Math.random(),
                    value2: Math.random(),
                    value3: Math.random(),
                    value4: Math.random(),
                    value5: Math.random(),
                    value6: Math.random(),
                });
            }
        });
    }
}
