<template>
  <div class="container">
    <div class="row" style="margin-top: 100px; margin-bottom: 30px">
     <router-link :to="'/admin/request'"><button class="btn btn-info">  Заявки </button></router-link>
      <router-link :to="'/admin/events'"><button class="btn btn-info">Мероприятия</button></router-link>
       <router-link :to="'/admin/users'"><button class="btn btn-info">  Пользователи</button> </router-link>
    </div>
     <router-view></router-view>
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>

</style>
