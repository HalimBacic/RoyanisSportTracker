import { Activity } from "../models/Activity";
import {
  GetAllActivitiesForUser,
  CreateActivity,
  DeleteActivity,
  GetAllActivities,
} from "../services/ActivityService";

export const GetAllActivitiesCtrl = async (
  token: string
): Promise<Activity[]> => {
  return await GetAllActivities();
};

export const GetAllActivitiesForUserCtrl = async (
  username: string
): Promise<Activity[]> => {
  return await GetAllActivitiesForUser(username);
};

export const CreateActivityCtrl = async ( activity: Partial<Activity>
): Promise<Activity> => {
  console.log(activity);
  return await CreateActivity(activity);
};

export const DeleteActivityCtrl = async (
  username: string,
  activityId: number
) => {
  return await DeleteActivity(username, activityId);
};
