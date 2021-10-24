using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private int buttonDestination = 0;


    public void OnButtonPressed()
    {
        SceneManager.LoadScene(buttonDestination);
    }
}
