<template>
<div class="row h">  
    <div class="col-md-6 col-xs-12">
        <table class="table table-bordered table-dark" id="light">
        <thead>
            <tr class="head"> 
                <th> <span class="next"><i @click="backYear" class="fa fa-chevron-left fa-lg" aria-hidden="true"></i></span> </th>
                <th scope="col" class="h3" colspan="5">{{year}}</th>
                <th><span class="next"><i @click="nextYear" class="fa fa-chevron-right fa-lg" aria-hidden="true"></i></span></th>
            </tr>
            <tr class="head"> 
                <th><span class="next"><i @click="backMonth" class="fa fa-chevron-left fa-lg" aria-hidden="true"></i></span></th>
                <th scope="col" class="h3" colspan="5">{{months[month]}}</th>
                <th><span class="next"><i @click="nextMonth" class="fa fa-chevron-right fa-lg" aria-hidden="true"></i></span></th>
            </tr>
            <tr>
                <th id="lable" scope="col" v-for="lable in lables" v-bind:key="lable">{{lable}}</th>  
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="anothermonth" v-for="(prev, index) in previouslyDays" :key="index + 70" >{{prev}}</td>
                <td class="cell" v-for="start in startDays" :key="start" :id="start" v-on:click="selectDay(start)">{{start}}
                    <span class="flag"></span>
                </td>
            </tr>
            <tr>
                <td class="cell" v-for="row1 in rows.slice(0,7)" :key="row1" :id="row1" v-on:click="selectDay(row1)">{{row1}}
                    <span class="flag"></span>
                </td>
            </tr>
            <tr>
                <td class="cell" v-for="row2 in rows.slice(7,14)" :key="row2" :id="row2" v-on:click="selectDay(row2)">{{row2}}
                    <span class="flag"></span>
                </td>
            </tr>
            <tr>
                <td class="cell" v-for="row3 in rows.slice(14, 21)" :key="row3" :id="row3" v-on:click="selectDay(row3)">{{row3}}
                    <span class="flag"></span>
                </td>
            </tr>
            <tr>
                <td class="cell" v-for="row4 in rows.slice(21, 28)" :key="row4" :id="row4" v-on:click="selectDay(row4)">{{row4}}
                    <span class="flag"></span>
                </td>
                <td class="anothermonth" v-for="rownext in nextrows[1]" v-bind:key="rownext">{{rownext}}</td>
            </tr>
            <tr>
                <td class="cell" v-for="row5 in rows.slice(28)" :key="row5" :id="row5" v-on:click="selectDay(row5)">{{row5}}
                    <span class="flag"></span>
                </td>
                <td class="anothermonth" v-for="(rownext, index) in nextrows[0]" :key="index + 40" >{{rownext}}</td>
            </tr>
        </tbody>
        </table>
    </div>
     <Notes v-if="complite" :day="day" :month="month" :year="year" :uid="uid" @nextDay="nextDay" @backDay="backDay"></Notes>
</div>
</template>

<script>
import Notes from './Notes.vue'
export default {
    props:['uid', 'complite'],
    components:{
            Notes
        },
    data: function(){
        return {
            title: "Hello",
            months: [ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" ], 
            lables: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
            month: new Date().getMonth(),
            year: new Date().getFullYear(),
            day: new Date().getDate(),
        }},
    methods: {
        nextDay(day){
            let date = new Date(this.year, this.month + 1, 0).getDate();
            let last = this.day;

                if(day > date){
                    this.nextMonth();
                    this.day = 1;
                }else{
                    this.day = day;
                }

            this.changeCellColor(last, this.day);
            },
        backDay(day){
            let last = this.day;

                if(day < 1){
                    this.backMonth();
                    this.day = new Date(this.year, this.month + 1, 0).getDate();
                }else{
                    this.day = day;
                }

            this.changeCellColor(last, this.day);
            },
        changeCellColor(last, current){
            // странная херь
            if(last){
                let el1 = document.getElementById(last);
                
                if(el1){
                    el1.style.backgroundColor = '';
                    }
            }
                let el2 = document.getElementById(current);

                if(el2){
                    el2.style.backgroundColor = "#32383e";  
                }
        },
        selectDay(day){
            let last = this.day;
            this.day = day;
            this.changeCellColor(last, this.day);
        },
        nextMonth() {
            this.month++;
            if(this.month > this.months.length - 1){
                this.month = 0;
                this.year++;
            }
            this.changeCellColor(2, this.day);
        },
        backMonth() {
            this.month--;
            if(this.month < 0){
                this.month = this.months.length - 1;
                this.year--;
            } 
        },
        nextYear(){
            this.year++;
        },
        backYear(){
            this.year--;
        }

    },

    computed:{
        previouslyDays() {
            var row = [];
            var previosliDays = new Date(this.year, this.month, 0).getDate();
            var numberWeek = new Date(this.year, this.month, 1).getDay();
            if(numberWeek == 0) numberWeek = 7;
            var size = numberWeek - 2;
            if(size > -1){
                for(var i = size, j = previosliDays; i > -1; i--, j-- ){
                    row[i] = j;
                }
            }
            return row;
        },
        startDays() {
            var row = []
            var numberWeek = new Date(this.year, this.month, 1).getDay();
            if(numberWeek == 0) numberWeek = 7;
            for(var i = 0, j = 1; i <= 7 - numberWeek; i++, j++ ){
                row[i] = j;
            }		
            return row;
        },
        rows(){
            var row = [];
            var lastrow = 42 - (this.previouslyDays.length + this.startDays.length);
            var day = new Date(this.year, this.month + 1, 0).getDate() - (this.startDays.length - 1);
            var start = this.startDays.length;
            for(var i = 0, j = start + 1; i < day - 1; i++, j++ ){
                row[i] = j;
            }
            return row;
        },
        nextrows() {
            var row = [[],[]];
            var lastrow = 42 - (this.rows.length + this.previouslyDays.length + this.startDays.length);
            if(lastrow >= 7){
                for (var i = 6, j = lastrow; i >= 0; i--, j--) {
                    row[0][i] = j;
                }
                for (var i = row[0][0] - 2, j = row[0][0] - 1; i >= 0; i--, j--) {
                    row[1][i] = j;
                }
            } else {
                for(let i = 0, j = 1; i < lastrow; i++, j++){
                    row[0][i] = j;
                }
            }
            return row;
        }
    }
}
</script>

<style>
#lable {
    padding: 0; 
    padding-bottom: 10px; 
    padding-top: 10px
}
.head {
    background-color: #32383e;
}

 .cell:hover {
	background-color: #FB7777;
    
}
.cell{
	cursor: pointer;
}

.anothermonth{
	cursor: default;
	background-color: #1A1D20;
}

.row.h{
	text-align: center; 
	margin-top: 50px;
}

table {
	text-align: center;
}

</style>
