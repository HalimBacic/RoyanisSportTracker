import axios from 'axios';
import { UserTarget } from '../models/Target';
import { Activity } from '../models/Activity';

const API_URL='https://localhost:7294/api/UserTarget/';

export const AddTarget = async (usertarget : Partial<UserTarget>) : Promise<UserTarget> =>
{
    const response = await axios.post(API_URL+'/AddTarget', usertarget);
    return response.data;
}

export const GetTargets = async (userId : number) : Promise<UserTarget[]>=>
{
    const response = await axios.get(API_URL+'/GetTargets?userId='+userId);
    return response.data.map((target : Promise<UserTarget>)=>Activity.fromJson(target));
}

export const GetTargetsFiltered = async (userId : number, finished : Boolean) =>
{
    const response = await axios.get(API_URL+'/GetTargetsFiltered?userId='+userId+'&finished='+finished);
    return response.data;
}

export const DeleteTarget = async (deleteRequest : any) =>
{
    const response = await axios.delete(API_URL+'/DeleteTarget',deleteRequest);
    return response.status;
}