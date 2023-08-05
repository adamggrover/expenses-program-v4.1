using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class User
{

    // Fields
    static int userCount = 0;
    

    private string username;
    private string password;
    private bool isAdmin;
    private int userId;

    // Constructor

    public User(string username, string password, bool isAdmin)
    {
        this.username = username;
        this.password = password;
        this.isAdmin = isAdmin;
        ++userCount;
        this.userId = userCount;
    }


    // Getter method for username
    public string GetUsername()
    {
        return username;
    }

    // Getter method for password
    public string GetPassword()
    {
        return password;
    }

    // Getter method for admin
    public bool IsAdmin()
    {
        return isAdmin;
    }

    // Getter method for User ID
    public int GetUserId()
    {
        return userId;
    }




}
