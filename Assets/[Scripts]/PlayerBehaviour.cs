using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool isMouse = false;
    [SerializeField]
    private float screenBound;
    [SerializeField]
    private GameObject playerBulletSpawn = null;
    [SerializeField]
    private TextMeshProUGUI LivesText;
    [Range(0.0f, 5.0f)]
    public float seconds = 0.5f;
    public UnityEvent onPressedOverSeconds = new UnityEvent();

    public BulletManager bulletManager;


    private Rigidbody2D body;
    private Animator anim;

    [SerializeField]
    private int lives = 3;
    private Vector3 m_touchesEnded;
    private float time = 0.0f;

    private bool canBigShoot = false;

    [Header("Audio")]
    public AudioSource BigShotFired;
    public AudioSource PlayerHit;



    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        CheckBounds();

        LivesText.text = lives.ToString();

        if(lives < 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void GetInput()
    {
        float direction = 0.0f;

        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            if (worldTouch.y < 3.9f)
            {
                if (worldTouch.x > 1.45f)
                {
                    Debug.Log("Right");
                    direction = 1.0f;
                }

                if (worldTouch.x < -1.45f)
                {
                    Debug.Log("Left");
                    direction = -1.0f;
                }

                if(worldTouch.x >-1.45 && worldTouch.x < 1.45)
                {
                    StartCoroutine(TrackTimePressed());
                    canBigShoot = true;
                }
            }
            m_touchesEnded = worldTouch;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Debug.Log("Fire Touch Up");
            time = 0.0f;
            canBigShoot = false;
            StopAllCoroutines();
        }

        if (isMouse)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMouse = true;
                Vector3 mousePosition = Input.mousePosition;
                if (mousePosition.y < 375.0f)
                {
                    if (mousePosition.x > 1120.0f)
                    {
                        Debug.Log("Right");
                        direction = 1.0f;
                    }

                    if (mousePosition.x < 308.0f)
                    {
                        Debug.Log("Left");
                        direction = -1.0f;
                    }

                    if (mousePosition.x > 375.0f && mousePosition.x < 1120.0f)
                    {
                        StartCoroutine(TrackTimePressed());
                        canBigShoot = true;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Mouse Up");
                time = 0.0f;
                canBigShoot = false;
                StopAllCoroutines();
            }
        }
        
        Move(direction);

    }


    private void Move(float direction)
    {
        float speed = 0.5f;
        if(isMouse)
        {
            speed = 3.5f;
        }
        Vector2 newVelocity = body.velocity + new Vector2(direction * speed, 0.0f);
        body.velocity = Vector2.ClampMagnitude(newVelocity, 6.0f);
        body.velocity *= 0.95f;
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
        if (other.gameObject.tag == "damager")
        {
            lives--;
            anim.SetInteger("Lives", lives);
            PlayerHit.Play();
        }

    }

    private IEnumerator TrackTimePressed()
    {
        time = 0.0f;

        while (time < this.seconds)
        {
            time += Time.deltaTime;
            yield return null;
        }
        
        if(canBigShoot)
        {
            FireBigShot();
        }

    }

    private void FireBigShot(BulletType type = BulletType.BIGSHOT)
    {
        BigShotFired.Play();
        Debug.Log("BIGSHOT");
        if (bulletManager.HasBigShotBullets())
        {
            bulletManager.GetBullet(playerBulletSpawn.transform.position, type);
        }
        StopAllCoroutines();
    }


    
}