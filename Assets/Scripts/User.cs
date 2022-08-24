using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string username;
    public string password;
    public string hint;

    public string[] hintElements;

    public User(string usr, string psw, string hnt, string[] hntelements)
    {
        username = usr;
        password = psw;
        hint = hnt;
        hintElements = hntelements;
    }
}
