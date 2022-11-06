using System;
using System.Collections.Generic;
using CommandSystem;
using CommandSystem.Logic.Commands;
using Foundation.ConfigurationSystem;
using Foundation.ScheduleSystem;
using Foundation.ServiceLocator;
using Level;
using UnityEngine;

public class God : MonoBehaviour
{
    private readonly CommandLayerController commandLayerController = new CommandLayerController();
    private readonly LevelLayerController levelLayerController = new LevelLayerController();
    private void Start()
    {
        InitializeServiceLocator();
        CreateServices();
        
        InitializeLayers();
    }

    private void InitializeServiceLocator()
    {
        ServiceLocator.Init();
    }
    
    private void CreateServices()
    {
        ServiceLocator.AddService(new ConfigurationManager());
        ServiceLocator.AddService(new Scheduler());
    }
    
    private void InitializeLayers()
    {
        levelLayerController.InitializeLevelLayer();
        commandLayerController.InitializeCommandLayer(levelLayerController.GetAvailableCommands());
    }

    private void Setup()
    {
                
    }
}