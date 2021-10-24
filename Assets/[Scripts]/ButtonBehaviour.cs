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

    [Header("Audio")]
    public AudioSource ShotFired;

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
            ShotFired.Play();
            bulletManager.GetBullet(playerBulletSpawn.transform.position);
        }

    }
}
