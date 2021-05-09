<template>
    <div id="all-courses">
        <h1>All Courses</h1>

        <p><router-link :to="{ name: 'create_course' }" class="btn btn-primary">Create Course</router-link></p>

        <div class="form-group">
          <input type="text" name="search" v-model="courseSearch" placeholder="Search courses" class="form-control" v-on:keyup="searchCourses">
        </div>

        <table class="table table-hover">
            <thead>
            <tr>
                <td>ID</td>
                <td>Name</td>
            </tr>
            </thead>

            <tbody>
            <tr v-for="course in courses" v-bind:key="course.courseID">
                <td>{{ course.courseID }}</td>
                <td>{{ course.name }}</td>
                <td class="text-right">
                    <router-link :to="{name: 'view_course', params: { id: course.courseID }}" class="btn btn-success btn-sm">View</router-link>
                    <button v-confirm="{
                        loader: true,
                        ok: dialog => deleteCourse(dialog, course.courseID),
                        cancel: null,
                        message: 'Are you sure you want to delete this course?'
                    }" class="btn btn-danger btn-sm">Delete</button>
                </td>
            </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import UserService from '../services/user.service';
    export default{
        name: 'Course',
        data(){
            return{
                courses: [],
                courseSearch: '',
                originalCourses: []
            }
        },
        created: function()
        {
            this.fetchCourseData();    
        },
        methods: {
            fetchCourseData: function()
            {
                let user = JSON.parse(localStorage.getItem('user'));
                UserService.getCourses(user).then((response) => {
                    this.courses = response.data;
                    this.originalCourses = this.courses;
                }, (response) => {
                });
            },
            searchCourses: function()
            {
                if(this.courseSearch == '')
                {
                    this.courses = this.originalCourses;
                    return;
                }
                var foundCourses = [];
                for(var i = 0; i < this.originalCourses.length; i++)
                {
                    var courseName = this.originalCourses[i]['name'].toLowerCase();
                    if(courseName.indexOf(this.courseSearch.toLowerCase()) >= 0)
                    {
                        foundCourses.push(this.originalCourses[i]);
                    }
                }
                this.courses = foundCourses;
            },
            deleteCourse: function(dialog, id)
            {
                let user = JSON.parse(localStorage.getItem('user'));
                UserService.deleteCourse(user, id).then((response) =>{
                    location.reload();
                    this.$router.push({name: 'course'})
                }, (response) => {
                    this.notification.push({
                        type: 'danger',
                        message: 'Course could not be deleted!'
                    });
                });
                dialog.loading(false);
                dialog.close();
            }
        }
      
    }
</script>

