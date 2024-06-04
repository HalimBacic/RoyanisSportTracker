export class UserTarget
{
    UserId : number;
    ActivityTypeId : number;
    DateActivity: Date;
    Type: number;
    Count: number;
    Target: number;
    
    constructor(userId : number,ActivityTypeId : number,DateActivity : Date,Type : number,Count : number,Target: number)
    {
        this.UserId = userId;
        this.ActivityTypeId = ActivityTypeId;
        this.DateActivity = DateActivity;
        this.Type = Type;
        this.Count = Count;
        this.Target = Target;
    }

    static fromJson(target : any) : UserTarget
    {
        return new UserTarget(target.userId, target.activityTypeId,target.dateActivity,target.type,target.count,target.target);
    }
}