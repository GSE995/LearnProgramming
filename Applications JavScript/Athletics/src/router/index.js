import Vue from 'vue'
import Router from 'vue-router'
import Home from '../components/Home/Home.vue'
import Profile from '../components/Users/Profile.vue'
import EventsPage from '../components/Event/EventsPage.vue'
import Event from '../components/Event/Event.vue'
import App from '../App.vue'
import EventsTable from '../components/AdminTool/EventsTable.vue'
import AdminTool from '../components/AdminTool/AdminTools.vue'
import RequestTable from '../components/AdminTool/RequestTable.vue'
import UsersTable from '../components/AdminTool/UsersTable.vue'
import ReitingDesc from '../components/Reiting/ReitingDesc.vue'
import CreateEvent from '../components/Event/CreateEvent.vue'


Vue.use(Router)

export default new Router({
  history: true,
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/events/:sport/page/:id',
      name: 'Events',
      component: EventsPage
    },
    {
      path: '/profile/:id',
      name: 'Profile',
      component: Profile
    },
    {
      path: '/event/:id',
      name: 'Event',
      component: Event
    },
    {
      path: '/reiting',
      name: 'Reiting',
      component: ReitingDesc

    },
    {
      path: '/admin',
      name: 'Admin',
      component: AdminTool,
      children:[
        {
          path: 'events',
          component: EventsTable
        },
        {
          path: 'request',
          component: RequestTable
        },
        {
          path: 'users',
          component: UsersTable
        }
      ]

    },
    {
      path: '/create',
      name: 'CreateEvent',
      component: CreateEvent
    }

  ]
})
