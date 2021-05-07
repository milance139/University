<template>
    <div id="create-student" class="mt-4">
        <p><router-link :to="{ name: 'all_students' }">Return to students</router-link></p>

        <notification v-bind:notifications="notifications"></notification>

        <form v-on:submit.prevent="addStudent">

            <div class="form-group">
                <label name="student_index">Index</label>
                <input type="text" class="form-control" v-model="student.Index" id="student_index" required>
            </div>

            <div class="form-group">
                <label name="student_firstName">First Name</label>
                <input type="text" class="form-control" v-model="student.FirstName" id="student_firstName">
            </div>

            <div class="form-group">
                <label name="student_lastName">Last Name</label>
                <input type="text" class="form-control" v-model="student.LastName" id="student_lastName">
            </div>

            <div class="form-group">
                <label name="student_year">Year</label>
                <input type="text" class="form-control" v-model="student.Year" id="student_year">
            </div>

            <div id="app" class="pb-3">
                <label name="student_status">Status</label>
                <v-select v-model="student.statusID" :options="options" :reduce="status => status.value" label="status">
                <template #search="{attributes, events}">
                    <input
                            class="vs__search"
                            :required="!student.statusID"
                            v-bind="attributes"
                            v-on="events"
                    />
                </template>
                </v-select>
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
    export default{
        data(){
            let user = JSON.parse(localStorage.getItem('user'));
            let options = [];
            UserService.getStatusOptions(user).then((response) => {
                response.data.forEach((data, index) => {
                    options.push({value: data.statusID, status: data.name});
                });
            }, (response) => {
            });
            return{
                student:{},
                notifications:[],
                options: options,
            }
        },
        created: function(){
            this.getStudent();
        },
        methods: {
            getStudent: function()
            {
                let user = JSON.parse(localStorage.getItem('user'));
                UserService.getStudent(user, this.$route.params.id).then((response) => {
                    this.student = response.data;
                    this.student.Status = null;
                }, (response) => {
                });
            },

            addStudent: function()
            {
                let user = JSON.parse(localStorage.getItem('user'));
                console.log(this.$route.params.id);
                if(this.$route.params.id === undefined) {
                    UserService.createStudent(user, this.student).then((response) => {
                        this.notifications.push({
                            type: 'success',
                            message: 'Student created successfully'
                        });
                    }, (response) => {
                        this.notifications.push({
                            type: 'error',
                            message: 'Student not created'
                        });
                    });
                }else{
                    UserService.updateStudent(user, this.student, this.$route.params.id).then((response) => {
                        this.notifications.push({
                            type: 'success',
                            message: 'Student updated successfully'
                        });
                    }, (response) => {
                        this.notifications.push({
                            type: 'error',
                            message: 'Student not updated'
                        });
                    });
                }
            },
        },
        components: {
            'notification' : Notification
        }
    }
</script>