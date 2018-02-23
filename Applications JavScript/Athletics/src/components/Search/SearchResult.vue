<template>
  <div class="container" style="padding-top: 100px; padding-bottom: 100px">
    <div class="row" v-if="!load">
      <div class="animationload">
        <div class="osahanloading"></div>
      </div>
    </div>
     <div class="input-group">
          <input type="text" class="form-control event" placeholder="Поиск результатов (Введите фамилию и имя)" style=" border-radius: 0" v-model="searchResult" @keyup.enter="getSearchResultPage">
          <span class="input-group-btn" >
            <button class="btn btn-warning event" type="button" @click.prevent="getSearchResultPage">Go!</button>
          </span>
        </div>
    <div v-if="find">
      <h2>По результату <mark>{{this.$route.params.name}}</mark> найдено: </h2>
      <div class="table-responsive">
        <table class="table">
          <thead>
            <tr>
              <th>Имя</th>
              <th>Время</th>
              <th>Пол</th>
              <th>Мероприятие</th>
              <th>Дистанция</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(result, index) in results" :key="index">
              <td v-if="result.user_id"><router-link :to="'/profile/' + result.user_id">{{result.u_name}} {{result.u_surename}}</router-link></td>
              <td v-if="!result.user_id">{{result.u_name}} {{result.u_surename}}</td>
              <td>{{result.time}}</td>
              <td>{{result.gender}}</td>
              <td><router-link :to="{name: 'Event', params: {id: result.event_id}}"> {{result.name}}</router-link> </td>
              <td>{{result.distance}}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div v-if="!find">
       <h2>По вашему запросу ничего не найдено</h2>
        <h3><router-link :to="'/'">на главную</router-link></h3>
    </div>
  </div>
</template>

<script>
export default {
  data(){
    return {
      results: [],
      load: false,
      find: false,
      searchResult: this.$route.params.name,
    }
  },
  methods:{
     getSearchResultPage(){
       this.load = false;
        if(this.searchResult){
            this.$router.push({name: 'SearchResult', params: {name: this.searchResult}});
            this.getResults();
        }else{
          alert('not');
        }
      },
    getResults(){
      fetch(this.$store.state.url + '/api/search/results/' + this.$route.params.name)
    .then(res=>{
      res.json().then(data=>{
        if(data.length){
          this.results = data;
          this.find = true;
        }
        this.load = true;

      })
    })
    .catch(erro=>{
      console.log(erro);
      this.load = true;
    })
    }
  },
  created(){
    fetch(this.$store.state.url + '/api/search/results/' + this.$route.params.name)
    .then(res=>{
      res.json().then(data=>{
        if(data.length){
          this.results = data;
          this.find = true;
        }
        this.load = true;

      })
    })
    .catch(erro=>{
      console.log(erro);
      this.load = true;
    })
  }

}
</script>

<style scoped>
  h2{
    text-align: center
  }
</style>
