using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float screenBound;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
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
}
