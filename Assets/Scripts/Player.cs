using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode climbKey;
    private bool canClimb = true;
    private bool canLoot;

    private void Start()
    {

    }

    private void Update()
    {
        InputPlayer();
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
        GameManager.instance.sliderPlayerOne.value += 10;
        if(GameManager.instance.sliderPlayerOne.value >= 100)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            GameManager.instance.sliderPlayerOne.value = 0;
            canLoot = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "prize1")
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
