import axios from "axios";
import { Activity } from "../models/Activity";

const API_URL = "https://localhost:7294/api/Activity/";

const getTokenFromCookies = () => {
  const cookies = document.cookie.split("; ");
  const tokenCookie = cookies.find((cookie) => cookie.startsWith("token="));
  if (tokenCookie) {
    const tokenstr = tokenCookie.split("=")[1];
    return JSON.parse(tokenstr);
  }
  return null;
};

export const GetAllActivities = async (): Promise<Activity[]> => {
  const token = getTokenFromCookies();
  const response = await axios.get(API_URL + "GetAllActivities", {
    headers: {
      Authorization: `Bearer ${token.token}`,
    },
  });
  return response.data.map((activity: Promise<Activity>) =>
    Activity.fromJson(activity)
  );
};

export const GetAllActivitiesForUser = async (
  cpage: number
): Promise<Activity[]> => {
  const token = getTokenFromCookies();
  const response = await axios.get(
    API_URL + "GetActivities?currentPage=" + cpage + "&pages=" + 10,
    {
      headers: {
        Authorization: `Bearer ${token.token}`,
      },
    }
  );
  const returnData = response.data.map((activity: Promise<Activity>) =>
    Activity.fromJson(activity)
  );
  return returnData;
};

export const CreateActivity = async (activity: Partial<Activity>) => {

  const token = getTokenFromCookies();
  const response = await axios.post(API_URL + "CreateActivity", activity, {
    headers: {
      Authorization: `Bearer ${token.token}`,
    },
  });
  return response.data;
};

export const UpdateActivity = async (activity: Partial<Activity>) => {

  const token = getTokenFromCookies();
  const response = await axios.put(API_URL + "UpdateActivity", activity, {
    headers: {
      Authorization: `Bearer ${token.token}`,
    },
  });
  console.log(response.data)
  return response.data;
};

export const SearchActivity = async (searchactivity: Partial<Activity>) : Promise<Activity[]> => {
    console.log(searchactivity)
    const token = getTokenFromCookies();
  const response = await axios.post(API_URL + "GetActivitiesSearch", searchactivity, {
    headers: {
      Authorization: `Bearer ${token.token}`,
    },
  });
  const returnData = response.data.map((activity: Promise<Activity>) =>
    Activity.fromJson(activity)
  );
  return returnData;
};

export const SearchDateActivity = async (date: Partial<Date>) : Promise<Activity[]> => {
  const token = getTokenFromCookies();
const response = await axios.get(API_URL + "SearchByDate?date="+date, {
  headers: {
    Authorization: `Bearer ${token.token}`,
  },
});
const returnData = response.data.map((activity: Promise<Activity>) =>
  Activity.fromJson(activity)
);
return returnData;
};

export const SearchTypeActivity = async (type: Partial<number>) : Promise<Activity[]> => {
  const token = getTokenFromCookies();
const response = await axios.get(API_URL + "SearchByType?type="+type, {
  headers: {
    Authorization: `Bearer ${token.token}`,
  },
});
const returnData = response.data.map((activity: Promise<Activity>) =>
  Activity.fromJson(activity)
);
return returnData;
};

export const DeleteActivity = async (activityId: number) => {
  const token = getTokenFromCookies();
  const response = await axios.delete(
    API_URL + "DeleteActivity?activityId=" + activityId, {
      headers: {
        Authorization: `Bearer ${token.token}`,
      }}
  );
  return response.status;
};
