import axios from 'axios';
import { UserTarget } from '../models/Target';
import { Activity } from '../models/Activity';

const API_URL='https://localhost:7294/api/UserTarget/';

const getTokenFromCookies = () => {
    const cookies = document.cookie.split('; ');
    const tokenCookie = cookies.find(cookie => cookie.startsWith('token='));
    if (tokenCookie) {
      const tokenstr = tokenCookie.split('=')[1];
      return JSON.parse(tokenstr);
    }
    return null;
  };

export const AddTarget = async (usertarget : Partial<UserTarget>) : Promise<UserTarget> =>
{
    const token = getTokenFromCookies();
    const response = await axios.post(API_URL+'AddTarget', usertarget, {headers:
        {
            'Authorization' : `Bearer ${token.token}`
        }
    });
    return response.data;
}

export const GetTargets = async (page:number) : Promise<UserTarget[]>=>
{
    const token = getTokenFromCookies();
    const response = await axios.get(API_URL+'GetTargets?currentPage='+page+'&pages='+10, {
        headers: {
            'Authorization' : `Bearer ${token.token}`
        }
    });
    
    return response.data.map((target : Promise<UserTarget>)=>UserTarget.fromJson(target));
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