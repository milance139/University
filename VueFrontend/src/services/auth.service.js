import axios from 'axios';


const API_URL = 'http://localhost:3673/api/';

class AuthService {
    login(user) {
        return axios
            .post(API_URL + 'token', {Username: user.username, Password: user.password})
            .then(response => {
                if (response.data) {
                    localStorage.setItem('user', JSON.stringify(response.data));
                }              
                user.access_token = response.data;      
                return response.data;
            });
    }

    logout() {
        localStorage.removeItem('user');
    }

}

export default new AuthService();
