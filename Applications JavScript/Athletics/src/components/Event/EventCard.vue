<template>
    <div class="col-xs-6 col-sm-4 col-md-3 col-lg-3" id="headevenybox">
          <div class="thumbnail" id="eventbox">
            <router-link :to="{name: 'Event', params: {id: event.id, events: event, distance: distances, startdate:startdate }}">
            <img :src="this.$store.state.src_eventimg + event.poster">
            </router-link>
              <div class="row">
                <div class="col-xs-12 col-lg-12" id="name-event">
                    <p class="event" style="size: 10px">
                        <router-link :to="{name: 'Event', params: {id: event.id, events: event, distance: distances, startdate:startdate}}">{{event.name}}</router-link>
                    </p>
                    </div>
                <div class="col-lg-12">
                    <p class="dataevent">{{startdate || event.date}}</p>
                    </div>
                    <div class="col-lg-12" id="div-distance">
                    <span class="badge distance" v-for="dist in distances" :key="dist.id">{{dist.distance || dist}} км</span>
                    </div>
              </div>
          </div>
        </div>
</template>

<script>
export default {
    props:['event', 'distances'],
    data(){
        return {
        }
    },
    computed:{
      startdate(){
        let options = {
          year: 'numeric',
          month: 'long',
          day: 'numeric',
        };
        let mill = Date.parse(this.event.start_date);
        let dt = new Date;
        dt.setTime(mill);
        return dt.toLocaleString("ru", options);
      }
    }
}
</script>

<style>
#name-event p{
    font-size: 10px;
    padding-top: 10px;
  }
.dataevent{
    font-size: 10px;
  }

#eventbox {
  background-color: #F7F8FF;
  border-color: #F7F8FF;
  border-radius: 0;
  box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
  transition: all 0.3s cubic-bezier(.25,.8,.25,1);
}

#eventbox:hover{
   box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
}

.event{
  margin: 0 0 0px;
}

.dataevent{
  font-size: 10px;
}



#div-distance{
  padding-bottom: 5px;
}

#name-event p{
font-size: 13px;
padding-top: 10px;
}

#headevenybox{
  padding-left: 4px;
  padding-right: 4px;
}
</style>
