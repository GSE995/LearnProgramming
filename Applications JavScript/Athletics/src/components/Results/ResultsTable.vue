<template>
<div>
    <button class="btn btn-default" v-for="dist in distance" :key="dist.id" @click="selectDistance(dist)">{{dist.distance}} км</button>
    <table class="table">
        <thead>
          <tr class="filters">
            <th><input type="text" class="form-control" placeholder="Место" ></th>
            <th class="hidden-sm hidden-xs"><input type="text" class="form-control" placeholder="Нагрудный номер" disabled></th>
            <th><input type="text" class="form-control" placeholder="Ф.И.О" disabled></th>
            <th><input type="text" class="form-control" placeholder="Возраст" disabled></th>
            <th><input type="text" class="form-control" placeholder="Пол" disabled></th>
            <th><input type="text" class="form-control" placeholder="Время" disabled></th>
            <th><input type="text" class="form-control" placeholder="Темп" disabled></th>
            <th></th>
          </tr>
        </thead>
      <tbody>
          <tr v-for="(result, index) in filterresults" :key="result.id">
            <td>{{index + 1}}</td>
            <td>{{result.bib_number}}</td>
            <td v-if="result.user_id"> <router-link :to="'/profile/' + result.user_id">{{result.u_name}} {{result.u_surename}} </router-link></td>
            <td v-if="!result.user_id">{{result.u_name}} {{result.u_surename}}</td>
             <td>{{result.age || "--"}}</td>
            <td>{{result.gender}}</td>
            <td>{{result.time}}</td>
            <td>{{result.temp}}</td>
            <td><button v-if="!result.user_id" class="btn btn-success">это я</button></td>
          </tr>
        </tbody>
      </table>

    <div class="panel-footer" style="top: 5px; padding-bottom: -5;">
        <div class="row">
            <div class="col col-xs-8">
                <ul class="pagination hidden-xs pull-right">
                    <li><a href="#">1</a></li>
                </ul>
                <ul class="pagination visible-xs pull-right">
                    <li><a href="#">«</a></li>
                    <li><a href="#">»</a></li>
                </ul>
            </div>
        </div>
    </div>
</div>
</template>
<script>
export default {
    props: ['eventid', 'distance'],
    data(){
        return {
            result: [
                {
                id: 1,
                number: 111,
                name: 'Stas',
                surename: 'Gorynov',
                age: 21,
                gender: "M",
                time: "2:36:00",
                temp: "0:05",
                user_id: 1
                }
            ],
            results: [],
            filterresults: []
        }
    },
    methods:{
        selectDistance(distance){
        },
        filterByDistance(dist){
            for(let i = 0; i < this.results.length; i++){
              if(this.results[i].distance == +dist){
                this.filterresults.push(this.results[i]);
              }
            }
        }
    },
    created(){
        if(this.$route.params.id){
          fetch(this.$store.state.url + '/api/results/event/' + this.$route.params.id)
          .then((res)=>{
            res.json().then(data=>{
              this.results = data;
              this.filterByDistance(42.2);
              console.log(this.filterresults);
            })
          })
          .catch(err=>{
            console.log(err);
          })
        }
    }

}
</script>

<style>

</style>
