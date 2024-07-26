<template>
    <div v-if="isUserLoggedIn">

        <div class="row mb-3 mt-2">
            <div class="col-sm-10">
                <h3 class="mt-4">Welcome {{userName}}</h3>
            </div>
            <div class="col-sm-10 ">
                <button type="submit" class="btn btn-primary" @click="store.logout">Logout</button>
            </div>
        </div>
    </div>
    <div v-else>
        <UserRegistration />
        <UserLogin />
    </div>

</template>

<script setup>
    import UserRegistration from './UserRegistration.vue'
    import UserLogin from './UserLogin.vue'
    import { useUserLoginStore } from '@/store/userLogin'
    import { storeToRefs } from 'pinia'

    const store = useUserLoginStore()

    const { isUserLoggedIn, userName } = storeToRefs(store)
</script>