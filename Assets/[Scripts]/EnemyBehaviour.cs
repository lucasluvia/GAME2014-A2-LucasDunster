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
        if(other.gameObject.tag == "Sam")
        {
            Debug.Log("Entered");
            Dive();
        }
        if (other.gameObject.tag == "shotBullet" || other.gameObject.tag == "bigShotBullet")
        {
            anim.SetTrigger("EnemyDied");
            StartCoroutine(WaitDestroy(0.2f));
            //return to pool
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        StopAllCoroutines();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Sam")
        {
            Debug.Log("Hit");
            //dequeue to enemy pool
        }

    }

    private void Dive()
    {
        Vector2 newVelocity = body.velocity + new Vector2(0.0f, -4.0f);
        body.velocity = Vector2.ClampMagnitude(newVelocity, 4.0f);
        anim.SetTrigger("StartDive");
    }

    private IEnumerator WaitDestroy(float seconds = 5.0f)
    {
        float time = 0.0f;

        while (time < seconds)
        {
            time += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);

    }
}
