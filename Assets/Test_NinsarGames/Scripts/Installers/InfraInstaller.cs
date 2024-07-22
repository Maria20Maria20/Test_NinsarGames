using Test_NinsarGames.Scripts.Factories;
using Test_NinsarGames.Scripts.Inputs;
using Zenject;

namespace Test_NinsarGames.Scripts.Installers
{
    public class InfraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
            BindFactories();
        }
        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<GameObjectCreator>().AsSingle();        
        }
        private void BindServices()
        {
            Container.Bind<InputService>().AsSingle().NonLazy();
        }
    }

}
