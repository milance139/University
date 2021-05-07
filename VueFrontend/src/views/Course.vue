<template>
    <div id="all-courses">
        <h1>All Courses</h1>

        <p><router-link :to="{ name: 'create_course' }" class="btn btn-primary">Create Course</router-link></p>

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
                }, (response) => {
                });
            },
        }
      
    }
</script>

