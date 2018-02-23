<template>
<div>
  <div class="row" v-if="load">
    <div id="loading">
      <ul class="bokeh">
        <li></li>
        <li></li>
        <li></li>
      </ul>
    </div>
  </div>
    <table class="table">
        <thead>
          <tr class="filters">
            <th><input type="text" class="form-control" placeholder="№" disabled></th>
            <th class="hidden-sm hidden-xs"><input type="text" class="form-control" placeholder="Ф.И.О" v-model="searchName" v-on:keyup="filterByName(searchName)"></th>
            <th><input type="text" class="form-control" placeholder="Пол"  v-model="searchGender" v-on:keyup="filterByGender"></th>
            <th><input type="text" class="form-control" placeholder="Дата регистрации" disabled></th>
          </tr>
        </thead>
      <tbody>
          <tr v-for="(user, index) in filterUsers" :key="index">
            <td>{{index + 1}}</td>
            <td> <router-link :to="'/profile/' + user.id"> {{user.name}} {{user.surename}}</router-link></td>
            <td>{{user.gender[0]}}</td>
            <td>{{validDate(user.register_date)}}</td>
            <button class="btn btn-success">Ред</button>
          </tr>
        </tbody>
      </table>
       <div class="panel-footer" style="top: 5px; padding-bottom: -5;">
        <div class="row">
            <div class="col col-xs-8">
                <ul class="pagination hidden-xs pull-right">
                    <li><a href="#">1</a></li>
                </ul>
                <ul class="pagination visible-xs pull-right">
                    <li><a href="#">«</a></li>
                    <li><a href="#">»</a></li>
                </ul>
            </div>
        </div>
    </div>
    </div>

</template>

<script>
export default {
  data(){
    return {
      load: true,
      users: [],
      searchName: '',
      searchGender: '',
      filterUsers: []
    }
  },
  methods:{
    validDate(date){
      let options = {
        year: 'numeric',
        month: 'numeric',
        day: 'numeric',
      };
      let mill = Date.parse(date);
      let dt = new Date;
      dt.setTime(mill);
      return dt.toLocaleString("ru", options);
      },
    filterByName(){
        if(!this.searchName || this.filterUsers.length < 1){
          this.filterAll();
        }else{
          let str = new RegExp(this.searchName.toLowerCase());
          let arr = [];
          arr = this.filterUsers.filter((item, i)=>{
              let name = `${item.name.toLowerCase()} ${item.surename.toLowerCase()}`;
              return str.test(name);
            });
          this.filterUsers = arr;
        }
    },
    filterByGender(){
      if(!this.searchGender){
          this.filterAll();
      }else{
        let arr = [];
        arr = this.filterUsers.filter((item, i)=>{
            let name = item['gender'].toLowerCase();
            return name == this.searchGender.toLowerCase();
          });
        this.filterUsers = arr;
      }
  },
  filterAll(){
    this.filterUsers = this.users;
    if(this.searchGender)this.filterByGender();
    if(this.searchName)this.filterByName();
  }
  },
  created(){
    fetch(this.$store.state.url + '/api/users')
      .then((res)=>{
        res.json().then(data=>{
          this.users = data.reverse();
          this.filterUsers = this.users;
          this.load = false;
        })
      })
  }
}
</script>

<style>

</style>
