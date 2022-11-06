using System;
using System.Collections.Generic;
using CommandSystem.Presentation;

namespace CommandSystem
{
    public class CommandLayerController
    {
        private CommandManagerPresentation commandManagerPresentation;
        
        public void InitializeCommandLayer(List<Type> availableCommandsTypes)
        {
            commandManagerPresentation = new CommandLayerFactory().CreateCommandManagerPresentation(availableCommandsTypes);
        }
    }
}
