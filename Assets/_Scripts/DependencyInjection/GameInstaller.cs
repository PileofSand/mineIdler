using Zenject;
using UnityEngine;
using GameCode.MineLevel;
using GameCode.Tutorial;
using GameCode.CameraRig;
using UniRx;
using GameCode.Init;

namespace GameCode.Injection
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private MineLevelView _mineLevelView;

        public override void InstallBindings()
        {
            //TODO seperate installers to external files and change binding for Interfaces rather than classes to make it more modular.
            Container.Bind<MineLevelsCollection>().AsSingle();
            Container.Bind<ITutorialModel>().To<TutorialModel>().AsSingle();
            Container.Bind<CameraView>().To<CameraView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CameraController>().AsSingle();
            Container.Bind<CompositeDisposable>().AsSingle();
            Container.Bind<MineLevelFactory>().AsSingle().NonLazy();
            Container.BindInstances(_gameConfig, _mineLevelView);
        }
    }
}