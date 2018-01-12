<template>
  <div class="container footer" id="foot">
    <div class="col-lg-4 col-md-4 col-xs-8" id="social">
        <p>Мы в социальных сетях</p>
        <i class="fa fa-twitter fa-2x" aria-hidden="true"></i>
        <i class="fa fa-odnoklassniki fa-2x" aria-hidden="true"></i>
        <i class="fa fa-facebook fa-2x" aria-hidden="true"></i>
        <i class="fa fa-vk fa-2x" aria-hidden="true"></i>
    </div>
    <div class="col-lg-4 col-md-4 col-xs-4" id="logo">
      <router-link to="/" class="logo"  ><img src="/src/pic/Untitled-1.png" alt="лого"></router-link>
    </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>
    #social > i{
        padding-right: 5px;
        color: #DEDEDE
    }

    #social > p{
      color:#DEDEDE
    }

    #socia{
      padding-top: 10px;
      padding-left: 0%
    }

    .container.footer {
      margin-top: 10px;
      box-shadow:0 0 15px rgba(0,0,0,0.3);
      text-align: center;
    }

    #foot{
      padding-bottom: 10px;
      background-color: #37474f
    }

</style>
