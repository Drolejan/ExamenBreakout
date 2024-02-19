using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class boloideMovimiento : MonoBehaviour
{
    Rigidbody2D rb;
    public float velX,velY,vidas,puntos;
    public TextMeshProUGUI textovidas,textopuntos;
    public GameObject GameOver;
    public GameObject Win;
    public bool inicio,pegado;
    public Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(velX,velY);
    }

    void Update()
    {
        if (inicio==true)
        {
            velX = Random.Range(2, 5);
            velY = Random.Range(-3, -6);
            rb.velocity = new Vector2(velX, velY);
            inicio = false;
            pegado = false;
        }
        if (pegado==true)
        {
            transform.position = player.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            velY*=-1;
            rb.velocity = new Vector2(velX, velY);
        }
        if (collision.gameObject.CompareTag("Pared"))
        {
            velX *= -1;
            rb.velocity = new Vector2(velX, velY);
        }

        if (collision.gameObject.CompareTag("Puntos"))
        {
            Destroy(collision.gameObject);
            puntos++;
            textopuntos.text = "Puntos: " + puntos;
        }
        if(puntos > 1) 
        {
            Win.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        vidas--;
        textovidas.text = "Vidas: " + vidas;
        if (vidas < 1)
        {
           GameOver.SetActive(true);
        }
        
    }
}
