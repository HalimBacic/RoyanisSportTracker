import { Activity } from "../models/Activity";
import {
  GetAllActivitiesForUser,
  CreateActivity,
  DeleteActivity,
  GetAllActivities,
  SearchActivity,
  SearchDateActivity,
  SearchTypeActivity,
  UpdateActivity
} from "../services/ActivityService";

export const GetAllActivitiesCtrl = async (
): Promise<Activity[]> => {
  return await GetAllActivities();
};

export const GetAllActivitiesForUserCtrl = async (
  cpage: number
): Promise<Activity[]> => {
  return await GetAllActivitiesForUser(cpage);
};

export const UpdateActivityCtrl = async ( activity: Partial<Activity>
): Promise<Activity> => {
  return await UpdateActivity(activity);
};

export const CreateActivityCtrl = async ( activity: Partial<Activity>
): Promise<Activity> => {
  return await CreateActivity(activity);
};

export const SearchActivityCtrl = async ( activity: Partial<Activity>
): Promise<Activity[]> => {
  return await SearchActivity(activity);
};

export const SearchDateActivityCtrl = async ( date: Partial<Date>
): Promise<Activity[]> => {
  return await SearchDateActivity(date);
};

export const SearchTypeActivityCtrl = async ( type: Partial<number>
): Promise<Activity[]> => {
  return await SearchTypeActivity(type);
};

export const DeleteActivityCtrl = async (
  activityId: number
) => {
  return await DeleteActivity(activityId);
};
