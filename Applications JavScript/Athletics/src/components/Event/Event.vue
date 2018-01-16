<template>
<div>
  <div class="container" >
	<div class="row" v-if="!load">
        <div class="animationload">
            <div class="osahanloading"></div>
        </div>
	</div>
</div>
    <div class="container" style="padding-top: 70px;">
        <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
            <div class="thumbnail event" style="border-radius: 0;">
                <img :src="`${this.$store.state.src_eventimg}${event.poster}`" style="width: 100%">
            </div>
        </div>
        <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
            <div class="thumbnail">
                <h3>{{event.name}}</h3>
                <div style="padding-left: 30px">
                <p><strong>Место проведения:</strong> {{event.country}}, {{event.city}}</p>
                <p><strong>Дата проведения:</strong> {{startdate || startd()}} </p>
                <p><strong>Дистанции: <span v-for="dist in event.distances" :key="dist.id" class="badge distance">{{dist.distance}}</span></strong></p>

                <p><strong>Стоимость: </strong> от 800 до 1000 <i class="fa fa-rub" aria-hidden="true"></i></p>
                <button class="btn btn-warning btn-sm"> Участвовать </button>
                <button class="btn btn-warning btn-sm"> Добавить в планы </button>
                <p style="padding-top: 15px">Рейтинг на основе участников
                    <button class="btn btn-success" style="border-radius: 20px">
                        <strong>4</strong>
                        <i class="fa fa-star"></i>
                    </button>
                </p>
                </div>
            </div>
        </div>
    </div>

    <div class="container" style="padding-top: 40px">
        <div class="row">
            <ul class="nav nav-tabs nav-justified">
                <li class="active nav-item"><a href="#tab-1" data-toggle="tab">Информация</a></li>
                <li v-if="status_result" ><a href="#tab-2" data-toggle="tab">Результаты</a></li>
                <li><a href="#tab-3" data-toggle="tab">Дистанции</a></li>
                <li><a href="#tab-4" data-toggle="tab">Контакты</a></li>
                <li><a href="#tab-5" data-toggle="tab">Участники</a></li>
                <li><a href="#tab-6" data-toggle="tab">Отзывы</a></li>
                <li><a href="#tab-7" data-toggle="tab">Отчеты</a></li>
            </ul>
        </div>

        <div class="tab-content">
            <div class="tab-pane fade in active" id="tab-1">
                <h4 style="padding-bottom: 80px; padding-top: 30px">{{event.description}}</h4>
            </div>

            <div  class="tab-pane fade" id="tab-2" >
                <ResultsTable v-if="status_result" :eventid="event.id" :distance="event.distances"></ResultsTable>
            </div>

            <div  class="tab-pane fade" id="tab-3">
                <DistancesCard :distances="event.distances"></DistancesCard>
            </div >

            <div class="tab-pane fade" id="tab-4">
                <section id="map">
                    <div class="container">
                        <br>
                        <div class="row">
                            <div class="col-md-7 col-lg-7 col-sm-7">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d10690.659841203127!2d37.54922099120497!3d55.71620283131831!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x46b54b86290372b3%3A0x99a79ca4effb81fe!2z0JvRg9C20L3QuNC60LgsINC80LDQu9Cw0Y8g0YHQv9C-0YDRgtC40LLQvdCw0Y8g0LDRgNC10L3QsA!5e0!3m2!1sru!2sru!4v1495595432474" width="100%" height="400px" frameborder="0" style="border:0" allowfullscreen></iframe>
                            </div>
                            <div class="col-lg-5 col-sm-5 col.md-5">
                                <div class="form-group has-feedback">
                                    <label for="name" class="control-label">Организатор</label>
                                    <span class="form-control">{{event.organiser}}</span>
                                </div>
                                <div class="form-group has-feedback">
                                    <label for="name" class="control-label">Официальный сайт</label>
                                    <span class="form-control"><a :href="event.oficial_site">{{event.oficial_site}}</a></span>
                                </div>
                                <div class="form-group has-feedback">
                                    <label for="name" class="control-label">Почта</label>
                                    <span class="form-control">{{event.email}}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>

            <div class="tab-pane fade" id="tab-5">
            </div>

            <div class="tab-pane fade" id="tab-6">

            </div>

            <div class="tab-pane fade" id="tab-7">
            </div>

        </div>
    </div>
</div>
</template>

<script>
import ResultsTable from '../Results/ResultsTable.vue'
import DistancesCard from '../Distances/DistancesCard.vue'
export default {
    components: {
        ResultsTable,
        DistancesCard
    },
    data(){
        return {
            organizer: 'top',
            event: [],
            startdate: '',
            results: [],
            status_result: false,
            load: false
        }
    },
    methods:{
      startd(){
        let options = {
          year: 'numeric',
          month: 'long',
          day: 'numeric',
        };
        let mill = Date.parse(this.event.start_date);
        let dt = new Date;

        if(mill < Date.now()){
          this.status_result = true;
        }
        dt.setTime(mill);
        return dt.toLocaleString("ru", options);
      }
    },
    created(){
          fetch(this.$store.state.url + '/api/event/all/' + this.$route.params.id)
          .then((res)=>{
            res.json().then(data=>{
              this.event = data[0];
              this.event.distances.sort((a,b)=>{
                  return (a.distance < b.distance)? 1 : -1;
              })
              this.load = true;
            })
          })
          .catch(err=>{
            console.log(err);
          })
      }

}
</script>

<style scoped>
    .thumbnail{
        border-radius: 0; background-color: #b2dfdb;
        border-color: #b2dfdb;
        border-radius: 0;
        box-shadow: 0 10px 20px rgba(0,0,0,0.19), 0 6px 6px rgba(0,0,0,0.23); font-family: 'Roboto', sans-serif;
    }
    .thumbnail > button{
        margin-left: 10px;
        border-radius: 0;
        background-color: #ffb74d;
        border-color: #ffb74d;
    }
    h4 {
      line-height: 1.5;
      font-family:sans-serif;
      color: #7D7D7D;
      text-decoration-line: none;
      padding-top: 0;
      margin-bottom: 20px;
    }


</style>
