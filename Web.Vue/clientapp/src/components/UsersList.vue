<template>
  <b-table hover :busy="isBusy" :items="users" show-empty empty-text="No users!">
    <template v-slot:table-busy>
      <div class="text-center my-2">
        <b-spinner class="align-middle mx-2"></b-spinner>
        <strong>Loading...</strong>
      </div>
    </template>
    <template v-slot:cell(actions)="row">
      <b-button variant="primary" :to="{ name: 'user-details', params: { id: row.item.id } }" class="mr-1">Edit</b-button>
      <b-button variant="danger" @click="$emit('remove-user', row.item.id)">Delete</b-button>
    </template>
  </b-table>
</template>

<script>
export default {
  props: ["users", "isBusy"]
};
</script>

<style>
</style>