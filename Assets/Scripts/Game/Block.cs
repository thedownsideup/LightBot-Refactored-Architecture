using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Transform glowingBlockPrefab;
    private Level_Manager levelManager;
    public void Light()
    {
        GetLevelManager();
        Transform glowingBlock = Instantiate(glowingBlockPrefab, transform.parent.transform);
        glowingBlock.position = transform.position;
        
        levelManager.CountLitBlocks();
        
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    private void GetLevelManager()
    {
        levelManager = GameObject.Find("Level_Manager").GetComponent<Level_Manager>();
        if (levelManager == null)
        {
            Debug.LogError("Level Manager Is Empty");
        }
    }
}
