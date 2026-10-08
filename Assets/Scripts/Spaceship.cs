using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
    #region VAR
    public float speed;
    public float minX, maxX;
    public float minY, maxY;

    public GameObject projectile;
    public Transform shootPoint;
    public int lives = 5;
    public PoolManager poolManager;

    public TextMeshProUGUI livesText;

    #endregion

    #region CODE

    private void Awake()
    {
        livesText.text = "Lives: " + lives;
    }

    void Update()
    {
        SpaceshipMove();
        Shoot();
    }

    public void SpaceshipMove ()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        } 
        
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        // Limita a posição
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
    
    public void Shoot ()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Forma curta
            /*Instantiate(projectile, shootPoint.position, Quaternion.identity);*/

            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        var obj = poolManager.GetPooledObject();
        obj.SetActive(true);
        obj.transform.position = shootPoint.transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            Destroy(collision.gameObject);
            Debug.Log("Lives: " + lives);
            livesText.text = "Lives: " + lives;
            GameOver();
        }
    }

    public void GameOver()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    #endregion

}
