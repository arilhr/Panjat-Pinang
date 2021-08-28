using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public KeyCode climbKey;
    private bool canClimb = true;
    private bool canLoot;
    private int score = 0;
    [SerializeField] private Slider slider;
    [SerializeField] private Text textScore;

    private void Start()
    {
        
    }

    private void Update()
    {
        InputPlayer();
        textScore.text = score.ToString();
    }

    private void InputPlayer()
    {
        if (Input.GetKeyDown(climbKey) && canClimb)
        {
            Climb();
        }else if (Input.GetKeyDown(climbKey) && canLoot)
        {
            Loot();
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
        }
    }

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
