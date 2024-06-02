import { UserTarget } from "../models/Target";
import {AddTarget, GetTargets, GetTargetsFiltered, DeleteTarget } from "../services/UserTargetService";

export const AddTargetCtrl = async (user : Partial<UserTarget>) =>
{
    return await AddTarget(user);
}

export const GetTargetsCtrl = async (userId : number) =>
{
    return await GetTargets(userId);
}

export const GetTargetsFilteredCtrl = async (userId : number, finished : Boolean) =>
{
    return await GetTargetsFiltered(userId, finished);
}

export const DeleteTargetCtrl = async (deleteRequest : any) =>
{
    return await DeleteTarget(deleteRequest);
}