using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBreakout : MonoBehaviour
{
    Rigidbody2D rb;
    public float vel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*vel,0);
    }
}
