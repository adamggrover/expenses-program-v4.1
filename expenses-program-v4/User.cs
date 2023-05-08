using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class User
{
    static  public string[] loginChoices = { "Login with existing account", "Create new User" };
    private string username;
    private string password;
    private bool isAdmin;

    public User(string username, string password, bool isAdmin)
    {
        this.username = username;
        this.password = password;
        this.isAdmin = isAdmin;
    }

    public string GetUsername()
    {
        return username;
    }

    public string GetPassword()
    {
        return password;
    }

    public bool IsAdmin()
    {
        return isAdmin;
    }




}
