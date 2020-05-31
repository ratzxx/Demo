<template>
  <div class="container">
    <b-card
      header="Users"
      border-variant="primary"
      header-bg-variant="primary"
      header-text-variant="white"
    >
      <b-button variant="success" class="mb-4" :to="{name: 'create-user'}" >Add</b-button>
      <UsersList v-bind:users="users" v-bind:isBusy="isBusy" @remove-user="removeUser" />
    </b-card>
  </div>
</template>

<script>
import UsersList from "@/components/UsersList";
import UserService from "@/services/UserService";
import ToastService from "@/services/ToastService";

export default {
  data() {
    return {
      users: [],
      isBusy: true
    };
  },

  mounted() {
    this.getUsers();
  },

  methods: {
    getUsers() {
      this.isBusy = true;
      UserService.getUsers().then(response => {
        this.users = response;
        this.isBusy = false;
      });
    },

    removeUser(userId) {
      UserService.dropUser(userId)
        .then(() => {
          this.getUsers()
          ToastService.makeToast("User deleted!", "danger");
        })
        .catch(err => {
          console.log(err);
        });
    },

    addUser() {}
  },
  components: {
    UsersList
  }
};
</script>