<template>
  <div class="col-md-4 col-xs-12 btn" id="items">
    <div class="row" style="margin-top: 10px">
        <div  class="col-4" >
          <i class="fa fa-chevron-left fa-lg" @click="backDay" aria-hidden="true"></i>
        </div>
        <div class="col-4" style="-webkit-user-select: none;">
           <p class="h2">{{day}}</p>
        </div>
        <div class="col-4" >
            <i class="fa fa-chevron-right fa-lg" @click="nextDay" aria-hidden="true"></i>
        </div>
      <hr>
    </div>
    <div class="row">
    <div class="col-12" style="texr-align: left; font-weight: normal;">
          <div class="list-group-item itm" v-for="(it, index) in notes" v-bind:key="index" >
              <span > {{it}} </span>
              <div class="deleted" v-if="!show">
                <button class="btn" v-on:click="getItem(index)"><i class="fa fa-pencil" aria-hidden="true" ></i></button>
              <button class="btn" v-on:click="removeItem(index)"><i class="fa fa-times" aria-hidden="false"></i></button>
              </div>
            </div>
            <input class="form-control" v-if="!show" v-model="add" v-on:keyup.enter.prevent="addItem" placeholder="Write item..." style="margin-top: 15px; padding: 20px">
            <input v-focus class="form-control" id="ch" v-if="show" v-model="changeText" v-on:keyup.enter.prevent="changeItem" style="margin-top: 15px; padding: 20px">
             <div  v-if="erroText" class="alert alert-danger" role="alert"> {{erroText}}</div>
            <button class="btn" style="margin-top: 5px" v-if="show" @click="changeItem">Change</button>
            <button class="btn" style="margin-top: 5px" v-if="!show" @click="addItem">Add</button>
        </div>
    </div>
  </div>
</template>

<script>
export default {
    props:['day', 'month', 'year', 'uid'],
    data: function(){
        return {
            add: '',
            erroText: '',
            changeText: '',
            selectItem: -1,
            dataIndex: -1,
            show: false,
            userData: [],
            arr: []
        }
    },
    directives: {
      focus: {
        inserted: function (el) {
          el.focus()
        }
      }
    },
    methods: {
        addItem(){
            if(this.add){
              console.log(this.add.length);
              if(this.notes.length){
                for(let i = 0; i < this.userData.length; i++){
                    if(this.userData[i]['date'] == `${this.day}.${this.month}.${this.year}`){
                        this.userData[i]['notes'].push(this.add);
                    }
                }
            } else {
                var obj = {
                    day: this.day,
                    month: this.month,
                    year: this.year,
                    date:  `${this.day}.${this.month}.${this.year}`,
                    notes: [this.add]
                }
                this.userData.push(obj);
            }
            this.updateItems();

            this.add = '';

            }else{
                this.erroText = 'Заметка пуста..'
                setTimeout(()=>{this.erroText = ''}, 2000);
            }

        },
        removeItem(index){
            for(let i = 0; i < this.userData.length; i++){
                if(this.userData[i]['date'] == `${this.day}.${this.month}.${this.year}`){
                    if(this.userData[i]['notes'].length == 1){
                        this.userData.splice(i, 1);
                    }else{
                         this.userData[i]['notes'].splice(index, 1);
                    }
                }
            }

            this.updateItems();
        },
        getItem(index){
          for(let i = 0; i < this.userData.length; i++){
                if(this.userData[i]['date'] == `${this.day}.${this.month}.${this.year}`){
                    this.changeText = this.userData[i]['notes'][index];
                    this.add =  this.changeText;
                    this.selectItem = index;
                    this.dataIndex = i;
                    this.show = true;
                    this.userData[i]['notes'][index] = '';
                }
          }
        },
        changeItem(){
            if(this.changeText){
              this.add = "";
              this.userData[this.dataIndex]['notes'][this.selectItem] = this.changeText;
              this.show = false;
              this.updateItems();
            }else{
              this.erroText = 'Зачем изменять заметку на пустое значение?'
              this.changeText = this.add;
                setTimeout(()=>{this.erroText = ''}, 2000);
            }
        },
        nextDay(){
            let day = this.day;
            this.$emit("nextDay", ++day);
            this.show = false;
        },
        backDay(){
            let day = this.day;
            this.$emit("backDay", --day);
            this.show = false;
        },
        updateItems(){
            firebase.database().ref('users/' + this.uid).set({
                items: this.userData
            });
        }
    },
    computed: {
        notes(){
            let arr = [];

            if(this.userData.length){
                for(let i = 0; i < this.userData.length; i++){
                    if(this.userData[i]['date'] == `${this.day}.${this.month}.${this.year}`){

                        arr = this.userData[i]['notes'];
                    }
                }
            }
            let cellcollect = document.getElementsByClassName('cell');

            for(let i = 0; i < cellcollect.length; i++){
                cellcollect[i].style.color = '';
            }

            for(let i = 0; i < this.userData.length; i++){
                if(this.userData[i]['month'] == this.month && this.userData[i]['year'] == this.year){
                    let el = document.getElementById(this.userData[i]['day']);
                    el.style.color = '#FB7777';
                }
            }
            return arr;
        }
    },
    created(){
        const takeItem = firebase.database().ref('users/' + this.uid + '/items');
        takeItem.on('value', (data)=>{
            if(data.val()){
                this.userData = data.val();
            }
        });
    }
}
</script>



<style>
.deleted{
   display: none
}
.itm:hover .deleted{
    display: block;
}
.list-group-item{
    text-align: left;
}
.btn{
    word-wrap: break-word;
}
#itemhead{
    background-color: #32383e;
}
.next{
    cursor: pointer;
    -webkit-user-select: none;
}
.fa{
-webkit-user-select: none;
padding-top: 10px;
cursor: pointer
}
</style>
