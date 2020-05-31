<template>
  <div>
    <validation-observer ref="observer" v-slot="{ handleSubmit }">
      <b-form @submit.stop.prevent="handleSubmit(onSubmit)" v-if="show">
        <validation-provider name="Username" :rules="{ required: true }" v-slot="validationContext">
          <b-form-group id="input-group-1" label="Username:" label-for="input-1">
            <b-form-input
              id="input-1"
              v-model="user.userName"
              type="text"
              placeholder="Enter username"
              :state="getValidationState(validationContext)"
            ></b-form-input>
          </b-form-group>
        </validation-provider>

        <validation-provider name="Username" :rules="{ required: true }" v-slot="validationContext">
          <b-form-group id="input-group-3" label="Department:" label-for="input-3">
            <b-form-select
              value-field="id"
              text-field="title"
              id="input-3"
              v-model="user.departmentId"
              :options="departments"
              :state="getValidationState(validationContext)"
            ></b-form-select>
          </b-form-group>
        </validation-provider>
      </b-form>
    </validation-observer>
  </div>
</template>

<script>
import DepartmentService from "@/services/DepartmentService";

export default {
  props: {
    user: {
      type: Object,
      required: true
    }
  },

  data() {
    return {
      departments: [],
      show: true
    };
  },
  mounted() {
    DepartmentService.getDepartments().then(response => {
      this.departments = response;
    });
  },
  methods: {
    getValidationState({ dirty, validated, valid = null }) {
      return dirty || validated ? valid : null;
    },

    onSubmit() {
      
    }
  }
};
</script>