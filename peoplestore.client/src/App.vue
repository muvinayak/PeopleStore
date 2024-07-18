<script setup>
import Products from './components/Products.vue'
import MyAccount from './components/MyAccount.vue'
import NavBar from './components/NavBar.vue'
import Home from './components/Home.vue'
import AddProduct from './components/AddProduct.vue'
import MyCart from './components/MyCart.vue'
import NotFound from './components/NotFound.vue'
import { computed, ref } from 'vue'

const routes = {
    '/' : Home,
    '/products' : Products,
    '/myAccount' : MyAccount,
    '/cart' : MyCart,
    '/addProduct' : AddProduct
}

const currentPath = ref(window.location.hash)

window.addEventListener('hashchange', () => {
    currentPath.value = window.location.hash
})

    const currentTab = computed(() => {
    return routes[currentPath.value.slice(1) || '/'] || NotFound
})

</script>

<template>
    <header>
        <NavBar :active-tab="Home" />
    </header>

    <main>
        <Suspense>
            <component :is="currentTab" />
        </Suspense>
    </main>
</template>

<style scoped>
    header {
        line-height: 2;
    }

</style>
