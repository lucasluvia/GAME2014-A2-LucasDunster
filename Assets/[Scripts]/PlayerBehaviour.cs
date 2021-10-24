using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float screenBound;

    private Rigidbody2D body;
    private Animator anim;

    private int lives = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds(); 
        
        body.velocity *= 0.99f;
    }

    private void CheckBounds()
    {
        if (transform.position.x >= screenBound)
        {
            transform.position = new Vector3(screenBound - 0.05f, transform.position.y, 0.0f);
            body.velocity = new Vector2(0.0f, 0.0f);
        }

        if (transform.position.x <= -screenBound)
        {
            transform.position = new Vector3(-screenBound + 0.05f, transform.position.y, 0.0f);
            body.velocity = new Vector2(0.0f,0.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        lives--;
        anim.SetInteger("Lives", lives);
    }

}
