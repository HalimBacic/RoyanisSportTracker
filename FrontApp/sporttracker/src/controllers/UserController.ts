import { User } from "../models/User";
import { UserToken } from "../models/UserResponse";
import {RegisterUser, LoginUser, RefreshUser} from "../services/UserService";

export const RegisterUserCtrl = async (user : Partial<User>) =>
{
    return await RegisterUser(user);
}

export const LoginUserCtrl = async (user : Partial<UserToken>) =>
{
    return await LoginUser(user);
}

export const RefreshUserCtrl = async (user : Partial<User>) =>
{
    return await RefreshUser(user);
}
