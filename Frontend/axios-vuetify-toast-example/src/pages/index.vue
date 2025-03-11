<template>
    <v-container>
        <v-data-table v-if="products.length" :headers="headers" :items="products" item-key="id">
            <template v-slot:item.actions="{ item }">
                <v-btn color="primary" @click="openEditDialog(item)">
                    Edit
                </v-btn>
            </template>
        </v-data-table>

        <edit-dialog v-model="dialog" :product="selectedProduct" @update="updateProduct" />
    </v-container>
</template>

<script>
import axios from 'axios';
import EditDialog from '../components/Dialog.vue';

export default {
    components: {
        EditDialog
    },
    data() {
        return {
            products: [],
            headers: [
                { title: 'ID', align: 'start', key: 'id' },
                { title: 'Name', align: 'start', key: 'name' },
                { title: 'Description', align: 'start', key: 'description' },
                { title: 'Price', align: 'start', key: 'price' },
                { title: 'Stock', align: 'start', key: 'stock' },
                { title: 'Actions', align: 'center', key: 'actions' }
            ],
            dialog: false,
            selectedProduct: null
        };
    },
    mounted() {
        this.fetchProducts();
    },
    inject: ['toast'],
    methods: {
        async fetchProducts() {
            try {
                const response = await axios.get('http://localhost:5000/api/products');
                this.products = response.data;
            } catch (error) {
                console.error('Error fetching products:', error);
            }
        },
        openEditDialog(product) {
            this.selectedProduct = { ...product };
            this.dialog = true;
        },
        async updateProduct(updatedProduct) {
            try {
                const response = await axios.put(
                    `http://localhost:5000/api/products/${updatedProduct.id}`,
                    {
                        name: updatedProduct.name,
                        price: updatedProduct.price
                    }
                );

                if (response.status === 200) {
                    this.fetchProducts();
                    this.toast.triggerToast("A termék módosítása sikeres!", "success");
                    this.dialog = false;
                }
            } catch (error) {
                this.toast.triggerToast("A termék módosítása sikertelen!", "error");
            }
        }
    }
};
</script>

<style scoped>
* {
    color: white;
}
</style>