using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject Shot;
    public GameObject BigShot;

    public GameObject createBullet(BulletType type = BulletType.SHOT)
    {
        GameObject tempBullet = null;
        switch (type)
        {
            case BulletType.SHOT:
                tempBullet = Instantiate(Shot);
                tempBullet.GetComponent<BullerBehaviour>().damage = 1;
                break;
            case BulletType.BIGSHOT:
                tempBullet = Instantiate(BigShot);
                tempBullet.GetComponent<BullerBehaviour>().damage = 3;
                break;
        }

        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);

        return tempBullet;
    }
}
