using System.Collections;
using System.Collections.Generic;
using Game.CommandSystem;
using UnityEngine;

public class God : MonoBehaviour
{
    private Character character = new Character();

    private CommandLayerController commandLayerController = new CommandLayerController();
    private void Start()
    {
        commandLayerController.InitializeCommandLayer();
    }
    
    private void Update()
    {
        
    }
}
