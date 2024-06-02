export class UserTarget
{
    UserId : number;
    ActivityTypeId : number;
    Date: Date;
    Type: number;
    Count: number;
    Target: number;
    constructor(userId : number,ActivityTypeId : number,Date : Date,Type : number,Count : number,Target: number)
    {
        this.UserId = userId;
        this.ActivityTypeId = ActivityTypeId;
        this.Date = Date;
        this.Type = Type;
        this.Count = Count;
        this.Target = Target;
    }

    static FronJson(target : any) : UserTarget
    {
        return new UserTarget(target.UserId, target.ActivityTypeId,target.Date,target.Type,target.Count,target.Target);
    }
}