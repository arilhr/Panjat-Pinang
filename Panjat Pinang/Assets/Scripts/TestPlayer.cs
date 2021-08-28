using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public KeyCode climbKey;
    private Transform playerTransform;
    private Vector2 targetPosition;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        targetPosition = transform.position;
    }

    private void Update()
    {
        InputPlayer();

        transform.position = Vector2.Lerp(transform.position, targetPosition, 0.2f);
    }

    private void InputPlayer()
    {
        if (Input.GetKeyDown(climbKey))
        {
            Climb();
        }
    }

    private void Climb()
    {
        targetPosition.y += 0.5f;
    }
}
