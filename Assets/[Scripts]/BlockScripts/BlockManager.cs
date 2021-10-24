using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public BlockFactory blockFactory;
    public int MaxBlocks;

    private Queue<GameObject> m_BlockPool;

    // Start is called before the first frame update
    void Start()
    {
        _BuildBlockPool();
    }

    private void _BuildBlockPool()
    {
        // create empty Queue structure
        m_BlockPool = new Queue<GameObject>();

        for (int count = 0; count < MaxBlocks; count++)
        {
            var tempBlock = blockFactory.createBlock();
            m_BlockPool.Enqueue(tempBlock);
        }
    }

    public GameObject GetBlock(Vector3 position)
    {
        var newBlock = m_BlockPool.Dequeue();
        newBlock.SetActive(true);
        newBlock.transform.position = position;
        return newBlock;
    }

    public bool HasBlocks()
    {
        return m_BlockPool.Count > 0;
    }

    public void ReturnBlock(GameObject returnedBlock)
    {
        returnedBlock.SetActive(false);
        m_BlockPool.Enqueue(returnedBlock);

    }
}
