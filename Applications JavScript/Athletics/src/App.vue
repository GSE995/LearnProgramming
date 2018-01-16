<template>
<div>
  <Headr></Headr>
  <router-view></router-view>
  <Foot></Foot>
</div>
</template>

<script>
import Headr from './components/Header/Header.vue'
import Foot from './components/Footer/Footer.vue'
export default {
  name: 'app',
  components: {
    Headr,
    Foot
  }
}
</script>

<style>

body {
  background-color:#eee;
}

h2 {
  font-family:sans-serif;
  text-align: center;
  color: #7D7D7D;
  text-decoration-line: none;
  padding-top: 0;
  margin-bottom: 20px;
}
p {
  font-family: 'Roboto', sans-serif;
}
span {
  font-family: 'Roboto', sans-serif;
}
a{
  font-family: 'Roboto', sans-serif;
}

h3{
  text-align: center
}

.badge.distance{
  background-color: #7986cb;
}

/* loader */

.animationload {
    background-color: #fff;
    height: 100%;
    left: 0;
    position: fixed;
    top: 0;
    width: 100%;
    z-index: 10000;
}
.osahanloading {
    animation: 1.5s linear 0s normal none infinite running osahanloading;
    background: #fed37f none repeat scroll 0 0;
    border-radius: 50px;
    height: 50px;
    left: 50%;
    margin-left: -25px;
    margin-top: -25px;
    position: absolute;
    top: 50%;
    width: 50px;
}
.osahanloading::after {
    animation: 1.5s linear 0s normal none infinite running osahanloading_after;
    border-color: #85d6de transparent;
    border-radius: 80px;
    border-style: solid;
    border-width: 10px;
    content: "";
    height: 80px;
    left: -15px;
    position: absolute;
    top: -15px;
    width: 80px;
}
@keyframes osahanloading {
0% {
    transform: rotate(0deg);
}
50% {
    background: #85d6de none repeat scroll 0 0;
    transform: rotate(180deg);
}
100% {
    transform: rotate(360deg);
}
}

/* loader */
</style>
