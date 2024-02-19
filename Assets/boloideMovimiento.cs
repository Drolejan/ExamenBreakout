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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velX,velY);
    }

    void Update()
    {
        if (rb.velocity == Vector2.zero)
        {
            velX = Random.Range(2, 5);
            velY = Random.Range(-3, -6);
            rb.velocity = new Vector2(velX, velY);
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        vidas--;
        textovidas.text = "Vidas: " + vidas;
    }
}
