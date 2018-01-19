<template>
    <div class="navbar navbar-default navbar-fixed-top" id="Head">
        <div class="container">
            <div class="navbar-header">
                <!-- Сокращеный список при маленьком разрешении -->
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#responsive-menu">
                    <span class="sr-only">Open navigation</span>
                    <span class="icon-bar"> </span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <router-link to="/"><img src="/src/pic/logo-inverse.png"></router-link>
            </div>
            <div class="collapse navbar-collapse " id="responsive-menu">
                <ul class="nav navbar-nav">
                    <li class="dropdown header"> <router-link :to="'/reiting'"> <a style="color: #383838"> <b>Рейтинг результатов</b></a> </router-link></li>
                    <li class="dropdown header"><a style="color: #383838; size: 20px" class="dropdown-toggle" data-toggle="dropdown" href=""> <b> Календарь соревнований</b><b class="caret">  </b>
                        </a>
                        <ul  class="dropdown-menu">
                            <li><router-link :to="'/events/runs/page/' + 1">Беговые</router-link></li>
                            <li class="divider">  </li>
                            <li><a><s>Плавание на открытой воде</s></a></li>
                            <li class="divider">  </li>
                            <li><a> <s> Веломарафоны </s></a></li>
                            <li class="divider">  </li>
                            <li><a><s>Беговые лыжи</s></a></li>
                            <li class="divider">  </li>
                            <li><a><s>Триатлон</s></a></li>
                        </ul>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a data-toggle="modal" data-target="#modal-1" style="padding-bottom: 0px;">
                      </a></li>
                    <li class="dropdown header">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="color: #383838"><b>Вход</b></a>
                      <ul id="login-dp" class="dropdown-menu pop">
                        <li>
                          <SignIn></SignIn>
                        </li>
                      </ul>
                    </li>
                    <!-- <li class="dropdown header">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="color: #383838"> <b>Регистрация</b></a>
                      <ul id="login-dp" class="dropdown-menu pop">
                        <li>
                          <SignUp></SignUp>
                        </li>
                      </ul>
                    </li> -->
                    <li class="dropdown header">
                     <router-link :to="'/admin'"> <a href="#" class="dropdown-toggle" style="color: #383838"> <b>Админка</b></a></router-link>
                    </li>
                    <!-- <li>
                        <router-link :to="'/profile/' + user.id" style="padding: 0; margin:0">
                            <img src="/src/pic/NasL1_croper_ru.jpeg" style=" border-radius: 100; height: 45px; width: 45px" >
                        </router-link>
                    </li> -->
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
import SignIn from '../SignIn/SignIn.vue'
import SignUp from '../SignIn/Signup.vue'

export default {
    components:{
        SignIn,
        SignUp
    },
    data(){
        return {
            user:{
                id: 1
            }
        }
    }
}
</script>

<style>
#avatar > a{
    padding-top: 0;
    padding-bottom: 0
}
    #Head {
  margin-bottom: 0; background-color: #26a69a;
  border-color: #26a69a;
  border-radius: 0;
  box-shadow: 0 10px 20px rgba(0,0,0,0.19), 0 6px 6px rgba(0,0,0,0.23);
}
</style>
