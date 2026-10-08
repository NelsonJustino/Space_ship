using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnemy : MonoBehaviour
{
    private float speed = 2f;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if(transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
