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
using Zenject;

namespace GameCode.Init
{
    public class GameInitializer : MonoBehaviour
    {
        private MineLevelFactory _mineLevelFactory;
        private MineLevelsCollection _mineLevelCollection;
        private CameraController _cameraController;

        private void Awake()
        {
            //TODO: Get data for title and description from scriptable objects or other source.
            _mineLevelFactory.CreateMine(1, "Mine 1", "This is your first mine in which you start of your tycoon journey");
            _mineLevelFactory.CreateMine(2, "Mine 2", "So exciting: A second mine!");
            _mineLevelCollection.ActivateLevel(1);
        }


        [Inject]
        private void Construct(MineLevelsCollection mineLevelsCollection, MineLevelFactory mineLevelFactory, CameraController cameraController)
        {
            _mineLevelFactory = mineLevelFactory;
            _mineLevelCollection = mineLevelsCollection;
            _cameraController = cameraController;
        }
    }
}