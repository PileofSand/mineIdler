using GameCode.CameraRig;
using GameCode.Elevator;
using GameCode.Finance;
using GameCode.MineLevel;
using GameCode.Mineshaft;
using GameCode.Tutorial;
using GameCode.UI;
using GameCode.Warehouse;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace GameCode.Init
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private HudView _hudView;
        [SerializeField] private CameraView _cameraView;
        [SerializeField] private MineLevelView _mineLevelView;

        private MineLevelsCollection _mineLevelCollection;

        private void Start()
        {
            var disposable = new CompositeDisposable().AddTo(this);

            var tutorialModel = new TutorialModel();
            var financeModel = new FinanceModel();
            
            new CameraController(_cameraView, tutorialModel);

            //Hud
            new HudController(_hudView, financeModel, tutorialModel, disposable);

            //MineLevel
            _mineLevelCollection = new MineLevelsCollection();
            var mineLevelFactory = new MineLevelFactory(_mineLevelView, financeModel, _gameConfig, disposable, _mineLevelCollection);

            mineLevelFactory.CreateMine(1);
            mineLevelFactory.CreateMine(2);
            _mineLevelCollection.ActivateLevel(1);
        }

        public void ActivateMine(int id)
        {
            _mineLevelCollection.ActivateLevel(id);
        }
    }
}