import Vue from 'vue'
import VueRouter from 'vue-router'
import Users from '@/views/Users'
import UserDetails from '@/views/UserDetails'
import CreateUser from '@/views/CreateUser'

Vue.use(VueRouter)

  const routes = [
    
  {
    path: '/',
    name: 'users',
    component: Users
  },
  {
    path: '/users/:id',
    name: 'user-details',
    component: UserDetails
  },
  {
    path: '/create-user',
    name: 'create-user',
    component: CreateUser
  }
  
]

const router = new VueRouter({
  routes
})

export default router
