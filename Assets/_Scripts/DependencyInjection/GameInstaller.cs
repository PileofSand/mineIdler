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
            //TODO: Seperate Installers to multiple files.
            Container.Bind<MineLevelsCollection>().To<MineLevelsCollection>().AsSingle();
            Container.Bind<TutorialModel>().To<TutorialModel>().AsSingle();
            Container.Bind<CameraController>().To<CameraController>().AsSingle();
            Container.Bind<CompositeDisposable>().To<CompositeDisposable>().AsSingle();
            Container.Bind<CameraView>().To<CameraView>().AsSingle();
            Container.Bind<MineLevelFactory>().To<MineLevelFactory>().AsSingle().NonLazy();
            Container.BindInstances(_gameConfig, _mineLevelView);
        }
    }
}