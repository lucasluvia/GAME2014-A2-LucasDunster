using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    public int state = 0;
    [SerializeField]
    private bool isExample = false;
    [SerializeField]
    private float Speed;

    public BlockManager blockManager;
    private Animator animator;

    void Start()
    {
        blockManager = FindObjectOfType<BlockManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isExample)
        {
            Move();
        }


        if (state > 2)
        {
            blockManager.ReturnBlock(gameObject);
            state = 0;
        }
        animator.SetInteger("Damage", state);
    }

    private void Move()
    {
        transform.position += new Vector3(0.0f, Speed, 0.0f) * Time.deltaTime;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shotBullet")
        {
            state++;
        }
        if (other.gameObject.tag == "Sam" || other.gameObject.tag == "bigShotBullet")
        {
            state = 3;
        }
    }
}
