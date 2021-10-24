using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Bounds;
    [SerializeField]
    private float Direction;
    [SerializeField]
    private float BlockDelay;
    [SerializeField]
    private float EnemyDelay;

    public BlockManager blockManager;
    public EnemyManager enemyManager;

    void Update()
    {
        Move();
        CheckBounds();
        SpawnBlock();
        SpawnEnemy();
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
        if (blockManager.HasBlocks() && Time.frameCount % BlockDelay == 0)
        {
            blockManager.GetBlock(transform.position);
        }
    }

    private void SpawnEnemy()
    {
        if (enemyManager.HasEnemies() && Time.frameCount % EnemyDelay == 0)
        {
            enemyManager.GetEnemy(transform.position);
        }
    }
}
