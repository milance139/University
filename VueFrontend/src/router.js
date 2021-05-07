import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';
import Course from './views/Course.vue';
import Login from './views/Login.vue';
import CreateStudent from './views/create_student.vue';
import CreateCourse from './views/create_course.vue';
import ViewStudent from './views/view_student.vue';
import ViewCourse from './views/view_course.vue';

Vue.use(Router);

export const router = new Router({
    mode: 'history',
    routes: [
        {
            path: '/',
            name: 'students',
            component: Home
        },
        {
            path: '/students',
            component: Home
        },
        {
            path: '/login',
            component: Login
        },
        {
            name: 'all_students',
            path: '/',
            component: Home
        },
        {
            name: 'create_student',
            path: '/create-student',
            component: CreateStudent
        },
        {
            name: 'create_course',
            path: '/create-course',
            component: CreateCourse
        },
        {
            name: 'view_student',
            path: '/view-student',
            component: ViewStudent
        },
        {
            name: 'view_course',
            path: '/view-course',
            component: ViewCourse
        },
        {
            name: 'Course',
            path: '/courses',
            component: Course
        },

    ]
});

router.beforeEach((to, from, next) => {
    const publicPages = ['/login'];
    const authRequired = !publicPages.includes(to.path);
    const loggedIn = localStorage.getItem('user');

    // trying to access a restricted page + not logged in
    // redirect to login page
    if (authRequired && !loggedIn) {
        next('/login');
    } else {
        next();
    }
});
