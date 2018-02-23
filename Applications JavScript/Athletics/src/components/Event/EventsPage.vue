<template>
<div class="container" style="padding-top: 50px ">
  <div class="row" v-if="!load">
        <div class="animationload">
          <div class="osahanloading"></div>
        </div>
    </div>
 		<br>

		<div class="row">
			<div id="carousel" class="carousel slide slidershadow">
				<div class="carousel-inner">
					<div class="item active" v-for="i in posters.slice(0,1)" :key="i.id">
						<img :src="i.src" height="300">
					</div>
					<div class="item" v-for="img in posters.slice(1)" :key="img.id">
						<img :src="img.src" height="300">
					</div>
				</div>
		<a href="#carousel" class="left carousel-control" data-slide="prev">
			<span class="glyphicon glyphicon-сhevron-left">	</span>
		</a>
		<a href="#carousel" class="right carousel-control" data-slide="next">
			<span class="glyphicon glyphicon-сhevron-right"></span>
		</a>
			</div>
		</div>





<div v-if="load" class="row">
  <h2 class="hidden-xs" style="margin-top: 20px;">СОРЕВНОВАНИЯ ПО БЕГУ</h2>
  	<div class="row">
  		<div class="container">
  			<ul class="nav nav-tabs event1">
	  			<li class="filter" @click="sortedByUpcome">
	  				<router-link :to="'/events/runs/page/' + 1">Предстоящие соревнования <span class="badge" style="background-color: #ff7043">{{upcomingevents.length}}</span></router-link>
	  			</li>
	  			<li class="filter" @click="getPastEvents">
	  				<router-link :to="'/events/runs/page/' + 1">Прошедшие <span class="badge" style="background-color: #ff7043; padding: 4px 7px">{{pastevents.length}}</span></router-link>
	  			</li>
  			</ul>
		</div>
	</div>
	<EventCard v-for="(event, key) in filterEvent.slice(start, end)" :key="key" :event="event" :distances="setDistances(event.id)"></EventCard>
	</div>
  <div class="container">
    <div class="center-block" style="padding-left: 47%">
		    <ul class="pagination hidden-xs ">
		    	<li v-for="number in paggination" :key="number" @click="getPageByNumber(number)"><router-link :to="'/events/runs/page/' + number">{{number}}</router-link></li>
		    </ul>
		    <ul class="pagination hidden-sm hidden-md hidden-lg">
		          <li><a @click="backPage">«</a></li>
		          <li><a @click="nextPage">»</a></li>
		    </ul>
      </div>
	</div>
</div>
</template>

<script>
import EventCard from '../Event/EventCard.vue'
export default {
	components: {
		EventCard
	},
	data(){
		return {
			posters: [],
      name: 'БЕГУ',
      start: 0,
      end: 4,
      maxevent: 4,
      pastevents: [],
      upcomingevents: [],
      distances: [],
      allevents: [],
      filterEvent:[],
      load: false
		}
  },
  methods: {
      nextPage(){
        if(this.filterEvent.length >= (this.end + 1)){
          this.start += 4;
          this.end += 4;
        }
      },
      backPage(){
        if(this.start){
          this.start -= 4;
          this.end -= 4;
        }
      },
      getPageByNumber(num){
            let a = (num - 1) * this.maxevent;
            let b = a + this.maxevent;
            this.start = a;
            this.end = b;
      },
      getPastEvents(){
          this.start = 0;
          this.end = 4;
          this.filterEvent = this.pastevents;
      },
      sortedByUpcome(){
          this.filterEvent = this.upcomingevents;
      },
      setDistances(eventid){
        let arr = [];
          for(let i = 0; i < this.distances.length; i++){
            if(this.distances[i].event_id == eventid){
              arr.push(this.distances[i]);
            }
          }
        return arr;
      },
      sortedPastEventByDate(){
        this.pastevents.sort((a, b)=>{
            return ( Date.parse(a.start_date) < Date.parse(b.start_date))? 1 : -1;
        });
      }
  },
	computed: {
		paggination(){
			let num = Math.ceil(this.filterEvent.length / this.maxevent);
			return num;
    },
    pageid(){
        this.getPageByNumber(this.$route.params.id);
        return this.$route.params.id;
    }
  },
  created(){
      fetch(this.$store.state.url + '/api/upcoming')
      .then((res)=>{
        res.json().then(data=>{
          console.log(data);
          this.upcomingevents = data;
          this.filterEvent = this.upcomingevents;
        })
      })
      .catch(erro=>{
        console.log(erro);
        this.load = true;
         this.$router.push({name: 'Erro', params: {status: 1}});
      })

      fetch(this.$store.state.url + '/api/past')
            .then((res)=>{
              res.json().then(data=>{
                this.pastevents = data;
              })
            })
            .catch(err=>{
              console.log(err);
            })

      this.getPageByNumber(this.$route.params.id);

      fetch(this.$store.state.url + '/api/distances')
      .then((res)=>{
        res.json().then(data=>{
          this.distances = data;
        })
      })
      .catch(err=>{
        console.log(err);
      })

      fetch(this.$store.state.url + '/api/posters')
      .then((res)=>{
        res.json().then(data =>{
          this.posters = data;
          this.load = true;
        })
      })

  }


}
</script>

<style scoped>

	h4{
		margin-top: 20px;
    text-align: center;
  }

  .nav-tabs {
	margin-bottom: 15px;
}
.filter{
  cursor: pointer
}

  .nav.nav-tabs.event1{
    background-color: #E2DFDF; -webkit-box-shadow:0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
       -moz-box-shadow:0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
            box-shadow:0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
}

.slidershadow{
 box-shadow:0 0 15px rgba(0,0,0,0.8);
}


</style>

