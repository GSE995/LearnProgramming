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
            <div class="list-group-item itm" v-for="(it, index) in notes" v-bind:key="it" >
             <span  class="">  {{it}} </span>
               <button class="btn btn-outline-danger" id="deleted" v-on:click="removeItem(index)">x</button> 
            </div>
            <textarea wrap="soft" class="form-control" v-if="show" v-model="add" v-on:keyup.enter="addItem"></textarea>
            <button class="btn" style="margin-top: 5px"  @click="show = !show">+</button>
            <button class="btn" style="margin-top: 5px" >-</button>
        </div>  
    </div>
    <!-- <ul class="list-group">
            <li class="list-group-item d-flex justify-content-between align-items-center itm" v-for="(it, index) in notes" v-bind:key="it">
        </li>
        </ul> -->
  </div>
</template>

<script>
export default {
    props:['day', 'month', 'year', 'uid'],
    data: function(){
        return {
            add: '',
            show: false,
            userData: [],
            arr: []
        }
    },
    methods: {
        validText(text){

        },
        addItem(){             
            if(this.notes.length){
                for(let i = 0; i < this.userData.length; i++){
                    if(this.userData[i]['data'] == `${this.day}.${this.month}.${this.year}`){
                        this.userData[i]['notes'].push(this.add);
                    }
                }     
            } else { 
                var obj = {
                    day: this.day,
                    month: this.month,
                    year: this.year,
                    data:  `${this.day}.${this.month}.${this.year}`,
                    notes: [this.add]
                }
                this.userData.push(obj);                   
            }

            firebase.database().ref('users/' + this.uid).set({
                items: this.userData
            });

            this.add = '';
        },
        removeItem(index){
            for(let i = 0; i < this.userData.length; i++){
                if(this.userData[i]['data'] == `${this.day}.${this.month}.${this.year}`){
                    if(this.userData[i]['notes'].length == 1){
                        this.userData.splice(i, 1);
                    }else{
                         this.userData[i]['notes'].splice(index, 1);  
                    }
                }
            }  

            firebase.database().ref('users/' + this.uid).set({
                items: this.userData
            });
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
    },
    computed: {
        notes(){
            let arr = [];
            
            if(this.userData){
                for(let i = 0; i < this.userData.length; i++){
                    if(this.userData[i]['data'] == `${this.day}.${this.month}.${this.year}`){
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
        this.userData = [];
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
#deleted{
   visibility: hidden;
}
.itm:hover #deleted{
    visibility: visible;
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
