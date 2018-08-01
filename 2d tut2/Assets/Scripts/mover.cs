using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {
    
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*float x = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * x * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }*/


    }
}
