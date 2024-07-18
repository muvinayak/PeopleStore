import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useCartStore = defineStore('cart', () => {
    const products = ref([])

    function AddProductToCart(inputProduct) {
        var foundProduct = products.value.find((prod) => prod.id === inputProduct.id)
        if (foundProduct) {
            if (foundProduct.count == inputProduct.quantity) {
                alert('You have reached the maximum amount available')
            }
            else
                foundProduct.count++;
        }
        else {
            products.value.push(inputProduct)
        }
    }

    return { products, AddProductToCart }
})