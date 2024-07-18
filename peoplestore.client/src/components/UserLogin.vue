<template>
    <div class="mt-4 fs-3">Login</div>
        <form class="mt-4" @submit.prevent="handleSignIn">
            <div class="form-group row mb-3">
                <label for="userEmail" class="col-sm-2 col-form-label">Email address</label>
                <div class="col-sm-10">
                    <input type="email" v-model="userEmail" class="form-control" id="userEmail" placeholder="Enter email address" />
                </div>
            </div>
            <div class="form-group row mb-3">
                <label for="userPassword" class="col-sm-2 col-form-label">Password</label>
                <div class="col-sm-10">
                    <input type="password" v-model="userPassword" class="form-control" id="userPassword" placeholder="Enter Password">
                </div>
            </div>
            <div class="form-group row mb-3 mt-2">
                <div class="col-sm-10 ">
                    <button type="submit" class="btn btn-primary">Login</button>
                </div>
            </div>
        </form>
</template>

<script setup>

    import { ref } from 'vue'
    import { useUserLoginStore } from '@/store/userLogin'

    const store = useUserLoginStore()

    const userEmail = ref('')
    const userPassword = ref('')

    async function handleSignIn() {
        const requestObj = {
            "email": userEmail.value,
            "password": userPassword.value
        }
        try {
            await store.login(requestObj)
        }
        catch {

        } 
    }

</script>