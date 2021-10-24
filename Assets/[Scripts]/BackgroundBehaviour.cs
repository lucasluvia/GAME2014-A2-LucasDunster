using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Bounds;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(0.0f, Bounds);
    }

    private void Move()
    {
        transform.position -= new Vector3(0.0f, Speed) * Time.deltaTime;
    }

    private void CheckBounds()
    {
        if (transform.position.y <= -Bounds)
        {
            _Reset();
        }
    }
}
