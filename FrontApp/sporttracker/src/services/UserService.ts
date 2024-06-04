import axios from 'axios';
import { UserTarget } from '../models/Target';
import { UserToken } from '../models/UserResponse';
import { User } from '../models/User';

const API_URL='https://localhost:7294/api/User/';

export const RegisterUser = async (user : Partial<User>) : Promise<User | null>=>
{
    try {
        const response = await axios.post(API_URL + 'Register', user);
        if (response.status === 200) {
            alert("User added. Now you can login");
            return response.data;
        }
        return null;
    } catch (error: any) { 
        if (error.response) {
            alert(`Error: ${error.response.data.message || 'Registration failed'}`);
        } else if (error.request) {
            alert("Error: No response received from the server");
        } else {
            alert(`Error: ${error.message}`);
        }
        return null;
    }
}

export const LoginUser = async (user: Partial<UserToken>): Promise<UserToken | null> => {
    try {
        const response = await axios.post(API_URL + 'Login', user);
        if (response.status === 200) {
            return response.data;
        }
        return null;
    } catch (error: any) { 
        if (error.response) {
            if (error.response.status === 401) {
                alert("Unauthorized: Invalid username or password");
            } else {
                alert(`Error: ${error.response.data.message || 'Login failed'}`);
            }
        } else if (error.request) {
            alert("Error: No response received from the server");
        } else {
            alert(`Error: ${error.message}`);
        }
        return null;
    }
}

export const RefreshUser = async (user : Partial<User>) : Promise<UserToken> =>
{
    const response = await axios.post(API_URL+'refresh',user);
    return response.data;
}