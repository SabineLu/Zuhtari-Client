using UnityEngine;
using System.Collections;

public class UserModel
{
    private string m_Email;         //email of the user
    private string m_Name;          //name of the user
    private string m_Password;      //password of the user
    //private Date joinDate;        //join data is set by the server

    public UserModel()
    {
        m_Email = null;
        m_Name = null;
        m_Password = null;
    }

    public UserModel(UserModel _User)
    {
        m_Email = _User.getEmail();
        m_Name = _User.getName();
        m_Password = _User.getPassword();
    }

    public UserModel(string _Email, string _Name, string _PW)
    {
        m_Email = _Email;
        m_Name = _Name;
        m_Password = _PW;
    }

    //Setter and Getter

    public string getEmail()
    {
        return m_Email;
    }

    public void setEmail(string email)
    {
        this.m_Email = email;
    }

    public string getName()
    {
        return m_Name;
    }

    public void setName(string name)
    {
        this.m_Name = name;
    }


    public string getPassword()
    {
        return m_Password;
    }

    public void setPassword(string password)
    {
        this.m_Password = password;
    }

}
