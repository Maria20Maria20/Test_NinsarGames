using System.Collections;
using System.Collections.Generic;
using Test_NinsarGames.Scripts.Gameplay;
using UnityEngine;
using Zenject;


namespace Test_NinsarGames.Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GridController gridController;
        public override void InstallBindings()
        {
            Container.BindInstance(gridController);
        }
    }
}

