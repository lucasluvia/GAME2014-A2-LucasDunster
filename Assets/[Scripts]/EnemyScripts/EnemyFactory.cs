using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Enemy;

    public GameObject createEnemy()
    {
        GameObject tempEnemy = null;

        tempEnemy = Instantiate(Enemy);

        tempEnemy.transform.parent = transform;
        tempEnemy.SetActive(false);

        return tempEnemy;
    }
}
