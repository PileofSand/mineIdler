using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCode.MineLevel
{
    public class MineLevelsCollection
    {
        private readonly Dictionary<int, MineLevelController> _mineControllers;

        public MineLevelsCollection()
        {
            _mineControllers = new Dictionary<int, MineLevelController>();
        }

        public void ActivateLevel(int id)
        {
            foreach (var levelController in _mineControllers)
            {
                if (levelController.Key == id)
                {
                    levelController.Value.SetLevelActive(true);
                }
                else
                {
                    levelController.Value.SetLevelActive(false);
                }
            }
        }

        public void RegisterMine(int mineshaftNumber, MineLevelController controller)
        {
            _mineControllers.Add(mineshaftNumber, controller);
        }

        public int GetCount()
        {
            return _mineControllers.Count;
        }

        public MineLevelModel GetModel(int mineshaftNumber)
        {
            return _mineControllers[mineshaftNumber].GetModel();
        }

        public MineLevelView GetView(int mineshaftNumber)
        {
            return _mineControllers[mineshaftNumber].GetView();
        }

    }
}