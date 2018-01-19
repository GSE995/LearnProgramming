<template>
<div>
    <table class="table">
        <thead>
          <tr class="filters">
            <th><input type="text" class="form-control" placeholder="№"></th>
            <th class="hidden-sm hidden-xs"><input type="text" class="form-control" placeholder="Ф.И.О" disabled></th>
            <th><input type="text" class="form-control" placeholder="Пол" disabled></th>
            <th><input type="text" class="form-control" placeholder="Дата регистрации" disabled></th>
          </tr>
        </thead>
      <tbody>
          <tr v-for="(user, index) in users" :key="index">
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
      users: [],
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
      }
  },
  created(){
    fetch(this.$store.state.url + '/api/users')
      .then((res)=>{
        res.json().then(data=>{
          console.log(data);
          this.users = data.reverse();
        })
      })
  }
}
</script>

<style>

</style>
