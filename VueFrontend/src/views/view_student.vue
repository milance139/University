<template>
    <div id="view-student">
        <p class="mt-4"><router-link :to="{ name: 'all_students' }">Return to courses</router-link></p>
        <h4 class="mb-4 mt-4">Student: {{ student.firstName }} {{ student.lastName }}</h4>

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
            <tr>
                <td>{{ student.studentID }}</td>
                <td>{{ student.index }}</td>
                <td>{{ student.firstName }} {{ student.lastName }}</td>
                <td>{{ student.year }}</td>
                <td>{{ student.status.name }}</td>
            </tr>
            </tbody>
        </table>
        <table class="table table-hover">
            <thead>
            <tr colspan="5" class="pl-0"><h4>Courses</h4></tr>
            <tr> 
                <td>ID</td>
                <td>Name</td>
            </tr>
            </thead>
            <tbody>
            <tr v-for="course in student.courses" v-bind:key="course.courseID">
                <td>{{ course.courseID }}</td>
                <td colspan="4">{{ course.name }}</td>
            </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import UserService from '../services/user.service';

    export default {
        name: 'Home',
        data() {
            return {
                student: [],
            }
        },
        created: function () {
            this.fetchStudentData();
        },
        methods: {
            fetchStudentData: function () {
                let user = JSON.parse(localStorage.getItem('user'));
                UserService.getStudent(user, this.$route.params.id).then((response) => {
                    this.student = response.data;
                }, (response) => {
                });
            },
        }
    }
</script>

