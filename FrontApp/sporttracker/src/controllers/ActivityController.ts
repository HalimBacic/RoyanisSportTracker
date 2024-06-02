import { Activity } from "../models/Activity";
import {GetAllActivities, CreateActivity, DeleteActivity} from "../services/ActivityService";

export const GetAllActivitiesCtrl = async (username : string) : Promise<Activity[]> =>
{
    return await GetAllActivities(username);
}

export const CreateActivityCtrl = async (username : string, activity : Partial<Activity>) : Promise<Activity>=>
{
    return await CreateActivity(username, activity);
}

export const DeleteActivityCtrl = async (username : string, activityId : number) =>
{
    return await DeleteActivity(username, activityId);
}