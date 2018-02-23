<template>
<div class="container" style="padding-top: 50px">
  <div class="row" v-if="success">
    <div class="col-md-10 col-md-offset-1">
      <div class="alert alert-success" role="alert"><h2>Event changed!!!</h2></div>
      <router-link :to="{name: 'Event', params: {id: eventId}}"> <button class="btn btn-default">Перейти на страницу мероприятия</button> </router-link>
      <!-- <router-link :to="{name: 'ChangeEvent', params: {id: eventId}}"> <button class="btn btn-default">Редактировать</button> </router-link> -->
    </div>
  </div>
  <div class="row" v-if="!success">
     <h2>Change events</h2>
    <div class="col-md-10 col-md-offset-1">
      <form role="form" action="#">
        <fieldset>
          <div class="form-group col-md-12">
            <label>Name</label>
            <input type="text" class="form-control" autocomplete="off" required v-model="event.name">
          </div>

          <div class="form-group col-md-12">
            <label>Poster</label>
            <input class="file-upload" id="im" name="myImage" type="file" @change="viewImage" >
            <div id="img-picker">
                <img :src="`/src/pic/${event.poster}`" id="chimg" alt="" style="max-width: 540px; max-height: 360">
            </div>
          </div>
          <div class="form-group col-md-12">
            <label>Description</label>
            <textarea placeholder="Enter description Here.." rows="3" class="form-control" required v-model="event.description"></textarea>
          </div>
        </fieldset>

        <fieldset>
          <div class="form-group col-md-6">
            <label>Country</label>
            <input type="text" class="form-control" autocomplete="off" placeholder="Country" required v-model="event.country">
          </div>

          <div class="form-group col-md-6">
            <label for="confirm_password">City</label>
            <input type="text" class="form-control" placeholder="City" autocomplete="off" required v-model="event.city">
          </div>

          <div class="form-group col-md-3">
            <label>Start</label>
            <input type="date" class="form-control" required v-model="event.start_date">
          </div>
          <div class="form-group col-md-3">
            <label>End</label>
              <input type="date" class="form-control"  required v-model="event.end_date">
          </div>
        </fieldset>
        <fieldset>
          <div class="form-group col-md-6 col-sm-6">
            <label>Distances</label>
            <p>Select default distances</p>
            <span class="btn btn-default" v-for="(dist, index) in default_distances" :key="index" v-on:click.prevent.stop="addDistaces(dist)">{{dist}}</span>
            <p>or create your</p>
             <div class="input-group">
               <input type="text" class="form-control"  v-model="distance">
              <span class="input-group-btn">
                <button class="btn btn-success" @click.stop.prevent="addDistaces(distance)">Add</button>
              </span>
            </div>
          </div>
          <div class="form-group col-md-6">
            <div v-for="(obj, index) in event.distances" :key="index">
              <span class="badge distance" >{{obj.distance}}</span>
              <span class="badge distance" >{{obj.cost}}</span>
              <span class="btn" @click.stop.prevent="removeDistance(index)"></span>
              <!-- <input class="form-control"  type="text"  placeholder="стоимость" v-if="!obj.cost" v-model.lazy.number="cost" v-on:keyup.enter="addCost(index)"> -->
            </div>
          </div>
        </fieldset>
        <fieldset>
          <h2>Contacts info</h2>
          <div class="form-group has-feedback col-md-6 col-sm-6">
            <label for="name" class="control-label">Organizer</label>
            <input type="text"  class="form-control" required="required" value="" placeholder="ТопАтлет" minlength="2" maxlength="30" v-model="event.organiser">
          </div>

          <div class="form-group has-feedback col-md-6 col-sm-6">
            <label for="name" class="control-label">Oficial site</label>
            <input type="text"  class="form-control" required="required" value="" minlength="2" maxlength="30" v-model="event.oficial_site">
          </div>

          <div class="form-group has-feedback col-md-6 col-sm-6">
              <label for="name" class="control-label">Email</label>
              <input type="text"  class="form-control" required="required" minlength="2" maxlength="30" v-model="event.email">
          </div>
        </fieldset>
      </form>
      <button v-if="!load" class="btn btn-warning" v-on:submit.prevent.stop @click="updateEvent">Update</button>
      <button v-if="load" class="btn btn-warning m-progress">Update</button>
      <div v-if="alert_erro" class="alert alert-danger" role="alert">Не все поля заполнены: {{erro_msg}}</div>
    </div>
  </div>
</div>

</template>

