﻿using Hardware.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;

namespace Hardware
{
    public class ChillerHardwareModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ChillerHardwareView>();
        }
    }
}
