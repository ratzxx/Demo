<script>
import axios from "axios";
import DepartmentService from "@/services/DepartmentService";

export default {
  usersUrl: "https://userapi20200524084750.azurewebsites.net/users",

  getUsers() {
    return Promise.all([
      fetch(this.usersUrl),
      fetch(DepartmentService.departmentsUrl)
    ])
      .then(async ([u, d]) => {
        const users = await u.json();
        const departments = await d.json();

        return users.users.map(u => {
          let department = departments.departments.find(
            element => element.id == u.departmentId
          );
          return {
            id: u.id,
            username: u.userName,
            departmentId: u.departmentId,
            department: department.title,
            actions: []
          };
        });
      })
      .then(users => {
        return users;
      });
  },

  createUser(user){
      return axios.post(this.usersUrl, user)
  },

  getUser(userId) {
     return axios.get(`${this.usersUrl}/${userId}`)
  },

  updateUser(user) {
      return axios.put(`${this.usersUrl}/${user.id}`, user)
  },

  dropUser(userId) {
    return axios.delete(`${this.usersUrl}/${userId}`)
  }
};
</script>