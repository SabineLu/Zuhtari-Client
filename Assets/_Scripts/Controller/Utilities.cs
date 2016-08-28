using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public static class Utilities
{
    public static bool CheckCharacterCount(string _Strng, int _MinLength)
    {
        bool lngSet;
        // Return true if strIn is in valid e-mail format.
        if (_Strng.Length >= _MinLength)
        {
            lngSet = true;
        }
        else
        {
            lngSet = false;
        }

        return lngSet;
    }

    public static bool IsValidPassword(string strIn)
    {
        bool pwSet;
        // Return true if strIn is in valid e-mail format.
        if (strIn.Length > 6)
        {
            pwSet = true;
        }
        else
        {
            pwSet = false;
        }

        return pwSet;
    }

    public static bool DoStringsMatch(String string1, String string2)
    {
        return String.Equals(string1,string2);
    }

    public static bool IsValidEmail(string strIn)
    {
        bool check = Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        Debug.Log(check);
        if (strIn.Length < 6)
        {
            check = false;
        }
        // Return true if strIn is in valid e-mail format.
        return check;
    }
}

