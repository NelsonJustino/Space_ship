using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float speed = 5f;
    private float randomX;

    private float movementTimer;
    private float spawnTimer;

    public GameObject circleEnemy;
    public GameObject squareEnemy;
    public GameObject hexagonEnemy;

    public enum EnemyChosen
    {
        Circle,
        Square,
        Hexagon,
    }

    void Movement()
    {
        movementTimer += Time.deltaTime;

        if (movementTimer >= 0.5f)
        {
            randomX = Random.Range(-5f, 5f);
            movementTimer = 0f;
        }

        transform.Translate(new Vector2(randomX, 0f) * speed * Time.deltaTime);


        // Limita a posição do spawner
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4, 4);

        transform.position = pos;
    }

    void Create()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 3f)
        {
            EnemyChosen enemy = (EnemyChosen)Random.Range(0, 3);

            switch (enemy)
            {
                case EnemyChosen.Circle:
                    Instantiate(circleEnemy, transform.position, Quaternion.identity);
                    break;

                case EnemyChosen.Square:
                    Instantiate(squareEnemy, transform.position, Quaternion.identity);
                    break;

                case EnemyChosen.Hexagon:
                    Instantiate(hexagonEnemy, transform.position, Quaternion.identity);
                    break;
            }

            spawnTimer = 0f;
        }
    }

    void Update()
    {
        Movement();
        Create();
    }
}