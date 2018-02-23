<template>
  <div class="container">
    <div class="row" style="margin-top: 100px">
    <span class="btn">Дистанция</span>
    <div class="btn-group" role="group" aria-label="...">
      <div class="btn-group" role="group">
        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
         {{distance}}
          <span class="caret"></span>
        </button>
        <ul class="dropdown-menu" id="dist">
          <li><a @click="selectDistance('42.2')">42.2</a> </li>
          <li><a  @click="selectDistance('21.1')">21.1</a> </li>
          <li><a @click="selectDistance('10')">10 км</a> </li>
        </ul>
      </div>
    </div>
    <table class="table" style="margin-top: 50px">
        <thead>
          <tr class="filters">
            <th><input type="text" class="form-control" placeholder="№" disabled></th>
            <th><input type="text" class="form-control" placeholder="Имя" v-model="searchUserName" v-on:keyup="filterByUserName"></th>
            <th><input type="text" class="form-control" placeholder="Пол" v-model="selectGender" v-on:keyup="filterByGender"></th>
            <th><input type="text" class="form-control" placeholder="Время" disabled></th>
            <th><input type="text" class="form-control" placeholder="Мероприятие" v-model="searchEventName" v-on:keyup="filterByEventName"></th>
            <th><input type="text" class="form-control" placeholder="Страна" ></th>
          </tr>
        </thead>
      <tbody>
          <tr v-for="(result, index) in filterresult" :key="index">
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
      selectGender: '',
      distance: "42,2",
      searchEventName: '',
      searchUserName: '',
      results: [],
      filterresult: [],
      selectDistanceArray: [],
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
    },
    selectDistance(dist){
      this.distance = dist;

      this.selectDistanceArray = this.results.filter((itm)=>{
        return itm.distance == dist;
      })
      this.filterresult = this.selectDistanceArray;
    },
    filterByUserName(){
        if(!this.searchUserName || this.filterresult.length < 1){
          this.filterAll();
        }else{
          let str = new RegExp(this.searchUserName.toLowerCase());
          let arr = [];
          arr = this.filterresult.filter((item, i)=>{
              let name = `${item.u_name.toLowerCase()} ${item.u_surename.toLowerCase()}`;
              return str.test(name);
            });
          this.filterresult = arr;
        }
    },
    filterByEventName(){
      if(!this.searchEventName || this.filterresult.length < 1){
         this.filterAll();
      }else{
        let str = new RegExp(this.searchEventName.toLowerCase());
        let arr = [];
        arr = this.filterresult.filter((item, i)=>{
            let name = item['name'].toLowerCase();
            return str.test(name);
          });
        this.filterresult = arr;
      }
    },
    filterByGender(){
      if(!this.selectGender || this.filterresult.length < 1){
         this.filterAll();
      }else{
        let str = new RegExp(this.selectGender.toLowerCase());
        let arr = [];
        arr = this.filterresult.filter((item, i)=>{
            let name = item['gender'].toLowerCase();
            return str.test(name);
          });
        this.filterresult = arr;
      }
    },
    filterAll(){
      this.filterresult = this.selectDistanceArray;
      if(this.searchUserName) this.filterByUserName();
      if(this.selectGender)this.filterByGender();
      if(this.selectEventName) this.filterByEventName();
    }
  },
  created(){
    fetch(this.$store.state.url + '/api/results')
          .then((res)=>{
            res.json().then(data=>{
              this.results = data;
              this.selectDistanceArray = data.filter((itm)=>{
                return itm.distance == '42.2';
              })
              this.filterresult = this.selectDistanceArray;
              this.load = true;
            })
          })
          .catch(erro=>{
            this.load = true;
            this.$router.push({name: 'Erro', params: {status: 1}});
          })
  }
}
</script>

<style>
#dist{
  cursor: pointer;
}
</style>
