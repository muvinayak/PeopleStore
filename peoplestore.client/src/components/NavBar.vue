<script setup>
    import { ref } from 'vue'
    import { useCategoriesStore } from '@/store/categories'
    import { storeToRefs } from 'pinia'

    const props = defineProps(['activeTab'])
    const emit = defineEmits(['updateContent'])
    const currentActiveTab = ref(props.activeTab)
    const store = useCategoriesStore()
    const { categories } = storeToRefs(store)

    function updateActiveTab(newTab) {
        currentActiveTab.value = newTab
    }

    function showProducts(categoryId) {
        store.selectedCategoryId = categoryId
        updateActiveTab('Products')
    }

    const CategoryData = async () => {
        await store.getCategories()
    }
    CategoryData()
</script>

<template>
    <div>
        <nav class="navbar navbar-expand-lg" style="background-color: #e3f2fd;">
            <div class="container-fluid">
                <span class="navbar-brand" href="#">
                    <img src="./icons/peopleStore_logo.jpg" alt="Logo" width="40" height="30" class="d-inline-block align-text-top">
                </span>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <RouterLink class="nav-link" :to="{ name: 'home' }">Home</RouterLink>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                <span :class="{ active: currentActiveTab === 'Products'}" >Products</span>
                            </a>
                            <ul class="dropdown-menu">
                                <li v-for="category in categories" :key="category.id">
                                    <RouterLink class="nav-link" :to="{ name: 'products', params: { id:  category.id } }">{{category.name}}</RouterLink>
                                </li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <RouterLink class="nav-link" :to="{ name: 'account' }">My Account</RouterLink>
                        </li>
                        <li class="nav-item">
                            <RouterLink class="nav-link" :to="{ name: 'cart' }">
                                <img src="./icons/shopping_cart_icon.png" alt="Logo" width="40" height="30" class="d-inline-block align-text-top">
                            </RouterLink>
                        </li>

                    </ul>
                </div>

            </div>
        </nav>
    </div>
</template>