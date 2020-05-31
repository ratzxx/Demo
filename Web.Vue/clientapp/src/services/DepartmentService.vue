<script>
export default {
  departmentsUrl:
    "https://departmentapi20200524092143.azurewebsites.net/departments",

  getDepartments() {
    return fetch(this.departmentsUrl)
      .then(response => response.json())
      .then(data => {
        return data.departments;
      });
  }
};
</script>