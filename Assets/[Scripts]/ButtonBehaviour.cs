using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private int buttonDestination = 0;
    [SerializeField]
    private GameObject playerBulletSpawn = null;

    public BulletManager bulletManager;

    public void OnButtonPressed()
    {
        SceneManager.LoadScene(buttonDestination);
        
    }

    public void OnFire()
    {
        Debug.Log("Fire Shot");
        if(bulletManager.HasShotBullets())
        {
            bulletManager.GetBullet(playerBulletSpawn.transform.position);
        }

    }
}
