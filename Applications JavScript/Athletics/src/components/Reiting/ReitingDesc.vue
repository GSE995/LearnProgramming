<template>
  <div class="container">
    <div class="row" style="margin-top: 100px">
    <button class="btn btn-default">Марафон</button>
    <button class="btn btn-default">Полумарафон</button>
    <button class="btn btn-default">10 км</button>
    <table class="table" style="margin-top: 50px">
        <thead>
          <tr class="filters">
            <th><input type="text" class="form-control" placeholder="№"></th>
            <th class="hidden-sm hidden-xs"><input type="text" class="form-control" placeholder="Имя" disabled></th>
            <th><input type="text" class="form-control" placeholder="Пол" disabled></th>
            <th><input type="text" class="form-control" placeholder="Время" disabled></th>
            <th><input type="text" class="form-control" placeholder="Мероприятие" disabled></th>
            <th><input type="text" class="form-control" placeholder="Страна" disabled></th>
          </tr>
        </thead>
      <tbody>
          <tr v-for="(result, index) in results" :key="index">
            <td>{{index + 1}}</td>
            <td v-if="result.user_id"><router-link :to="'/profile/' + result.user_id">{{result.u_name}} {{result.u_surename}}</router-link></td>
            <td v-if="!result.user_id">{{result.u_name}} {{result.u_surename}}</td>
            <td>{{result.gender}}</td>
            <td>{{result.time}}</td>
            <td><router-link :to="{name: 'Event', params: {id: result.event_id}}"> {{result.name}} </router-link></td>
            <td>{{result.country}}</td>
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
      <div class="row" v-if="!load">
        <div class="animationload">
          <div class="osahanloading"></div>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  data(){
    return {
      results: [],
      filterresult: [],
      load: false
    }
  },
  methods:{
    getTemp(){
    },
    getEventName(id){
      let name;
      for(let i = 0; i < this.events.length; i++){
        if(this.events[i].id == id){
          name = this.events[i].name;
        }
      }
      return name;
    }
  },
  created(){
    fetch(this.$store.state.url + '/api/results')
          .then((res)=>{
            res.json().then(data=>{
              this.results = data;
              this.filterresult = data;
              this.load = true;
            })
          })
          .catch(erro=>{
            console.log(erro);
            this.load = true;
            this.$router.push({name: 'Erro', params: {status: 1}});
          })
  }
}
</script>

<style>

</style>
