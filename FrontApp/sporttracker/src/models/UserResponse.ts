export class UserToken
{
    Token: string;
    Refreshtoken: string;

    constructor(token : string, refreshtoken : string)
    {
        this.Token = token;
        this.Refreshtoken = refreshtoken;
    }

    static FromJson(userInfo : any) : UserToken 
    {
        return new UserToken(userInfo.Token, userInfo.Refreshtoken)
    }
}