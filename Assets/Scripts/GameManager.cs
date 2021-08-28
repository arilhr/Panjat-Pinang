using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Prize prize;

    public static GameManager instance;

    public Slider sliderPlayerOne, sliderPlayerTwo;

    // Start is called before the first frame update
    void Start()
    {
        prize = new Prize();
        prize.InitDictionary();

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
