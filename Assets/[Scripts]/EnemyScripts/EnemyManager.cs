using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public int MaxEnemies;

    private Queue<GameObject> m_EnemyPool;

    // Start is called before the first frame update
    void Start()
    {
        _BuildEnemyPool();
    }

    private void _BuildEnemyPool()
    {
        // create empty Queue structure
        m_EnemyPool = new Queue<GameObject>();

        for (int count = 0; count < MaxEnemies; count++)
        {
            var tempEnemy = enemyFactory.createEnemy();
            m_EnemyPool.Enqueue(tempEnemy);
        }
    }

    public GameObject GetEnemy(Vector3 position)
    {
        var newEnemy = m_EnemyPool.Dequeue();
        newEnemy.SetActive(true);
        newEnemy.transform.position = position;
        return newEnemy;
    }

    public bool HasEnemies()
    {
        return m_EnemyPool.Count > 0;
    }

    public void ReturnEnemy(GameObject returnedEnemy)
    {
        returnedEnemy.SetActive(false);
        m_EnemyPool.Enqueue(returnedEnemy);

    }
}
