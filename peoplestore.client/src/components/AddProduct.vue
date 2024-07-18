<template>
    <div class="mt-4 fs-3 text-center">Add Product</div>

    <div v-if="isUserLoggedIn">
        <form class="mt-4" @submit.prevent="addNewProduct">
            <div class="form-group row mb-3">
                <label for="name" class="col-sm-2 col-form-label">Product Name</label>
                <div class="col-sm-10">
                    <input type="text" v-model="name" class="form-control" id="name" placeholder="Enter product name" />
                </div>
            </div>
            <div class="form-group row mb-3">
                <label for="description" class="col-sm-2 col-form-label">Product Desciption</label>
                <div class="col-sm-10">
                    <input type="text" v-model="description" class="form-control" id="description" placeholder="Enter product description" />
                </div>
            </div>
            <div class="form-group row mb-3">
                <label for="unitPrice" class="col-sm-2 col-form-label">Unit Price</label>
                <div class="col-sm-10">
                    <input type="number" step="0.01" v-model="unitPrice" class="form-control" id="unitPrice" placeholder="Enter Products Unit Price">
                </div>
            </div>
            <div class="form-group row mb-3">
                <label for="quantity" class="col-sm-2 col-form-label">Quantity</label>
                <div class="col-sm-10">
                    <input type="number" v-model="quantity" class="form-control" id="quantity" placeholder="Enter Quantity of Product">
                </div>
            </div>
            <div class="form-group row mb-3 mt-2">
                <div class="col-sm-10 ">
                    <button type="submit" class="btn btn-outline-primary">Submit</button>
                </div>
            </div>
        </form>
    </div>
    <div v-else class="mt-4 text-center alert alert-danger">
        Error : Please log in to add new product
    </div>
</template>


<script setup>
    import { useUserLoginStore } from '@/store/userLogin'
    import { storeToRefs } from 'pinia'
    import { ref } from 'vue'
    import { useCategoriesStore } from '../store/categories'
    import axios from 'axios'

    const userLoginStore = useUserLoginStore()
    const categoriesStore = useCategoriesStore()

    const { accessToken, isUserLoggedIn } = storeToRefs(userLoginStore)
    const { selectedCategoryId } = storeToRefs(categoriesStore)

    const name = ref('')
    const description = ref('')
    const unitPrice = ref(0)
    const quantity = ref(0)

    async function addNewProduct() {
        var product = {
            "name": name.value,
            "description": description.value,
            "categoryId": selectedCategoryId.value,
            "unitPrice": unitPrice.value,
            "quantity": quantity.value
        }

        try {
            var response = await axios.post('https://localhost:7071/api/Products', product, {
                headers: {
                    Authorization: 'Bearer ' + accessToken.value
                }
            })

            name.value = ''
            description.value = ''
            unitPrice.value = 0
            quantity.value = 0
        } catch (error) {
            alert('error')
        }

    }
</script>


