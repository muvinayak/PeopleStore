import { createMemoryHistory, createRouter } from 'vue-router';
import Products from './components/Products.vue'
import MyAccount from './components/MyAccount.vue'
import Home from './components/Home.vue'
import AddProduct from './components/AddProduct.vue'
import MyCart from './components/MyCart.vue'

const routes = [
    { path: '/', name: 'home', component: Home },
    { path: '/products/:id', name: 'products', component: Products, props: true },
    { path: '/myAccount', name: 'account', component: MyAccount },
    { path: '/myCart', name: 'cart', component: MyCart },
    { path: '/addProduct', name: 'addProduct', component: AddProduct }
]

const router = createRouter({
    linkActiveClass: 'active',
    linkExactActiveClass: 'fw-bolder',
    history: createMemoryHistory(),
    routes
})

export default router