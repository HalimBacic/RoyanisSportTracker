import axios from 'axios';
import { Activity } from '../models/Activity';

const API_URL='https://localhost:7294/api/Activity/';

const getTokenFromCookies = () => {
    const cookies = document.cookie.split('; ');
    const tokenCookie = cookies.find(cookie => cookie.startsWith('token='));
    if (tokenCookie) {
      const tokenstr = tokenCookie.split('=')[1];
      return JSON.parse(tokenstr);
    }
    return null;
  };

export const GetAllActivities = async () : Promise<Activity[]> =>
    {
        const token = getTokenFromCookies();
        const response = await axios.get(API_URL+'GetAllActivities', {headers:{
            Authorization : `Bearer ${token.token}`
        }});
        return response.data.map((activity : Promise<Activity>)=>Activity.fromJson(activity));
    }

export const GetAllActivitiesForUser = async (cpage : number) : Promise<Activity[]> =>
    {
        const token = getTokenFromCookies();
        const response = await axios.get(API_URL+'GetActivities?currentPage='+cpage+'&pages='+10, {
            headers:{
                Authorization : `Bearer ${token.token}`
            }
        });
        const returnData = response.data.map((activity : Promise<Activity>)=>Activity.fromJson(activity));
        return returnData;
    }

export const CreateActivity = async (activity : Partial<Activity>) =>
{
    console.log(activity)
    const token = getTokenFromCookies();
    const response = await axios.post(API_URL+'CreateActivity', activity, {headers:{
        Authorization : `Bearer ${token.token}`
    }});
    return response.data;
}

export const DeleteActivity = async (username : string, activityId : number) =>
{
    const response = await axios.delete(API_URL+'DeleteActivity?username='+username+'&activity='+activityId);
    return response.status;
}