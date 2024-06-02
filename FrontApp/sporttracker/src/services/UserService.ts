import axios from 'axios';
import { UserTarget } from '../models/Target';
import { UserToken } from '../models/UserResponse';
import { User } from '../models/User';

const API_URL='https://localhost:7294/api/User/';

export const RegisterUser = async (user : Partial<User>) : Promise<User> =>
{
    const response = await axios.post(API_URL+'Register',user);
    return response.data;
}

export const LoginUser = async (user : Partial<User>) : Promise<UserToken>=>
{
    const response = await axios.post(API_URL+'Login',user);
    return response.data;
}

export const RefreshUser = async (user : Partial<User>) : Promise<UserToken> =>
{
    const response = await axios.post(API_URL+'refresh',user);
    return response.data;
}