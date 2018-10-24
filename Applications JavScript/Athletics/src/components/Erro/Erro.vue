<template>
  <div style="padding-top: 100px; padding-bottom: 100px">
    <h2 v-if="this.$route.params.status">Упс... не удалось загрузить данные данные</h2>
    <h2 v-if="!this.$route.params.status">Страница не найдена</h2>
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
  h2{
    text-align:  center
  }

</style>
