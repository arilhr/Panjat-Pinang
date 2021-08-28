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
            {"ringan", new string[] {"kapal api", "blender" } },
            {"sedang", new string[] {"handphone", "kipas angin" } },
            {"berat", new string[] {"sapi", "mobil", "truk", "kapal", "pesawat" } },

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
