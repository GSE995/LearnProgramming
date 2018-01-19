<template>
<div class="container" style="padding-top: 50px">
  <div class="row" v-if="success">
    <div class="col-md-10 col-md-offset-1">
      <div class="alert alert-success" role="alert"><h2>Event create success!!!</h2></div>
      <router-link :to="{name: 'Event', params: {id: event_id}}"> <button class="btn btn-default">Перейти на страницу мероприятия</button> </router-link>
      <router-link :to="{name: 'Event', params: {id: event_id}}"> <button class="btn btn-default">Редактировать</button> </router-link>
    </div>
  </div>
  <div class="row" v-if="!success">
     <h2>Create events</h2>
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
                <img src="" id="chimg" alt="" style="max-width: 540px; max-height: 360">
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
              <span class="btn" @click.stop.prevent="removeDistance(index)">x</span>
              <!-- <input class="form-control"  type="text"  placeholder="стоимость" v-if="!obj.cost" v-model.lazy.number="cost" v-on:keyup.enter="addCost(index)"> -->
            </div>
          </div>
        </fieldset>
        <fieldset>
          <h2>Contacts info</h2>
          <div class="form-group has-feedback col-md-6 col-sm-6">
            <label for="name" class="control-label">Organizer</label>
            <input type="text"  class="form-control" required="required" value="" placeholder="ТопАтлет" minlength="2" maxlength="30">
          </div>

          <div class="form-group has-feedback col-md-6 col-sm-6">
            <label for="name" class="control-label">Oficial site</label>
            <input type="text"  class="form-control" required="required" value="" minlength="2" maxlength="30">
          </div>

          <div class="form-group has-feedback col-md-6 col-sm-6">
              <label for="name" class="control-label">Email</label>
              <input type="text"  class="form-control" required="required" value=""  minlength="2" maxlength="30">
          </div>
        </fieldset>

      </form>
      <button class="btn btn-warning" v-on:submit.prevent.stop @click="sendEvent">Create</button>
      <div v-if="alert_erro" class="alert alert-danger" role="alert">Не все поля заполнены: {{erro_msg}}</div>
    </div>
  </div>
</div>

</template>

<script>
export default {
  data(){
    return {
      event: {
        name: '',
        description: '',
        city: '',
        country: '',
        start_date: '',
        end_date: '',
        distances: []
      },
      oficial_site: '',
      distance: '',
      cost: '',
      default_distances: [42.2, 21.1, 10, 5],
      event_id: null,
      success: false,
      alert_erro: false,
      erro_msg: ''
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
    sendImage(){
        const formData = new FormData();
        const input = document.getElementById('im');

        if(input.files[0]){
           formData.append('myImage', input.files[0]);
            const init = {
                method: 'POST',
                body: formData
              };
         fetch(this.$store.state.url + '/upload', init)
         .then((res) => {
              res.json()
                .then(data =>{
                  this.event.poster = data.imagename;
                  this.checkEvent();
                })
         })
         .catch(err=>{
           console.log(err);
         })
        }else {
          this.erro_msg = 'не выбрано изображение';
          console.log('img is empty');
        }
    },
    sendEvent(){
      this.erro_msg = '';

      for(let key in this.event){
            if(!this.event[key]){
              this.alert_erro = true;
              this.erro_msg += ' ' + key + ',';
            }
      }
      if(!this.erro_msg){
         this.sendImage();
      }
    },
    checkEvent(){
      if(!this.alert_erro && this.event.poster){
        let fetchdata = {
             method: 'post',
             mode: 'cors',
              headers: new Headers({"Content-type": "application/json"}),
              body: JSON.stringify(this.event),
        };

		    fetch(this.$store.state.url + '/api/addevent', fetchdata)
		      .then((res)=>{
              res.json().then(data => {
                this.event_id = data.eventid;
                this.success = true;
              })
		        })
		        .catch((err)=>{
		        	alert(err);
            })
      }else{
        console.log("poster empty");
      }

    },
    addDistaces(dist){
       let obj = {};
      obj.cost = '';
      if(dist){
        obj.distance = dist;
        this.event.distances.push(obj);
        this.distance = '';

        this.event.distances.sort((a,b)=>{
              if (a.distance < b.distance) return 1;
              if (a.distance > b.distance) return -1;
          });
      }
    },
    addCost(index){
      this.event.distances[index].cost = this.cost;
      this.cost = '';
    },
    removeDistance(index){
         this.event.distances.splice(index, 1);
    }
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

</style>
