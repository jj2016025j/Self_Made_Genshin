using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        CommonFactor(a, b);
        Debug.Log(CommonFactor(a, b));

        FindTheNumberWhere5Appears();
        int i = 0;
        string s = "";
        foreach (var item in FindTheNumberWhere5Appears())
        {
            s += "[" + FindTheNumberWhere5Appears()[i] + "] ";
            i++;
        }
        Debug.Log(s); 
        
        i = 0;
        s = "";
        foreach (var item in FindTheNumberWhereNAppears(a, b, f))
        {
            s+="["+FindTheNumberWhereNAppears(a, b, f)[i]+"] ";
            i++;
        }
        Debug.Log(s);
    }
    public int a, b, f;
    int CommonFactor(int a, int b)
    {
        for (int i = a; i >= 1; i--)
        {
            if (a % i == 0)
            {
                if (b % i == 0)
                    return i;
            }
        }
        return 1;
    }
    List<int> FindTheNumberWhere5Appears()
    {
        List<int> list = new List<int>();
        for (int i = 1; i <= 100; i++)
        {
            if (i % 10 == 5)
                list.Add(i);
            else if (Math.Floor((decimal)i / 10) == 5)
                    list.Add(i);
        }
        return list;
    }
    List<int> FindTheNumberWhereNAppears(int min, int max, int F)
    {
        List<int> list = new List<int>();
        for (int i = min; i <= max; i++)
        {
            int s = 1;
            if (i % 10 == F)
                list.Add(i);
            else
                while (i >= Math.Pow(10, s))
                {
                    if (Math.Floor(i / Math.Pow(10, s)) == F)
                    {
                        list.Add(i);
                    }
                    s++;
                }
        }
        return list;
    }
}