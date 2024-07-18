<template>
    <h3 class="mt-4">Registration</h3>
    <form class="mt-4" @submit.prevent="registerUser">
        <div class="form-group row mb-3">
            <label for="registrationUserEmail" class="col-sm-2 col-form-label">Email address</label>
            <div class="col-sm-10">
                <input type="email" v-model="registrationEmail" class="form-control" id="registrationUserEmail" placeholder="Enter email address" />
            </div>
        </div>
        <div class="form-group row mb-3">
            <label for="registrationUserPassword" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-10">
                <input type="password" v-model="registrationPassWord" class="form-control" id="registrationUserPassword" placeholder="Enter Password">
            </div>
        </div>
        <div class="form-group row mb-3 mt-2">
            <div class="col-sm-10 ">
                <button type="submit" class="btn btn-primary" @click="">Register</button>
            </div>
        </div>
    </form> 
</template>

<script setup>
    import { ref } from 'vue'
    import axios from 'axios'

    const registrationEmail = ref('')
    const registrationPassWord = ref('')

    async function registerUser() {
        try {
            const requestObject = { "email": registrationEmail.value, "password": registrationPassWord.value}
            const response = await axios.post("https://localhost:7071/register", requestObject)
            alert('Registration Successful please login')
        } catch {
            alert('Registration Failed')
        }
    }

</script>