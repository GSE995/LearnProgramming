<template>
<div>
    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
        <img src="/src/pic/mos.png" width="120" height="120" style="border-radius: 100px">
    </div>
    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12" style="margin-top: 5px">
        <h4 style="text-align: left">
            <router-link :to="'/event/' + result.id">
            <a style="color: #4E4E4E; font-family: 'Roboto', sans-serif;"><strong>{{result.name}}</strong></a>
            </router-link>
        </h4>
        <p>26 Сентября 2016</p>
        <ul class="list-inline list-unstyled">
            <li><span class="badge" style="margin-right: 10px; background-color: #353535">{{result.distance}} км</span> </li>
            <li>|</li>
            <li><i class="fa fa-clock-o" aria-hidden="true" style="margin-right: 10px; font-size: 16px "> <strong>{{result.time}}</strong> </i> </li>
            <li>|</li>
            <li><i class="fa fa-list-ol" aria-hidden="true" style="margin-right: 10px; font-size: 16px;"> <strong>325-й из 15690</strong>  </i>  </li>
        </ul>
            Поделиться
        <span><i class="fa fa-facebook-square fa-lg" style="margin-right: 6px; margin-left: 6px"></i></span>
        <span><i class="fa fa-twitter-square fa-lg" style="margin-right: 6px;"></i></span>
        <span><i class="fa fa-vk fa-lg" style="margin-right: 6px;"></i></span>
    </div>
</div>
</template>

<script>
export default {
    props: ['result'],
    data(){
        return {

        }
    }

}
</script>

<style>

</style>
