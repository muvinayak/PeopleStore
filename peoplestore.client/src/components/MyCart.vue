<template>

    <h3 class="mt-4 mb-3">My Cart</h3>

    <table class="table">
        <thead>
            <tr>
                <th scope="col">Product</th>
                <th scope="col">Description</th>
                <th scope="col">Price</th>
                <th scope="col">Purchase Quantity</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="product in products" :key="product.id">
                <td>{{product.name}}</td>
                <td>{{product.description}}</td>
                <td>{{(product.unitPrice * product.count).toFixed(2)}}</td>
                <td>{{product.count}}</td>
            </tr>
        </tbody>
    </table>


</template>

<script setup>
    import { useCartStore } from "../store/cart";
    import { storeToRefs } from "pinia";

    const cartStore = useCartStore()
    const { products } = storeToRefs(cartStore)

</script>