

export class Activity
{
    Id:number;
    Name:string;
    Description:string;
    DateActivity:Date;
    Duration:number;
    ActivityTypeId:number;

    constructor(Id : number,Name:string, Description:string,DateActivity:Date,
        Duration: number,ActivityTypeId:number)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.DateActivity = DateActivity;
        this.Duration = Duration;
        this.ActivityTypeId = ActivityTypeId;
    }

    static fromJson(activity : any) : Activity
    {
        return new Activity(activity.Id, activity.Name, activity.Description,activity.DateActivity,
            activity.Duration, activity.ActivityTypeId);
    }
}