using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonEnemy : MonoBehaviour
{
    private float horizontalSpeed = 6f;
    private float verticalSpeed = 1f;
    private float direction = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(direction * horizontalSpeed, -verticalSpeed);

        transform.Translate(movement * Time.deltaTime);

        if (transform.position.x >= 6)
        {
            direction = -1f;
        }

        if (transform.position.x <= -6)
        {
            direction = 1f;
        }

        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
