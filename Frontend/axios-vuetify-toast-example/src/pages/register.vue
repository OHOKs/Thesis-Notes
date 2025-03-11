<script>
import axios from 'axios';

export default {
  data() {
    return {
      username: null,
      email: null,
      name: null,
      password: null,
      passwordConf: null,
    };
  },
  inject: ['toast'],
  methods: {
    async register() {
      try {
        const response = await axios.post(`http://localhost:5000/api/register`, {
          email: this.username,
          password: this.password,
          username: this.username,
          name: this.password,
        }
        );

        if (response.status == 201) {
          this.toast.triggerToast('Sikeres regisztráció!', 'success');
          setTimeout(() => {
            this.$router.push("/login");
          }, 1000);
        }
      } catch (error) {
        console.log(error)
        this.toast.triggerToast("Hiba a regisztráció során!", "error");
      }
    },
  },
};
</script>

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
        <label for="inputEmail" class="col-sm-2 col-form-label">
          Email Address
        </label>
        <div class="col-sm-10">
          <input type="email" class="form-control" id="inputEmail" placeholder="Email Address" v-model="email" />
        </div>
      </div>
      <div class="form-group row">
        <label for="inputName" class="col-sm-2 col-form-label"> Name </label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="inputName" placeholder="Name" v-model="name" />
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
      <div class="form-group row">
        <label for="inputPassword2" class="col-sm-2 col-form-label">
          Password Confirmation
        </label>
        <div class="col-sm-10">
          <input type="password" class="form-control" id="inputPassword2" placeholder="Password Confirmation"
            v-model="passwordConf" />
        </div>
      </div>
      <button type="button" class="btn btn-primary" @click="register()">
        Register
      </button>
      <a><router-link to="/login">Not registered yet? Register here!</router-link></a>
    </form>
  </div>

</template>

<style>
.background {
  background-image: url("../../public/bg.jpg");
  background-size: cover;
  background-repeat: no-repeat;
}
</style>
