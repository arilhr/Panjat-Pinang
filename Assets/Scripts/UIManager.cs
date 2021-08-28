using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("START MENU UI")]
    public GameObject startingUI;

    [Header("IN GAME UI")]
    public Text timeToStartText;
    public GameObject gamePlayUI;
    public Text gameTimeText;

    [Header("END GAME UI")]
    public Text winnerText;
    public GameObject gameEndUI;
}
