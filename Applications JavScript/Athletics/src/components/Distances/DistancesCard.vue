<template>
    <div class="col-lg-12" >
        <div class="col-lg-4 col-md-6 col-xs-12 col-sm-8" v-for="dist in distances" :key="dist.id" style="padding-top: 10px; padding-bottom: 10px">
          <div style="padding-bottom: 5px"><span class="badge">{{dist.distance}}</span></div>
            <img :src="`/src/pic/${dist.map}`" width="360" height="220">
        </div>
    </div>
</template>

<script>
export default {
    props: ['distances'],
    data(){
        return {
        }
    }
}
</script>

<style>
img.zoom {
  -moz-user-select: none;
  user-select: none;
}
img.zoom:active{
  display: block;
  position: fixed;
  z-index: 10;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%); transform: translate(-50%, -50%);
  width: 1140px;
  height: 750px;
  border: solid rgba(210,210,210,.4);
  cursor: zoom-out;
}
:not(:active) > img.zoom :not(:hover), img.zoom:active {
  pointer-events: none;
}

</style>
