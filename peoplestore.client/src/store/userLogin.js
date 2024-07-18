import axios from 'axios'
import { defineStore } from 'pinia'
import { computed, ref } from 'vue'

export const useUserLoginStore = defineStore('userLogin', () => {
    const accessToken = ref('')
    const refreshToken = ref('')
    const createdAt = ref('')
    const userName = ref('')

    const isUserLoggedIn = computed(() => accessToken.value !== '')

    async function login(requestObj) {
        try {
            const response = await axios.post('https://localhost:7071/login?useCookies=false', requestObj)
            const responseData = response.data
            accessToken.value = responseData.accessToken
            refreshToken.value = responseData.refreshToken
            createdAt.value = new Date().toUTCString()
            userName.value = requestObj.email
        } catch (error) {
            console.log(error)
        }
    }

    async function logout() {
        try {
            const response = await axios.post('https://localhost:7071/api/Logout', {}, {
                headers: {
                    Authorization: 'Bearer ' + accessToken.value
                }
            })
            accessToken.value = ''
            refreshToken.value = ''
            createdAt.value = ''
            userName.value = ''
        }
        catch (err) {
            console.log(err)
        }
    }

    return { isUserLoggedIn, accessToken, login, logout, refreshToken, userName }
})