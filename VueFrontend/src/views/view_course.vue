<template>
    <div id="view-student" class="mt-4">
        <p><router-link :to="{ name: 'Course' }">Return to courses</router-link></p>
        <h4 class="mb-4 mt-4">Course: {{ course.name }}</h4>

        <table class="table table-hover">
            <thead>
            <tr>
                <td>ID</td>
                <td>Index</td>
                <td>Name</td>
                <td>Year</td>
            </tr>
            </thead>
            <tbody>
            <tr v-for="student in course.students" v-bind:key="student.studentID">
                <td>{{ student.studentID }}</td>
                <td>{{ student.index }}</td>
                <td>{{ student.firstName }} {{ student.lastName }}</td>
                <td>{{ student.year }}</td>
                <td class="text-right">
                    <button v-confirm="{
                        loader: true,
                        ok: dialog => deleteStudentFromCourse(dialog, student.studentID),
                        cancel: null,
                        message: 'Are you sure ?'}" class="btn btn-danger btn-sm">Delete</button>
                </td>
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
                course: [],
            }
        },
        created: function () {
            this.fetchCourseData();
        },
        methods: {
            fetchCourseData: function () {
                let user = JSON.parse(localStorage.getItem('user'));
                UserService.getCourse(user, this.$route.params.id).then((response) => {
                    this.course = response.data;
                }, (response) => {
                });
            },
            deleteStudentFromCourse(dialog, student_id){
                let user = JSON.parse(localStorage.getItem('user'));
                let course_id = this.course.courseID;
                UserService.deleteStudentFromCourse(user, this.course.courseID, student_id).then((response) => {
                    location.reload();
                }, (response) => {
                });
            }
        }
    }
</script>

