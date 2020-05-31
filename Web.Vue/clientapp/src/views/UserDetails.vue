<template>
  <div class="container">
    <b-button variant="primary" :to="{ name: 'users'}" class="mr-1 mb-2">Back to users</b-button>
    <b-card
      header="User"
      border-variant="primary"
      header-bg-variant="primary"
      header-text-variant="white"
    >
      <User v-bind:user="user" />
      <b-button type="button" variant="primary" @click="onSave()">Save</b-button>
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

  mounted() {
    UserService.getUser(this.$route.params.id).then(response => {
      this.user = response.data;
    });
  },

  methods: {
    onSave() {
      UserService.updateUser(this.user)
        .then(() => {
          ToastService.makeToast("Saved!", "success");
        })
        .catch(() => ToastService.makeToast("Error!", "warning"));
    }
  },

  components: {
    User
  }
};
</script>