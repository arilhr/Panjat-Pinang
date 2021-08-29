using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public KeyCode climbKey;
    private bool canClimb = true;
    private bool canLoot;
    public KeyCode useItemKey;
    private bool hasItemDistract = false;
    [SerializeField] private Image itemDistractUI;
    private int score = 0;
    [SerializeField] private Slider slider;
    [SerializeField] private Text textScore;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (GameManager.instance.gameState == 1)
        {
            InputPlayer();
        }
        
        textScore.text = score.ToString();
    }

    private void InputPlayer()
    {
        if (Input.GetKeyDown(climbKey) && canClimb)
        {
            Climb();
        }
        else if (Input.GetKeyDown(climbKey) && canLoot)
        {
            Loot();
        }

        if (Input.GetKeyDown(useItemKey))
        {
            UseItemDistract();
        }
    }

    private void Climb()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
    }

    private void Loot()
    {
        slider.value += 10;
        if(slider.value >= 100)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            slider.value = 0;
            canLoot = false;
            score += 10;
            RandomGetItemDistract();
        }
    }

    private void RandomGetItemDistract()
    {
        if (!hasItemDistract)
        {
            if (Random.Range(0, 3) == 2)
            {
                hasItemDistract = true;
                itemDistractUI.gameObject.SetActive(true);
            }
        }
    }

    private void UseItemDistract()
    {
        if (hasItemDistract)
        {
            GameManager.instance.DistractedPlayer(this);
            hasItemDistract = false;
            itemDistractUI.gameObject.SetActive(false);
        }
    }

    public void Distracted()
    {
        // cancel loot
        canLoot = false;
        slider.value = 0;

        // cancel climb
        canClimb = false;

        // tibo
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }


    public int GetScore() { return score; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "prize")
        {
            canClimb = false;
            canLoot = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            canClimb = true;
        }
    }
}
