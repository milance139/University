<template>
    <div id="create-student" class="mt-4">
        <p>
            <router-link :to="{ name: 'Course' }">Return to courses</router-link>
        </p>

        <notification v-bind:notifications="notifications"></notification>

        <form v-on:submit.prevent="addCourse">

            <div class="form-group">
                <label name="course_name">Name</label>
                <input type="text" class="form-control" v-model="course.name" id="course_name" required>
            </div>

            <div id="app" class="pb-3">
                <label name="students">Students</label>
                <v-select taggable multiple push-tags v-model="course.students" :options="options"
                          :reduce="status => status.value" label="status"></v-select>
            </div>

            <div class="form-group">
                <button class="btn btn-primary">Save</button>
            </div>
        </form>
    </div>
</template>


<script>
    import Notification from './notifications.vue';
    import UserService from '../services/user.service';

    export default {
        data() {
            let user = JSON.parse(localStorage.getItem('user'));
            let options = [];
            UserService.getStudents(user).then((response) => {
                response.data.forEach((student, index) => {
                    options.push({value: student, status: student.firstName + ' ' + student.lastName});
                });
            }, (response) => {
            });
            return {
                course: {},
                notifications: [],
                options: options,
            }
        },
        methods: {
            addCourse: function () {
                let user = JSON.parse(localStorage.getItem('user'));

                UserService.createCourse(user, this.course).then((response) => {
                    this.notifications.push({
                        type: 'success',
                        message: 'Course created successfully'
                    });
                }, (response) => {
                    this.notifications.push({
                        type: 'danger',
                        message: 'Course not created'
                    });
                });
            },
        },
        components: {
            'notification': Notification
        }
    }
</script>