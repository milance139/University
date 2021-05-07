<template>
  <div id="all-students">
    <h1>All Students</h1>

    <p><router-link :to="{ name: 'create_student' }" class="btn btn-primary">Create Student</router-link></p>

    <div class="form-group">
      <input type="text" name="search" v-model="studentSearch" placeholder="Search students" class="form-control" v-on:keyup="searchStudents">
    </div>

    <table class="table table-hover">
      <thead>
      <tr>
        <td>ID</td>
        <td>Index</td>
        <td>Name</td>
        <td>Year</td>
        <td>Status</td>
      </tr>
      </thead>

      <tbody>
      <tr v-for="student in students" v-bind:key="student.studentID">
        <td>{{ student.studentID }}</td>
        <td>{{ student.index }}</td>
        <td>{{ student.firstName }} {{ student.lastName }}</td>
        <td>{{ student.year }}</td>
        <td>{{ student.status.name }}</td>
        <td class="text-right">
          <router-link :to="{name: 'view_student', params: { id: student.studentID }}" class="btn btn-success btn-sm">View</router-link>
          <router-link :to="{name: 'create_student', params: { id: student.studentID }}" class="btn btn-primary btn-sm">Edit</router-link>
          <button v-confirm="{
            loader: true,
            ok: dialog => deleteStudent(dialog, student.studentID),
            cancel: null,
            message: 'Are you sure ?'}" class="btn btn-danger btn-sm"
          >
            Delete
          </button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
    import UserService from '../services/user.service';
    export default{
        name: 'Home',
        data(){
            return{
                students: [],
                originalStudents: [],
                studentSearch: ''
            }
        },
        created: function()
        {
            this.fetchProductData();
        },
        methods: {
            fetchProductData: function()
            {
                let user = JSON.parse(localStorage.getItem('user'));
                UserService.getStudents(user).then((response) => {
                    this.students = response.data;
                    this.originalStudents = this.students;         
                }, (response) => {
                });
            },
            searchStudents: function()
            {
                if(this.studentSearch == '')
                {
                    this.students = this.originalStudents;
                    return;
                }
                var searchedStudents = [];
                for(var i = 0; i < this.originalStudents.length; i++)
                {
                    var studentName = this.originalStudents[i]['firstName'].toLowerCase();
                    if(studentName.indexOf(this.studentSearch.toLowerCase()) >= 0)
                    {
                        searchedStudents.push(this.originalStudents[i]);
                    }
                }
                this.students = searchedStudents;
            },
            deleteStudent: function(dialog, id)
            {
                let user = JSON.parse(localStorage.getItem('user'));
                UserService.deleteStudent(user, id).then((response) => {
                    location.reload();
                    this.$router.push({name: 'home'})
                }, (response) => {
                    this.notifications.push({
                        type: 'danger',
                        message: 'Student could not be deleted'
                    });
                });
                dialog.loading(false);
                dialog.close();
            }
        }
    }
</script>

