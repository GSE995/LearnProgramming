<template>
  <div class="container" id="profilecontainer">
    <div class="row" v-if="!load">
        <div class="animationload">
          <div class="osahanloading"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 " >
            <div class="card hovercard">
                <div class="card-background">
                    <img class="card-bkimg" :src="this.$store.state.src_userimg + (user.poster || user.img)">
                </div>
                <div class="useravatar">
                    <img :src="this.$store.state.src_userimg + (user.poster || user.img)">
                </div>
                <p>{{user.name}} {{user.surename}}</p>
                <div class="col-lg-6 col-xs-6 col-md-12 col-sm-12 stats">
                    <p>Лучшая дистанция</p>
                    <span class="badge  stat">42,2 км</span>
                </div>
                <div class="col-lg-6 col-xs-6 col-md-12 col-sm-12 stats">
                    <p>Лучшее время</p>
                    <span class="badge stat">2:42:40</span>
                </div>
                <div class="col-lg-6 col-xs-6 col-md-6 col-sm-12 stats">
                    <p>Завершенных мероприятий</p>
                    <span class="badge stat">1</span>
                </div>
                <div class="col-lg-6 col-xs-6 col-md-6 col-sm-12 stats">
                    <p>В общем пройдено</p>
                    <span class="badge stat">42,2 км</span>
                </div>
                <div class="col-lg-6 col-xs-6 col-md-6 col-sm-12 stats">
                    <p>Запланированно</p>
                    <span class="badge stat">2</span>
                </div>
            </div>
        </div>

        <div class="col-lg-8 col-sm-8 col-md-8 col-xs-12">
            <div class="card hovercard hidden-xs" style="border-radius: 0">
                <div class="card-background">
                    <img class="card-bkimg" :src="this.$store.state.src_userimg + (user.img || user.poster )">
                </div>
            </div>

            <div class=" btn-group btn-group-justified btn-group-lg" role="group">
                <div class="btn-group" role="group">
                    <button id="following" class="btn btn-default" href="#tab1" data-toggle="tab">
                        <div>
                            <i class="fa fa-star" aria-hidden="true"></i>
                            <p class="hidden-xs" >Результаты</p>
                        </div>
                    </button>
                </div>
                <div class="btn-group" role="group">
                    <button id="following" class="btn btn-default" href="#tab2" data-toggle="tab">
                        <div>
                            <i class="fa fa-calendar" aria-hidden="true"></i>
                            <p class="hidden-xs">Планы</p>
                        </div>
                    </button>
                </div>
                <div class="btn-group" role="group">
                    <button id="following" class="btn btn-default" href="#tab3" data-toggle="tab">
                        <div>
                            <i class="fa fa-file-text" aria-hidden="true"></i>
                            <p class="hidden-xs">Отчеты</p>
                        </div>
                    </button>
                </div>
                <div class="btn-group" role="group">
                    <button id="following" class="btn btn-default" href="#tab4" data-toggle="tab">
                        <div>
                            <i class="fa fa-camera-retro fa-lg"></i>
                            <p class="hidden-xs">Фото</p>
                        </div>
                    </button>
                </div>
            </div>
            <div class="well">
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab1">
                        <div class="row">
                            <Result v-for="(result, index) in user.results" :key="index" :result="result"></Result>
                        </div>
                    </div>

                    <div class="tab-pane fade in" id="tab2" >
                        <div class="row">
                            <EventCard v-for="(event, index) in user.events" :key="index" :event="event" :distances="[event.distance]"></EventCard>
                        </div>
                    </div>

                    <div class="tab-pane fade in" id="tab3" >
                        <div class="row">

                        </div>
                    </div>

                    <div class="tab-pane fade in" id="tab4" >
                        <div class="row">
                           {{user}}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import Result from '../Result/Result.vue'
import EventCard from '../Event/EventCard.vue'
export default {
    components:{
        Result,
        EventCard
    },
    data(){
        return{
            user: {},
            u: {},
            load: false
        }
    },
    created(){
            fetch(this.$store.state.url + '/api/user/all/' + this.$route.params.id)
		        .then((res)=>{
		        	res.json().then(data =>{
		        		console.log(data);
                this.user = data[0];
                this.load = true;
		        	})
		        })
		        .catch(()=>{
		        	alert('hi');
            })

         // если данные не передались через компонент то достать их из базы
        // запрашивать данные о пользователе, его планах, результатах, фотографиях
    }
}
</script>

<style>

.card.hovercard{
    background-color: #D8DEE2;
    -webkit-box-shadow:0 2px 6px rgba(0, 0, 0, 0.5), 0 0 40px rgba(0, 0, 0, 0.1) inset;
     -moz-box-shadow:0 2px 6px rgba(0, 0, 0, 0.5), 0 0 40px rgba(0, 0, 0, 0.1) inset;
    box-shadow:0 4px 8px rgba(0, 0, 0, 0.5), 0 0 40px rgba(0, 0, 0, 0.1) inset;
}

.card.hovercard {
    position: relative;
    padding-top: 0;
    overflow: hidden;
    text-align: center;
    background-color: #fff;
    background-color: rgba(255, 255, 255, 1);
}
    #profilecontainer{
        padding-top: 50px;
    }
    .useravatar + p{
        font-size: 20px
    }
    .stats{
        padding: 5px; height: 80px
    }
    .hovercard{
        border-radius: 0
    }

    .well{
        background-color: #4db6ac;
        border-color: #4db6ac;
        box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
        transition: all 0.3s cubic-bezier(.25,.8,.25,1);
        border-radius: 0
    }

    .card {
    margin-top: 20px;
    padding: 30px;
    background-color: rgba(214, 224, 226, 0.2);
    -webkit-border-top-left-radius:5px;
    -moz-border-top-left-radius:5px;
    border-top-left-radius:5px;
    -webkit-border-top-right-radius:5px;
    -moz-border-top-right-radius:5px;
    border-top-right-radius:5px;
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}

    #following:focus{
      background-color: #e0f2f1;
      border-color: #e0f2f1;
      box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
    }

    #following > div{
        color: #323232
    }

    #following{
  background-color: #b2dfdb;
  border-color: #b2dfdb;
  height: 60px
}

    .card-background img {
    -webkit-filter: blur(25px);
    -moz-filter: blur(25px);
    -o-filter: blur(25px);
    -ms-filter: blur(25px);
    filter: blur(25px);
    margin-left: -100px;
    margin-top: -200px;
    min-width: 130%;
}

.card.hovercard .useravatar {
    position: absolute;
    top: 15px;
    left: 0;
    right: 0;
}

.card.hovercard .card-background {
    height: 230px;
}


.badge.stat{
  background-color: #4db6ac;
  border-radius: 5px;
}


.card.hovercard .useravatar img {
    width: 200px;
    height: 200px;
    max-width: 200px;
    max-height: 200px;
    -webkit-border-radius: 50%;
    -moz-border-radius: 50%;
    border-radius: 50%;
    border: 5px solid rgba(255, 255, 255, 0.5);
}
</style>