<script>
export default {
  data(){
    return {
      eventId: this.$route.params.id,
      load: false,
      erro_msg: '',
      alert_erro: false,
      distance: [],
      success:false,
      event: [],
      default_distances: [42.2, 21.1, 10, 5],
      new_poster: ''
    }
  },
  methods:{
      viewImage(){
        const input = document.getElementById('im');
        const files = input.files;

        if(false){

        }else {
        let reader = new FileReader();
        reader.onload = (function(theFile) {
        return function(e) {
          let img = document.getElementById('chimg');
          img.src = e.target.result;
        };
        })(files[0]);
      // Read in the image file as a data URL.
        reader.readAsDataURL(files[0]);
        }
      },
      updateEvent(){
        this.load = true;

        this.checkEvent();

        if(!this.alert_erro){
              this.sendImage();
          }
      },
      checkEvent(){
        // проверка на заполнение всех полей
        this.erro_msg = '';

        for(let key in this.event){
          if(!this.event[key]){
            this.alert_erro = true;
            this.erro_msg += ' ' + key + ',';
          }
        }
      },
      sendEvent(){
        let data = {event: this.event, new_poster: this.new_poster};

        let fetchdata = {
              method: 'post',
              mode: 'cors',
              headers: new Headers({"Content-type": "application/json"}),
              body: JSON.stringify(data)
          };

        fetch(this.$store.state.url + '/api/update/event/' + this.$route.params.id, fetchdata)
            .then((res)=>{
                res.json().then(data => {
                  this.event_id = data.eventid;
                  this.success = true;
                })
              })
              .catch((err)=>{
                this.erro_msg = "ошибка добавления мероприятия";
                // удалить картинку в случае неудачи
              })
      },
      sendImage(){
        const formData = new FormData();
        const input = document.getElementById('im');

        if(input.files[0]){

           formData.append('myImage', input.files[0]);
            const init = {
                method: 'POST',
                body: formData
              };
          console.log('here');
         fetch(this.$store.state.url + '/upload', init)
         .then((res) => {
              res.json()
                .then(data =>{
                  this.prev_poster = this.event.poster;
                  this.event.poster = data.imagename;
                  this.sendEvent();
                })
         })
         .catch(err=>{
           this.erro_msg = "не удалось загрузить изображение";
           console.log(err);
         })
        }else {
          this.sendEvent();
        }
    },
    setData(data){
        this.event = {
          name: data.name,
          description: data.description,
          city: data.city,
          country: data.country,
          start_date: data.start_date.substring(0, 10),
          end_date: data.end_date.substring(0, 10),
          distances: data.distances.sort((a,b)=>{
                  return (a.distance < b.distance)? 1 : -1;
              }),
          organiser: data.organiser,
          oficial_site: data.oficial_site,
          email: data.email,
          poster: data.poster
        }
    },
    addDistaces(){

    }
  },
  created(){
    // стянуть всю инфу о мероприятии
    fetch(this.$store.state.url + '/api/event/all/' + this.$route.params.id)
          .then((res)=>{
            res.json().then(data=>{
              this.setData(data[0]);
            })
          })
          .catch(err=>{
            console.log(err);
          })
  }
}
</script>

<style>
.file-upload {
  position: relative;
  height: 32px;
  width: 100%;
  cursor: pointer;
  font-size: 14px;
  font-family: sans-serif;
  line-height: 1.42857143;
  color: #555;
}

.file-upload:after {
  content: "Обзор";
  position: absolute;
  display: block;
  top: 0;
  right: 0;
  z-index: 5;
  background-color: #fff;
  border: 1px solid #ccc;
  border-radius: 0 4px 4px 0;
  padding: 6px 12px;
  color: #333;
}
.file-upload:hover:after {
  color: #333;
  background-color: #e6e6e6;
  border-color: #adadad;
}

.file-upload:active:after {
  outline: 0;
  -webkit-box-shadow: inset 0 3px 5px rgba(0, 0, 0, .125);
  box-shadow: inset 0 3px 5px rgba(0, 0, 0, .125);
}

.file-upload:before {
  content: attr(data-text);
  position: absolute;
  top: 0;
  left: 0;
  z-index: 3;
  display: block;
  width: calc(100% - 40px);
  padding: 6px 12px;
  background-color: #fff;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.file-upload input {
  position: absolute;
  display: block;
  top: 0;
  height: 100%;
  z-index: 99;
  width: 100%;
  opacity: 0;
}

/*  */

@-webkit-keyframes ld {
  0%   { transform: rotate(0deg) scale(1); }
  50%  { transform: rotate(180deg) scale(1.1); }
  100% { transform: rotate(360deg) scale(1); }
}
@-moz-keyframes ld {
  0%   { transform: rotate(0deg) scale(1); }
  50%  { transform: rotate(180deg) scale(1.1); }
  100% { transform: rotate(360deg) scale(1); }
}
@-o-keyframes ld {
  0%   { transform: rotate(0deg) scale(1); }
  50%  { transform: rotate(180deg) scale(1.1); }
  100% { transform: rotate(360deg) scale(1); }
}
@keyframes ld {
  0%   { transform: rotate(0deg) scale(1); }
  50%  { transform: rotate(180deg) scale(1.1); }
  100% { transform: rotate(360deg) scale(1); }
}

.m-progress {
    position: relative;
    opacity: .8;
    color: transparent !important;
    text-shadow: none !important;
}

.m-progress:hover,
.m-progress:active,
.m-progress:focus {
    cursor: default;
    color: transparent;
    outline: none !important;
    box-shadow: none;
}

.m-progress:before {
    content: '';

    display: inline-block;

    position: absolute;
    background: transparent;
    border: 1px solid #fff;
    border-top-color: transparent;
    border-bottom-color: transparent;
    border-radius: 50%;

    box-sizing: border-box;

    top: 50%;
    left: 50%;
    margin-top: -12px;
    margin-left: -12px;

    width: 24px;
    height: 24px;

    -webkit-animation: ld 1s ease-in-out infinite;
    -moz-animation:    ld 1s ease-in-out infinite;
    -o-animation:      ld 1s ease-in-out infinite;
    animation:         ld 1s ease-in-out infinite;
}

.btn-default.m-progress:before {
    border-left-color: #333333;
    border-right-color: #333333;
}

.btn-lg.m-progress:before {
    margin-top: -16px;
    margin-left: -16px;

    width: 32px;
    height: 32px;
}

.btn-sm.m-progress:before {
    margin-top: -9px;
    margin-left: -9px;

    width: 18px;
    height: 18px;
}

.btn-xs.m-progress:before {
    margin-top: -7px;
    margin-left: -7px;

    width: 14px;
    height: 14px;
}

</style>
