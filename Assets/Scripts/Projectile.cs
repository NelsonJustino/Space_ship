using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Action OnHitTarget;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y >= 10)
        {
            FinishUse();
        }

    }

    private void FinishUse()
    {
        gameObject.SetActive(false);
        OnHitTarget = null;
    }
          
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        //if(collision2D.transform.tag == "Enemy")
        if (collision2D.gameObject.CompareTag("Enemy"))
        {
            gameManager.CountScore();
            Destroy(collision2D.gameObject);
            OnHitTarget?.Invoke();
            FinishUse();
        }        
    }


}
