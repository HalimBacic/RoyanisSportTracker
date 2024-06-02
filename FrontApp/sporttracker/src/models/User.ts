export class User
{
    Id: number;
    Username: string;
    Email: string;
    Password: string;

    constructor(id : number, username : string, email: string,password: string)
    {
        this.Id = id;
        this.Username = username;
        this.Email = email;
        this.Password = password;
    }

    static FromJson(user : any) : User
    {
        return new User(user.Id, user.Username,user.Email, user.Password);
    }
}