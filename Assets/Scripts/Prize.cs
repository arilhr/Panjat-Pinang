using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize 
{
    private Dictionary<string, string[]> prize;

    public void InitDictionary()
    {
        prize = new Dictionary<string, string[]>()
        {
            {"ringan", new string[] {"vga", "kaos"} },
            {"sedang", new string[] {"microwave", "kursi" } },
            {"berat", new string[] {"tv", "sepeda"} },
        };
    }

    public Dictionary<string, string[]> GetPrize()
    {
        return prize;
    }

    public string[] GetPrizeByKey(string key)
    {
        return prize[key];
    }
}
