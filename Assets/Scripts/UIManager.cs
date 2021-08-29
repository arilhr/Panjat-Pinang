using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("IN GAME UI")]
    public Text timeToStartText;
    public GameObject gamePlayUI;
    public Text gameTimeText;

    [Header("END GAME UI")]
    public Text winnerText;
    public GameObject gameEndUI;

    [Header("PAUSE UI")]
    public GameObject pauseUI;

    public Sprite chair;
    public Sprite tv;
    public Sprite vga;
    public Sprite kaos;
    public Sprite microwave;
    public Sprite bicycle;

    public int SetSliderMaxValueByScore(Slider slider, int score)
    {
        int sliderMaxValue;

        if(score >= 600)
        {
            sliderMaxValue = 200;
            slider.maxValue = sliderMaxValue;
        }else if(score >= 300)
        {
            sliderMaxValue = 150;
            slider.maxValue = sliderMaxValue;
        }else
        {
            sliderMaxValue = 100;
            slider.maxValue = sliderMaxValue;

        }

        return sliderMaxValue;
    }

    public void ShowPrize(Image image, string prizeName)
    {
        switch (prizeName)
        {
            case "kursi":
                image.sprite = chair;
                break;
            case "tv":
                image.sprite = tv;
                break;
            case "vga":
                image.sprite = vga;
                break;
            case "microwave":
                image.sprite = microwave;
                break;
            case "bicycle":
                image.sprite = bicycle;
                break;
            case "kaos":
                image.sprite = kaos;
                break;
        }

        StartCoroutine(FadeImage(image));
    }

    IEnumerator FadeImage(Image image)
    {
        image.gameObject.SetActive(true);
        for (float i = 1.5f; i >= 0; i -= Time.deltaTime)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
        image.gameObject.SetActive(false);
    }
}
