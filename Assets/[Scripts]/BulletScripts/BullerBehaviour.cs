using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BullerBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public BulletManager bulletManager;
    public int damage;

    private int Score = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private BulletType type = BulletType.SHOT;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        if (Score > 0)
        {
            scoreText.text = Score.ToString();
        }

    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.y > verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject, type, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Score += 100;
        }
        if (other.gameObject.layer == 7)
        {
            Score += 30;
        }
        if (other.gameObject.tag == "damager")
        {
            bulletManager.ReturnBullet(gameObject, type, Score);
        }
    }
}

