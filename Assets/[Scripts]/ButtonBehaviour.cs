using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private int buttonDestination = 0;
    [SerializeField]
    private Rigidbody2D playerRB = null;


    public void OnButtonPressed()
    {
        SceneManager.LoadScene(buttonDestination);
    }
    public void OnLeftPressed()
    {
        MoveCharacter(-1.0f);
    }

    public void OnRightPressed()
    {
        MoveCharacter(1.0f);
    }

    private void MoveCharacter(float direction)
    {
        Vector2 newVelocity = playerRB.velocity + new Vector2(direction * 2.0f, 0.0f);
        playerRB.velocity = Vector2.ClampMagnitude(newVelocity, 6.0f);
        playerRB.velocity *= 0.99f;
    }

}
