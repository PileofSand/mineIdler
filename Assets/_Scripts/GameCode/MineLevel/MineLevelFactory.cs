using GameCode.Elevator;
using GameCode.Finance;
using GameCode.Init;
using GameCode.Mineshaft;
using GameCode.Tutorial;
using GameCode.UI;
using GameCode.Warehouse;
using UniRx;
using UnityEngine;

namespace GameCode.MineLevel
{
    public class MineLevelFactory : IMineLevelFactory
    {
        private readonly GameConfig _config;
        private readonly CompositeDisposable _disposable;
        private readonly MineLevelView _mineLevelView;
        private readonly MineLevelsCollection _collection;
        private readonly ITutorialModel _tutorialModel;

        public MineLevelFactory(MineLevelView mineLevelView, ITutorialModel tutorialModel, GameConfig config, CompositeDisposable disposable, MineLevelsCollection collection)
        {
            _mineLevelView = mineLevelView;
            _tutorialModel = tutorialModel;
            _config = config;
            _disposable = disposable;
            _collection = collection;
        }

        public void CreateMine(int levelID, string title, string description)
        {
            var mineLevel = Object.Instantiate(_mineLevelView);          
            var minelevelModel = new MineLevelModel(levelID, title, description);
            var mineController = new MineLevelController(mineLevel, minelevelModel);
            var financeModel = new FinanceModel();

            new HudController(mineLevel.HubView, financeModel, _tutorialModel, _disposable);

            //Mineshaft
            var mineshaftCollectionModel = new MineshaftCollectionModel();
            var mineshaftFactory = new MineshaftFactory(mineshaftCollectionModel, financeModel, _config, _disposable, mineLevel.transform);
            mineshaftFactory.CreateMineshaft(1, 1, mineLevel.MineshaftStartingPosition.position);

            //Elevator
            var elevatorModel = new ElevatorModel(levelID, _config, financeModel, _disposable);
            new ElevatorController(mineLevel.ElevatorView, elevatorModel, mineshaftCollectionModel, _config, _disposable);

            //Warehouse
            var warehouseModel = new WarehouseModel(levelID, _config, financeModel, _disposable);
            new WarehouseController(mineLevel.WarehouseView, warehouseModel, elevatorModel, _config, _disposable);

            _collection.RegisterMine(levelID, mineController);
        }


    }
}