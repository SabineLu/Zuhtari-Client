using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

//utili class for standard check ups and events which will be needed in all classes
public static class Utilities
{
    //check length of the string, with given min length
    public static bool CheckCharacterCount(string _String, int _MinLength)
    {
        bool lngSet;
        // Return true if strIn is in valid e-mail format.
        if (_String.Length >= _MinLength)
        {
            lngSet = true;
        }
        else
        {
            lngSet = false;
        }

        return lngSet;
    }

    //check if password is valid, min length (Add later check to make pw more secure) 
    public static bool IsValidPassword(string _String)
    {
        bool pwSet;
        // Return true if strIn is in valid e-mail format.
        if (_String.Length > 6)
        {
            pwSet = true;
        }
        else
        {
            pwSet = false;
        }

        return pwSet;
    }

    //check if two given strings match
    public static bool DoStringsMatch(String _String1, String _String2)
    {
        return String.Equals(_String1,_String2);
    }

    //check if given mail is valid
    public static bool IsValidEmail(string _String)
    {
        bool check = Regex.IsMatch(_String, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        Debug.Log(check);
        if (_String.Length < 6)
        {
            check = false;
        }
        // Return true if strIn is in valid e-mail format.
        return check;
    }
}

