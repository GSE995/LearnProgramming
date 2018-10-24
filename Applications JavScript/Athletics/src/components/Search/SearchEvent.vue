<template>
  <div class="container" style="padding-top: 100px; padding-bottom: 100px">
    <div class="row" v-if="!load">
      <div class="animationload">
        <div class="osahanloading"></div>
      </div>
    </div>
    <div class="input-group" style="padding-bottom: 30px">
      <input type="text" class="form-control event" placeholder="Поиск мероприятий (введите название)" style=" border-radius: 0" v-model="searchEvent" @keyup.enter="getSearchEventPage">
        <span class="input-group-btn" >
        <button class="btn btn-danger event" type="button" @click="getSearchEventPage" >Go!</button>
      </span>
    </div>
    <div v-if="find">
      <h2>По результату <mark>{{this.$route.params.name}}</mark> найдено:</h2>
      <EventCard v-for="(event, index) in events" :key="index" :event="event"></EventCard>
    </div>
    <div v-if="!find">
      <h2>По вашему запросу ничего не найдено</h2>
      <h3><router-link :to="'/'">на главную</router-link></h3>
    </div>
  </div>
</template>

<script>
import EventCard from '../Event/EventCard.vue'
export default {
  components:{
      EventCard
  },
  data(){
    return {
      events: [],
      load: false,
      find: false,
      searchEvent: this.$route.params.name
    }
  },
  methods:{
    getSearchEventPage(){
      this.load = false;
      if(this.searchEvent){
          this.$router.push({name: 'SearchEvent', params: {name: this.searchEvent}});
          this.getEvents();
        }else{
          alert('not');
        }
    },
    getEvents(){
      fetch(this.$store.state.url + '/api/search/events/' + this.$route.params.name)
    .then(res=>{
      res.json().then(data=>{
          if(data.length){
            this.events = data;
            this.find = true;
          }
          this.load = true;
      })
    })
    }
  },
  created(){
    fetch(this.$store.state.url + '/api/search/events/' + this.$route.params.name)
    .then(res=>{
      res.json().then(data=>{
          if(data.length){
            this.events = data;
            this.find = true;
          }
          this.load = true;
      })
    })
  }

}
</script>

<style scoped>
  h2{
    text-align: center
  }
  h3{
    text-align: center;
  }
</style>
