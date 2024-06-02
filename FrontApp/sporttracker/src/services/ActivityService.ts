import axios from 'axios';
import { Activity } from '../models/Activity';

const API_URL='https://localhost:7294/api/Activity/';

export const GetAllActivities = async (username : string) : Promise<Activity[]> =>
{
    const response = await axios.get(API_URL+'GetActivities?username='+username);
    return response.data.map((activity : Promise<Activity>)=>Activity.fromJson(activity));
}

export const CreateActivity = async (username : string, activity : Partial<Activity>) =>
{
    const response = await axios.post(API_URL+'CreateActivity?username='+username,activity);
    return response.data;
}

export const DeleteActivity = async (username : string, activityId : number) =>
{
    const response = await axios.delete(API_URL+'DeleteActivity?username='+username+'&activity='+activityId);
    return response.status;
}