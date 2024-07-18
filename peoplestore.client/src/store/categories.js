/* import axios from "axios";

export default {
    namespaced: true,
    state: () => ({
        categoryId: 0,
        categories: []
    }),
    getters: {
        categoryName: state.categories.find(category => category.Id === categoryId).name
    },
    mutations: {
        updateCategoryId(state, newCategoryId) {
            state.categoryId = newCategoryId
        },
        setCategories(state, data) {
            state.categories = data
        },
    },
    actions: {
        getCategories({ commit }) {
            axios.get('https://localhost:7071/api/Categories')
                .then(response => {
                    commit('setCategories', response.data)
                })
                .catch(error=>console.log(error))
        }
    }
}
*/

import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import axios from 'axios';

export const useCategoriesStore = defineStore('categories', () => {
    const selectedCategoryId = ref(0)
    const categories = ref([])

    const selectedCategoryName = computed(() =>
        categories.value.find(category => category.id === selectedCategoryId.value)?.name
    )

    function $reset() {
        categories = []
        selectedCategoryId = 0
    }

    async function getCategories() {
        try {
            const res = await axios.get('https://localhost:7071/api/Categories');
            categories.value = res.data
        }
        catch(error) {
            console.log(error)
        }
    }

    return { categories, getCategories, selectedCategoryId, selectedCategoryName }
})