import { UserTarget } from "../models/Target";
import {AddTarget, GetTargets, GetTargetsFiltered, DeleteTarget } from "../services/UserTargetService";

export const AddTargetCtrl = async (usertarget : Partial<UserTarget>) =>
{
    return await AddTarget(usertarget);
}

export const GetTargetsCtrl = async (page : number) =>
{
    return await GetTargets(page);
}

export const GetTargetsFilteredCtrl = async (userId : number, finished : Boolean) =>
{
    return await GetTargetsFiltered(userId, finished);
}

export const DeleteTargetCtrl = async (deleteRequest : any) =>
{
    return await DeleteTarget(deleteRequest);
}