using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    public GameObject Block;

    public GameObject createBlock()
    {
        GameObject tempBlock = null;
        
        tempBlock = Instantiate(Block);
        tempBlock.GetComponent<BlockBehaviour>().state = 0;
        
        tempBlock.transform.parent = transform;
        tempBlock.SetActive(false);

        return tempBlock;
    }
}
