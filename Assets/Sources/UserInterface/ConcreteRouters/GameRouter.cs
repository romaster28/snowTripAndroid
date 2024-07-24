﻿using Sources.UserInterface.ConcreteScreens.Game;

namespace Sources.UserInterface.ConcreteRouters
{
    public class GameRouter : BaseRouter
    {
        protected override void OnInitialized()
        {
            Screens.Open<CharacterControlScreen>();
        }
    }
}