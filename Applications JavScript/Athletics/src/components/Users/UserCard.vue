<template>
    <div class="col-lg-3 col-xs-6 col-sm-4 col-md-3">
            <div class="minicard">
                 <router-link :to="'/profile/' + user.id">
                <div class="avatar">
                    <img :src="this.$store.state.src_userimg + user.poster" alt="" />
                </div>
                </router-link>
                <div class="content">
                    <p>{{user.name}} {{user.surename}}</p>
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
}
</script>

<style>
/*  */
.src-image {
  display: none;
}

.minicard {
  overflow: hidden;
  position: relative;
  border-radius: 0;
  text-align: center;
  padding: 0;
  text-decoration: none;
  margin-bottom: 40px
}
.minicard .header-bg {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 70px;
  z-index: 1;
}
.minicard .avatar {
  position: relative;
  margin-top: 15px;
  z-index: 100;
  margin-bottom: 8px
}

.minicard .avatar img {
  width: 100px;
  height: 100px;
  -webkit-border-radius: 50%;
  -moz-border-radius: 50%;
  border-radius: 50%;
}


</style>
