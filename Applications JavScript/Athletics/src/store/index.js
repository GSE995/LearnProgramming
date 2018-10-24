import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const store = new Vuex.Store({
  state: {
    // url: 'http://localhost:3000',
    url: 'https://athleticsapps.azurewebsites.net',
    src_userimg: '/src/pic/',
    src_eventimg: '/src/pic/'
  }
})

export default store
