using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        Dive();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit");
        //dequeue to enemy pool
        Destroy(gameObject);
    }

    private void Dive()
    {
        Vector2 newVelocity = body.velocity + new Vector2(0.0f, -4.0f);
        body.velocity = Vector2.ClampMagnitude(newVelocity, 4.0f);
        anim.SetTrigger("StartDive");
    }
}
