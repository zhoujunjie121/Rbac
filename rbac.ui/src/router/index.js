import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/Menutree',
    name: 'Menutree',
    component: () => import('../views/Role/Menutree.vue')
  },
  {
    path: '/admincreate',
    name: 'admincreate',
    component: () => import('../views/Admin/admincreate.vue')
  },
  {
    path: '/',
    name: 'login',
    component: () => import('../views/login.vue')
  },
  {
    path: '/MenuUpd',
    name: 'MenuUpd',
    component: () => import('../views/Menu/MenuUpd.vue')
  },
  {
    path: '/MenuCreate',
    name: 'MenuCreate',
    component: () => import('../views/Menu/MenuCreate.vue')
  },
 
  {
    path: '/home',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    component: () => import('../views/AboutView.vue'),
    children:[{
      path: '/Menulist',
      name: 'Menulist',
      component: () => import('../views/Menu/Menulist.vue')
    },
    {
      path: '/adminlist',
      name: 'adminlist',
      component: () => import('../views/Admin/adminlist.vue')
    },
    {
      path: '/Rolelist',
      name: 'Rolelist',
      component: () => import('../views/Role/Rolelist.vue')
    }
  ]
  }
]

const router = new VueRouter({
  routes
})

export default router
