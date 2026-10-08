using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    private float speed = 1.5f;
    private float randomX;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            randomX = Random.Range(-5f, 5f);
            timer = 0f;
        }

        transform.Translate(new Vector2(randomX, -1f) * speed * Time.deltaTime);

        // Limita a posição
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4, 4);
        pos.y = Mathf.Clamp(pos.y, -10, 10);

        transform.position = pos;

        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
