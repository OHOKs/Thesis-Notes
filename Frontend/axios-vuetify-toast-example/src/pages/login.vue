<script>
import axios from 'axios';

export default {
  data() {
    return {
      username: null,
      password: null,
    };
  },
  inject: ['toast'],
  methods: {
    async login() {
      try {
        const response = await axios.post(`http://localhost:5000/api/login`, {
          email: this.username,
          password: this.password,
        }
        );

        if (response.status == 200) {
          this.toast.triggerToast('Sikeres bejelentkezés!', 'success');
          setTimeout(() => {
            this.$router.push("/");
          }, 1000);
        }
      } catch (error) {
        this.toast.triggerToast("Hiba a bejelentkezés során!", "error");
      }
    },
  },
};
</script>

<!-- <script setup lang="ts">
import { inject } from 'vue'
import { ToastEnum } from '@/types/toast.enum'

const { triggerToast } = inject('toast') as { triggerToast: (message: string, type: ToastEnum) => void }

triggerToast(err.message, ToastEnum.Error)
</script> -->

<template>
  <div class="vw-100 vh-100 d-flex justify-content-center align-items-center bg-light background">
    <form class="container bg-white p-5 rounded d-flex flex-column gap-3">
      <div class="form-group row">
        <label for="username" class="col-sm-2 col-form-label">Username</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="username" placeholder="Username" v-model="username" />
        </div>
      </div>
      <div class="form-group row">
        <label for="inputPassword" class="col-sm-2 col-form-label">
          Password
        </label>
        <div class="col-sm-10">
          <input type="password" class="form-control" id="inputPassword" placeholder="Password" v-model="password" />
        </div>
      </div>
      <button type="button" class="btn btn-primary" @click="login()">
        Login
      </button>
      <a><router-link to="/register">Not registered yet? Register here!</router-link></a>
    </form>
  </div>
</template>

<style scoped>
.background {
  background-image: url("../../public/bg.jpg");
  background-size: cover;
  background-repeat: no-repeat;
}
</style>
