using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerAttributes", menuName = "Player/Attributes")]
public class PlayerAttributesObject : ScriptableObject
{
    public int currenthp = 40;
    public int maxhp = 40;
    public int currentmp = 10;
    public int maxmp = 10;
    public int strength = 10;
    public int dex = 10;

    public void changeCurrentHp(int n)
    {
        if (currenthp + n > maxhp)
            currenthp = maxhp;
        else if (currenthp + n < 0)
            currenthp = 0;
        else
            currenthp += n;
    }

    public void changeMaxHp(int n)
    {
        if (maxhp + n < 0)
            maxhp = 0;
        else
            maxhp += n;
    }

    public void changeCurrentMp(int n)
    {
        if (currentmp + n > maxmp)
            currentmp = maxmp;
        else if (currentmp + n < 0)
            currentmp = 0;
        else
            currentmp += n;
    }

    public void changeMaxMp(int n)
    {
        if (maxmp + n < 0)
            maxmp = 0;
        else
            maxmp += n;
    }

    public void changeStr(int n)
    {
        if (strength + n < 0)
            strength = 0;
        else
            strength += n;
    }

    public void changeDex(int n)
    {
        if (dex + n < 0)
            dex = 0;
        else
            dex += n;
    }
}
