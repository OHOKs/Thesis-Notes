
<template>
<v-dialog v-model="visible" max-width="500px">
    <v-card>
    <v-card-title>
        <span class="headline">Edit Product</span>
    </v-card-title>
    <v-card-text>
        <v-text-field
        v-model="product.name"
        label="Product Name"
        ></v-text-field>
        <v-text-field
        v-model="product.price"
        label="Product Price"
        type="number"
        ></v-text-field>
    </v-card-text>
    <v-card-actions>
        <v-btn text @click="closeDialog">Cancel</v-btn>
        <v-btn color="primary" @click="saveChanges">Save</v-btn>
    </v-card-actions>
    </v-card>
</v-dialog>
</template>

<script>
export default {
props: ['value', 'product'],
computed: {
    visible: {
    get() {
        return this.value;
    },
    set(val) {
        this.$emit('input', val);
    }
    }
},
methods: {
    closeDialog() {
    this.visible = false;
    },
    saveChanges() {
    this.$emit('update', this.product);
    }
}
};
</script>

<style scoped>
</style>
