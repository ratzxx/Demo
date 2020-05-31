<template>
  <div class="container">
    <b-button variant="primary" :to="{ name: 'users'}" class="mr-1 mb-2">Back to users</b-button>
    <b-card
      header="New User"
      border-variant="primary"
      header-bg-variant="primary"
      header-text-variant="white"
    >
      <User v-bind:user="user" />
      <b-button type="button" variant="primary" @click="onCreate()">Create</b-button>
    </b-card>
  </div>
</template>

<script>
import User from "@/components/User";
import UserService from "@/services/UserService";
import ToastService from "@/services/ToastService";

export default {
  data() {
    return {
      user: {}
    };
  },

  methods: {
    onCreate() {
      UserService.createUser(this.user)
        .then(() => {
          ToastService.makeToast("User created!", "success");
          this.$router.push("/");
        })
        .catch(() => ToastService.makeToast("Create user error", "warning"));
    }
  },

  components: {
    User
  }
};
</script>