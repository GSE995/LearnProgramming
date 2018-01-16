
<template>
<div>
    <table class="table">
        <thead>
          <tr class="filters">
            <th><input type="text" class="form-control" placeholder="№"></th>
            <th class="hidden-sm hidden-xs"><input type="text" class="form-control" placeholder="Название" disabled></th>
            <th><input type="text" class="form-control" placeholder="Страна" disabled></th>
            <th><input type="text" class="form-control" placeholder="Город" disabled></th>
            <th><input type="text" class="form-control" placeholder="Место" disabled></th>
            <th><input type="text" class="form-control" placeholder="Старт" disabled></th>
            <th><input type="text" class="form-control" placeholder="Дата создания" disabled></th>
            <th><input type="text" class="form-control" placeholder="Создатель" disabled></th>
          </tr>
        </thead>
      <tbody>
          <tr v-for="(event, index) in filterevets" :key="index">
            <td>{{index + 1}}</td>
            <td> <router-link :to="{name: 'Event', params: {id: event.id}}"> {{event.name}} </router-link> </td>
            <td>{{event.country}}</td>
            <td>{{event.city}}</td>
            <td>{{event.area}}</td>
            <td>{{validDate(event.start_date)}}</td>
            <td>{{validDate(event.create_date)}}</td>
            <td>{{getCreator(event.id)}}</td>
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
      events: [],
      filterevets: [],
      load: false
    }
  },
  methods:{
    getCreator(id){
      return 1;
    },
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
    fetch(this.$store.state.url + '/api/events')
		      .then((res)=>{
		        res.json().then(data =>{
              this.events = data;
              this.filterevets = data;
              this.load = true;
		        })
		      })
		.catch(()=>{})
  }
}
</script>

<style>


</style>
