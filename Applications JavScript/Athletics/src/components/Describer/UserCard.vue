<template>
    <div class="col-lg-2 col-xs-4 col-sm-3 col-md-2">
        <div style="padding-top: 30px; padding-bottom: 20px">
            <router-link :to="'/profile/' + user.id">
                <img class="profilFoto" :src="this.$store.state.src_userimg + user.poster"/>
            </router-link>
            <div>
                <div>{{user.name}} {{user.surename}}</div>
                <div v-for="sport in user.sports" :key="sport">{{sport}}</div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  props: ['user'],
    data(){
        return {
        }
    },
    created(){
        // поиск участинков которые добавили это мероприятия в свои планы
    }

}
</script>

<style>
    .profilFoto{
        border-radius: 100%;
        height: 80px;
        width: 80px
    }

</style>
