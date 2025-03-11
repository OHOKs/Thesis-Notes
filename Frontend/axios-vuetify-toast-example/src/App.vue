<template>
  <v-app>
    <router-view />
  </v-app>

  <Toast v-if="toast.isVisible" :message="toast.message" :type=toast.type :is-visible="toast.isVisible" />
</template>

<script setup>
import { ref, provide } from 'vue';

const toast = ref({
  isVisible: false,
  message: 'This is a toast message',
  type: ''
})

function triggerToast(message, type) {
  toast.value = {
    isVisible: true,
    message,
    type
  }
  setTimeout(() => {
    toast.value = {
      isVisible: false,
      message: '',
      type: ''
    }
  }, 4000)
}

provide('toast', { triggerToast })
</script>
