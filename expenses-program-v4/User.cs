using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class User
{
    static int userCount = 0;
    static  public string[] loginChoices = { "Login with existing account", "Create new User" };

    private string username;
    private string password;
    private bool isAdmin;
    private int userId;

    public User(string username, string password, bool isAdmin)
    {
        this.username = username;
        this.password = password;
        this.isAdmin = isAdmin;
        ++userCount;
        this.userId = userCount;
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

    public int GetUserId()
    {
        return userId;
    }




}
