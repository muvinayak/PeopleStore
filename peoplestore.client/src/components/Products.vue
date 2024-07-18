<script setup>
    import { useCategoriesStore } from '@/store/categories'
    import { ref, watch } from 'vue'
    import axios from 'axios'
    import { storeToRefs } from 'pinia'
    import { useCartStore } from '../store/cart'

    const categoriesStore = useCategoriesStore()
    const cartStore = useCartStore()
    const { selectedCategoryId, selectedCategoryName } = storeToRefs(categoriesStore)
    const products = ref([])

    const GetProductsByCategory = async () => {
        await axios.get(`https://localhost:7071/api/Products/GetProductsByCatgory/${selectedCategoryId.value}`)
            .then((response) => {
                products.value = response.data
            })
            .catch((error) => {
                console.log(error)
            })
    }

    function AddProductToCart(product) {
        var addedItem = {
            "id": product.id, "name": product.name, "description": product.description,
             "quantity": product.quantity, "count": 1, "unitPrice": product.unitPrice}
        cartStore.AddProductToCart(addedItem)
    }

    GetProductsByCategory()

    watch(selectedCategoryId, () => {

        GetProductsByCategory()
    })

</script>
<template>
    <div class="mt-4 mb-3 text-center fs-3" >Products for {{ selectedCategoryName }}</div>

    <table class="table">
        <thead>
            <tr>
                <th scope="col">Product</th>
                <th scope="col">Description</th>
                <th scope="col">Price</th>
                <th scope="col">AddToCart</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="product in products" :key="product.id">
                <td>{{product.name}}</td>
                <td>{{product.description}}</td>
                <td>{{product.unitPrice}}</td>
                <td><button type="button" class="btn btn-outline-primary" @click="AddProductToCart(product)">Add To Cart</button></td>
            </tr>
        </tbody>
    </table>

    <div class="mt-4 mb-3 text-center fs-3"><a class="btn btn-outline-primary" href="#/addProduct" @click="AddNewProduct">Add new product</a></div>


</template>

<style>
    .button-color {
        background-color: #e3f2fd;
    }
</style>