using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;

    public EnemyManager enemyManager;

    [SerializeField]
    private bool isInPlace = false;
    [SerializeField]
    private float Speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isInPlace)
        {
            transform.position += new Vector3(0.0f, Speed, 0.0f) * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shotBullet" || other.gameObject.tag == "bigShotBullet")
        {
            anim.SetBool("EnemyDied", true);
            StartCoroutine(Return(0.2f));
        }
        if(other.gameObject.tag == "place")
        {
            isInPlace = true;
        }
        if(isInPlace)
        {
            if (other.gameObject.tag == "Sam")
            {
                Dive();
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Sam")
        {
            anim.SetBool("EnemyDied", true);
            StartCoroutine(Return(0.2f));
        }

    }


    private void Dive()
    {
        Vector2 newVelocity = body.velocity + new Vector2(0.0f, -1.5f);
        body.velocity = Vector2.ClampMagnitude(newVelocity, 2.5f);
        anim.SetBool("StartDive", true);
    }

    private IEnumerator Return(float seconds = 5.0f)
    {
        float time = 0.0f;

        while (time < seconds)
        {
            time += Time.deltaTime;
            yield return null;
        }

        isInPlace = false;
        anim.SetBool("EnemyDied", false);
        anim.SetBool("StartDive", false);
        enemyManager.ReturnEnemy(gameObject);
    }
}
