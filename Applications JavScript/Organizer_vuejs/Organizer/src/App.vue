<template>
  <div class="container">
    <span v-if="signComplite" id="user">{{email}} </span>
    <div v-if="!signComplite">
      <button class="btn" @click="signInShow">Войти</button>
      <button class="btn" @click="signUpShow">Зарегистрироваться</button>
      <SignUp v-show="checkUp" @registerSuccess="compliteUp"></SignUp>
      <SignIn v-show="checkIn" @addUser="signComplite = $event.complete, email = $event.email, uid = $event.uid"></SignIn>
      <div v-if="up" class="alert alert-success col-8" role="alert">Регистрация успешно пройдена!</div>
    </div>
    <Calendar :uid="uid" :complite="signComplite"></Calendar>
  </div>
</template>

<script>
  import Calendar from './components/Calendar.vue'
  import SignUp from './components/SignUp.vue'
  import SignIn from './components/SignIn.vue'
  export default{
      components:{
        Calendar,
        SignUp,
        SignIn
      },
      data: function(){
        return {
        checkIn: false,
        checkUp: false,
        up: false,
        signComplite: false,
        email: '',
        uid: ''
      }
      },
      methods:{
        signInShow(){
          this.up = false;
          this.checkUp = false;
          this.checkIn = !this.checkIn;
        },
        signUpShow(){
          this.checkIn = false;
          this.checkUp = !this.checkUp;
        },
        compliteUp(status){
          this.checkUp = status;
          this.up = !status;
        },
        compliteIn(sett){
          this.signComplite = sett.complete, 
          this.email = sett.email, 
          this.uid = sett.uid
        }
    }
  }

</script>

<style>
body{
    font-family: Arial, Verdana, sans-serif;
}
</style>
