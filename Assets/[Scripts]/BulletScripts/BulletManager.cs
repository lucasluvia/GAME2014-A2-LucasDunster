using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public BulletFactory bulletFactory;
    public int MaxShotBullets;
    public int MaxBigShotBullets;

    private int Score;

    private Queue<GameObject> m_ShotBulletPool;
    private Queue<GameObject> m_BigShotBulletPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_ShotBulletPool = new Queue<GameObject>();
        m_BigShotBulletPool = new Queue<GameObject>();

        for (int count = 0; count < MaxShotBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_ShotBulletPool.Enqueue(tempBullet);
        }
        for (int count = 0; count < MaxBigShotBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet(BulletType.BIGSHOT);
            m_BigShotBulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position, BulletType type = BulletType.SHOT)
    {
        GameObject newBullet = null;
        switch (type)
        {
            case BulletType.SHOT:
                newBullet = m_ShotBulletPool.Dequeue();
                break;
            case BulletType.BIGSHOT:
                newBullet = m_BigShotBulletPool.Dequeue();
                break;
        }

        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public bool HasShotBullets()
    {
        return m_ShotBulletPool.Count > 0;
    }
    public bool HasBigShotBullets()
    {
        return m_BigShotBulletPool.Count > 0;
    }

    public void ReturnBullet(GameObject returnedBullet, BulletType type, int addScore)
    {
        returnedBullet.SetActive(false);
        switch (type)
        {
            case BulletType.SHOT:
                m_ShotBulletPool.Enqueue(returnedBullet);
                break;
            case BulletType.BIGSHOT:
                m_BigShotBulletPool.Enqueue(returnedBullet);
                break;
        }
        Score += addScore;
    }

    void Update()
    {
        scoreText.text = Score.ToString();
    }

}
