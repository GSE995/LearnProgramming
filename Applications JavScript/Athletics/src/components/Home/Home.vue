<template>
<div>
  <div class="container" >
    <div class="row" v-if="!load">
      <div class="animationload">
        <div class="osahanloading"></div>
      </div>
    </div>
</div>
    <div id="carousel">
        <div class="carousel-inner">
            <div class="item active">
              <img src="/src/pic/medal.jpg">
              <div class="carousel-caption">
                <div class="col-lg-8 col-sm-8 col-md-8 col-xs-8 search-result1">
                  <div class="input-group">
                    <input type="text" class="form-control event" placeholder="Поиск мероприятий (введите название)" style=" border-radius: 0" v-model="searchEvent" @keyup.enter="getSearchEventPage">
                    <span class="input-group-btn" >
                      <button class="btn btn-danger event" type="button" @click="getSearchEventPage" >Go!</button>
                    </span>
                  </div>
                </div>
                <div class="col-lg-8 col-sm-8 col-md-8 col-xs-8 search-result2">
                  <div class="input-group">
                    <input type="text" class="form-control event" placeholder="Поиск результатов (Введите фамилию и имя)" style=" border-radius: 0" v-model="searchResult" @keyup.enter="getSearchResultPage">
                    <span class="input-group-btn" >
                      <button class="btn btn-warning event" type="button" @click.prevent="getSearchResultPage">Go!</button>
                    </span>
                  </div>
                </div>
              </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <h2>Предстоящие мероприятия</h2>
            <EventCard v-for="(event, index) in events" :key="index" :event="event" :distances="setDistances(event.id)"></EventCard>
            <router-link :to="'/create'">
            <div class="col-xs-6 col-sm-4 col-md-3 col-lg-3" id="headevenybox">
              <div class="thumbnail" id="eventbox">
                <h4 style="text-align:center; text-decoration: none;">Создать свое мероприятие</h4>
              </div>
            </div>
            </router-link>
        </div>
    </div>

    <div class="container-fluid">
      <div class="container">
        <h2>Недавно зарегистрированные пользователи</h2>
        <UserCard v-for="(user, index) in users" :key="index" :user="user"> </UserCard>
      </div>
    </div>
</div>
</template>

<script>
import EventCard from '../Event/EventCard.vue'
import UserCard from '../Users/UserCard.vue'

export default {
    components:{
        EventCard,
        UserCard
    },
    name: 'Home',
    data(){
        return {
            events:[],
            distances: [],
            users: [],
            load: false,
            searchEvent: '',
            searchResult: ''
        }
    },
    methods:{
      setDistances(eventid){
        let arr = [];
          for(let i = 0; i < this.distances.length; i++){
            if(this.distances[i].event_id == eventid){
              arr.push(this.distances[i]);
            }
          }
        return arr;
      },
      getSearchEventPage(){
        if(this.searchEvent){
          this.$router.push({name: 'SearchEvent', params: {name: this.searchEvent}});
        }else{
          alert('not');
        }
      },
      getSearchResultPage(){
        if(this.searchResult){
            this.$router.push({name: 'SearchResult', params: {name: this.searchResult}});
        }else{
          alert('not');
        }
      }
    },
    created(){
      fetch(this.$store.state.url + '/api/upcoming')
		      .then((res)=>{
		        res.json().then(data =>{
              this.events = data;
              this.load = true;
		      })
		      })
          .catch(erro=>{
        console.log(erro);
        this.load = true;
         this.$router.push({name: 'Erro', params: {status: 1}});

      })
      fetch(this.$store.state.url + '/api/distances')
          .then((res)=>{
            res.json().then(data=>{
              this.distances = data;
            })
          })
          .catch(err=>{
            console.log(err);
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
<style scoped>
    h3{
        text-align: center;
    }
    #foot{
        padding-bottom: 10px; background-color: #37474f
    }
    #social{
        padding-top: 10px; padding-left: 0%
    }
    #logo{
        margin-right: 0%;
        margin-top: 15px;
        padding: 0
    }

    .col-lg-8.col-sm-8.col-md-8.col-xs-8.search-result1{
    margin-top: -49%;
  margin-left: 17%;
}
.col-lg-8.col-sm-8.col-md-8.col-xs-8.search-result2{
  margin-top: -39%;
  margin-left: 17%;

}
@media (max-width: 768px){
  .col-lg-8.col-sm-8.col-md-8.col-xs-8.search-result1{
   padding-top: 15%;
  margin-left: 17%;
}
.col-lg-8.col-sm-8.col-md-8.col-xs-8.search-result2{
  margin-left: 17%;
  padding-top: 15%;
}
}

@media (max-width: 400px){
.col-lg-8.col-sm-8.col-md-8.col-xs-8.search-result1{
   padding-top: 15%;
  margin-left: 17%;
}
.col-lg-8.col-sm-8.col-md-8.col-xs-8.search-result2{
  margin-left: 17%;
  padding-top: 15%;
}
}
</style>
