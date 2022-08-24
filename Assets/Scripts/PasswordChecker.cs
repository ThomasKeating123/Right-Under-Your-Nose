using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordChecker
{

    //Score Out of 6
    private int score = 0;
    public int maxScore = 6;

    public int CheckPassword(string password)
    {
        score = 0;

        if (HasUnwantedChar(password) == false & HasWhitespce(password) == false)
        {
            if (password.Length >= 6) score += 2;
            if (HasUpper(password)) score++;
            if (HasLower(password)) score++;
            if (HasNumber(password)) score++;
            if (HasSymbol(password)) score++;
        }
        else
        {
            score = 0;
        }

        return score;
    }

    private bool HasUpper(string password)
    {
        char[] pswCharacters = password.ToCharArray();
        for (int i = 0; i < pswCharacters.Length; i++)
        {
            if (char.IsUpper(pswCharacters[i]) && char.IsLetter(pswCharacters[i]))
            {
                return true;
            }
        }

        return false;
    }

    private bool HasLower(string password)
    {
        char[] pswCharacters = password.ToCharArray();
        for (int i = 0; i < pswCharacters.Length; i++)
        {
            if (char.IsLower(pswCharacters[i]) && char.IsLetter(pswCharacters[i]))
            {
                return true;
            }
        }

        return false;
    }

    private bool HasNumber(string password)
    {
        char[] pswCharacters = password.ToCharArray();
        for (int i = 0; i < pswCharacters.Length; i++)
        {
            if (char.IsDigit(pswCharacters[i]))
            {
                return true;
            }
        }

        return false;
    }

    private bool HasSymbol(string password)
    {
        char[] specialChars = "@!£$%^&*#~?+-_=".ToCharArray();

        char[] pswCharacters = password.ToCharArray();
        for (int i = 0; i < pswCharacters.Length; i++)
        {
            for (int j = 0; j < specialChars.Length; j++)
            {
                if (pswCharacters[i] == specialChars[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool HasUnwantedChar(string password)
    {
        char[] unwantedChars = "\\/':;(){}[]".ToCharArray();

        char[] pswCharacters = password.ToCharArray();
        for (int i = 0; i < pswCharacters.Length; i++)
        {
            for (int j = 0; j < unwantedChars.Length; j++)
            {
                if (pswCharacters[i] == unwantedChars[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool HasWhitespce(string password)
    {
        char[] pswCharacters = password.ToCharArray();
        for (int i = 0; i < pswCharacters.Length; i++)
        {
            if (char.IsWhiteSpace(pswCharacters[i]))
            {
                return true;
            }
        }

        return false;
    }
}
