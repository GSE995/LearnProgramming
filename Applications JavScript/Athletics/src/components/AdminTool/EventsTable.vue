
<template>
<div>
  <div class="row" v-if="load">
    <div id="loading">
      <ul class="bokeh">
        <li></li>
        <li></li>
        <li></li>
      </ul>
    </div>
  </div>
  <div class="container">
    <table class="table">
        <thead>
          <tr class="filters">
            <th><input type="text" class="form-control" placeholder="№"></th>
            <th><input type="text" class="form-control" placeholder="Название" v-model="searchName" v-on:keyup="filterEvents('name', searchName)"></th>
            <th><input type="text" class="form-control" placeholder="Страна" v-model="searchCountry" v-on:keyup="filterEvents('country', searchCountry)"></th>
            <th><input type="text" class="form-control" placeholder="Город" v-model="searchCity" v-on:keyup="filterEvents('city', searchCity)"></th>
            <th><input type="text" class="form-control" placeholder="Старт" disabled></th>
            <th><input type="text" class="form-control" placeholder="Дата создания" disabled></th>
            <th><input type="text" class="form-control" placeholder="Создатель" disabled></th>
          </tr>
        </thead>
      <tbody >
          <tr v-for="(event, index) in filterevets" :key="index">
            <td>{{index + 1}}</td>
            <td> <router-link :to="{name: 'Event', params: {id: event.id}}"> {{event.name}} </router-link> </td>
            <td>{{event.country}}</td>
            <td>{{event.city}}</td>
            <td>{{validDate(event.start_date)}}</td>
            <td>{{validDate(event.create_date)}}</td>
            <td><router-link :to="'/profile/' + event.creator_id">{{getCreator(event.creator_id)}}</router-link></td>
            <router-link :to="{name: 'ChangeEvent', params: { id: event.id}}"><button class="btn btn-success">Ред</button></router-link>
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
</div>
</template>

<script>
export default {
  data(){
    return {
      load: true,
      searchName: '',
      searchCountry: '',
      searchCity: '',
      searchCreator: '',
      events: [],
      filterevets: [],
      users: []
    }
  },
  methods:{
    getCreator(id){
      let fullname = "";

      for(let i = 0; i < this.users.length; i++){
        if(this.users[i].id == id){
          fullname = this.users[i].name + " " + this.users[i].surename;
        }
      }
      return fullname;
    },
    validDate(date){
      let options = {
        year: 'numeric',
        month: 'numeric',
        day: 'numeric',
      };
      let mill = Date.parse(date);
      let dt = new Date;
      dt.setTime(mill);

      return dt.toLocaleString("ru", options);
      },
    filterEvents(propety, strSearch){
      if(!strSearch || this.filterevets.length < 1){
        this.filterAll();
      }else{
        let str = new RegExp(strSearch.toLowerCase());
        let arr = [];

        arr = this.filterevets.filter((item, i)=>{
            let name = item[propety].toLowerCase();
            return str.test(name);
          });

        this.filterevets = arr;
      }
    },
    filterAll(){
      this.filterevets = this.events;
      if(this.searchName) this.filterEvents('name', this.searchName);
      if(this.searchCountry) this.filterEvents('country', this.searchCountry);
      if(this.searchCity) this.filterEvents('city', this.searchCity);
    }
  },
  created(){
    fetch(this.$store.state.url + '/api/events')
		      .then((res)=>{
		        res.json().then(data =>{
              this.filterevets = data.reverse();
              this.events = data;
              this.load = false;
		        })
		      })
    .catch(erro=>{
        console.log(erro);
      })
     fetch(this.$store.state.url + '/api/users')
      .then((res)=>{
        res.json().then(data=>{
          this.users = data;
        })
      })
      .catch(erro=>{
        console.log(erro);
      })
  }
}
</script>

<style>
#loading {
    height: 100%;
    left: 0;
    margin: auto;
    position: relative;
    top: 0;
    width: 50%;
}

.bokeh {
    border: 0.01em solid rgba(150, 150, 150, 0.1);
    border-radius: 50%;
    font-size: 100px;
    height: 1em;
    list-style: outside none none;
    margin: 0 auto;
    position: relative;
    top: 35%;
    width: 1em;
    z-index: 2147483647;
}

.bokeh li {
    border-radius: 50%;
    height: 0.2em;
    position: absolute;
    width: 0.2em;
}
.bokeh li:nth-child(1) {
    animation: 1.13s linear 0s normal none infinite running rota, 3.67s ease-in-out 0s alternate none infinite running opa;
    background: #00c176 none repeat scroll 0 0;
    left: 50%;
    margin: 0 0 0 -0.1em;
    top: 0;
    transform-origin: 50% 250% 0;
}
.bokeh li:nth-child(2) {
    animation: 1.86s linear 0s normal none infinite running rota, 4.29s ease-in-out 0s alternate none infinite running opa;
    background: #ff003c none repeat scroll 0 0;
    margin: -0.1em 0 0;
    right: 0;
    top: 50%;
    transform-origin: -150% 50% 0;
}
.bokeh li:nth-child(3) {
    animation: 1.45s linear 0s normal none infinite running rota, 5.12s ease-in-out 0s alternate none infinite running opa;
    background: #fabe28 none repeat scroll 0 0;
    bottom: 0;
    left: 50%;
    margin: 0 0 0 -0.1em;
    transform-origin: 50% -150% 0;
}
.bokeh li:nth-child(4) {
    animation: 1.72s linear 0s normal none infinite running rota, 5.25s ease-in-out 0s alternate none infinite running opa;
    background: #88c100 none repeat scroll 0 0;
    margin: -0.1em 0 0;
    top: 50%;
    transform-origin: 250% 50% 0;
}
@keyframes opa {
12% {
    opacity: 0.8;
}
19.5% {
    opacity: 0.88;
}
37.2% {
    opacity: 0.64;
}
40.5% {
    opacity: 0.52;
}
52.7% {
    opacity: 0.69;
}
60.2% {
    opacity: 0.6;
}
66.6% {
    opacity: 0.52;
}
70% {
    opacity: 0.63;
}
79.9% {
    opacity: 0.6;
}
84.2% {
    opacity: 0.75;
}
91% {
    opacity: 0.87;
}
}

@keyframes rota {
100% {
    transform: rotate(360deg);
}
}
</style>
