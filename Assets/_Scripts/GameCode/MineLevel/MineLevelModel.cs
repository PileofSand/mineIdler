using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCode.MineLevel
{
    public class MineLevelModel 
    {
        private int _mineLevelID;
        private bool _isActive;

        public int MineLevelID { get => _mineLevelID; set => _mineLevelID = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }

        public MineLevelModel(int levelID)
        {
            _mineLevelID = levelID;
        }
    }
}
