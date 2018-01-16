<template>
  <div>
    <button class="btn btn-default">На рассмотрении</button>
    <button class="btn btn-default">Одобренные</button>
    <table class="table">
        <thead>
          <tr class="filters">
            <th><input type="text" class="form-control" placeholder="№"></th>
            <th class="hidden-sm hidden-xs"><input type="text" class="form-control" placeholder="Мероприятие" disabled></th>
            <th><input type="text" class="form-control" placeholder="Дистанция" disabled></th>
            <th><input type="text" class="form-control" placeholder="Время" disabled></th>
            <th><input type="text" class="form-control" placeholder="Имя" disabled></th>
            <th><input type="text" class="form-control" placeholder="Пользователь" disabled></th>
            <th><input type="text" class="form-control" placeholder="Дата создания" disabled></th>
          </tr>
        </thead>
      <tbody>
          <tr v-for="(req, index) in filtereq" :key="index">
            <td>{{index + 1}}</td>
            <td>{{req.result_id}}</td>
            <td>{{req.user_id}}</td>
            <td>{{1}}</td>
            <td>{{1}}</td>
            <td>{{1}}</td>
            <td>{{1}}</td>
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
      request: [],
      users: [],
      events: [],
      filtereq:[]
    }
  },
  methods:{
    getUser(id){
      let user = [];
      fetch(this.$store.state.url + '/api/users/' + id)
		        .then((res)=>{
		        	res.json().then(data =>{
                user[0] = data;
		        	})
		        })
		        .catch(()=>{
		        })
      return user;
    },
    getEvent(id){
      let event  = [];
      fetch(this.$store.state.url + '/api/event/' + id)
		      .then((res)=>{
		        res.json().then(data =>{
              event[0] = data;
		        })
		      })
          .catch(()=>{})
      return event;
    },
    getResult(id){
      let result = [];
       fetch(this.$store.state.url + '/api/results/' + id)
          .then((res)=>{
            res.json().then(data=>{
                result[0] = data;
            })
          })
          .catch(err=>{
            console.log(err);
          })
      return result;
    },
    validRequests(){
        for(let i = 0; i < this.request.length; i++){
          this.request[i]['user'] = this.getUser(this.request[i].user_id);
          this.request[i]["result"] = this.getResult(this.request[i].result_id);
          this.request[i]['event'] = this.getEvent(this.request[i].result[0].event_id);
        }
    },
    filterRequest(status){
      for(let i = 0; i < this.request.length; i++){
        if(this.request[i].status == status){
          this.filterreq.push(this.request[i]);
        }
      }
    }
  },
  created(){

     fetch(this.$store.state.url + '/api/admin/request')
          .then((res)=>{
            res.json().then(data=>{
                this.request = data;
                this.validRequests();
                this.filtereq = this.request;
                console.log(this.filtereq);
                })
          })
          .catch(err=>{
            console.log(err);
          })

  }

}
</script>

<style>

</style>
