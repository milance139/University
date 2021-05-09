import axios from 'axios';

const API_URL = 'http://localhost:3673/api/';

class UserService {
    getStudents(user) {
        return axios.get(API_URL + 'students', { headers: { Authorization: "Bearer " + user.access_token }});
    }

    getCourses(user, id) {
        return axios.get(API_URL + 'Courses/GetCourses', { headers: { Authorization: "Bearer " + user.access_token }});
    }

    createStudent(user, student) {
        return axios.post(API_URL + 'students', student, { headers: { Authorization: "Bearer " + user.access_token }});
    }

    updateStudent(user, student, id) {
        return axios.put(API_URL + 'students/'+id, student, { headers: { Authorization: "Bearer " + user.access_token }});
    }

    createCourse(user, course) {
        return axios.post(API_URL + 'courses/PostCourse', course, { headers: { Authorization: "Bearer " + user.access_token }});
    }

    getStatusOptions(user, student) {
        return axios.get(API_URL + 'status', { headers: { Authorization: "Bearer " + user.access_token }});
    }

    getStudent(user, id) {
        return axios.get(API_URL + 'students/'+id, { headers: { Authorization: "Bearer " + user.access_token }});
    }

    getCourse(user, id) {
        return axios.get(API_URL + 'courses/GetCourse/'+id, { headers: { Authorization: "Bearer " + user.access_token }});
    }

    deleteStudentFromCourse(user, course_id, student_id){
        return axios.post(API_URL + 'courses/RemoveStudentFromCourse?student_id=' + student_id + '&course_id=' + course_id, {headers: { Authorization: "Bearer " + user.access_token }});
    }

    deleteCourse(user, id) {
        return axios.delete(API_URL + 'courses/DeleteCourse/'+id, { headers: { Authorization: "Bearer " + user.access_token}});
    }

    deleteStudent(user, id) {
        return axios.delete(API_URL + 'students/'+id, { headers: { Authorization: "Bearer " + user.access_token }});
    }
}

export default new UserService();
