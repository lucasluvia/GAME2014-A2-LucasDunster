using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField]
    private int state;
    [SerializeField]
    private bool isExample = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isExample)
        {

        }

        if(state > 2)
        {
            //destroy
        }
        animator.SetInteger("Damage", state);
    }
}
