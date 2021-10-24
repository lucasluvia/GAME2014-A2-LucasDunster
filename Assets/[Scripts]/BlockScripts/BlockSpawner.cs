using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Bounds;
    [SerializeField]
    private float Direction;
    [SerializeField]
    private float SpawnDelay;

    public BlockManager blockManager;

    void Update()
    {
        Move();
        CheckBounds();
        SpawnBlock();
    }

    private void Move()
    {
        transform.position += new Vector3(Speed * Direction * Time.deltaTime, 0.0f, 0.0f);
    }

    private void CheckBounds()
    {
        if (transform.position.x >= Bounds)
        {
            Direction = -1.0f;
        }

        if (transform.position.x <= -Bounds)
        {
            Direction = 1.0f;
        }
    }

    private void SpawnBlock()
    {
        // delay bullet firing 
        if (blockManager.HasBlocks() && Time.frameCount % SpawnDelay == 0)
        {
            blockManager.GetBlock(transform.position);
        }
    }
}
