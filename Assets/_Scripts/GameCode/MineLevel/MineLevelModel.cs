using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCode.MineLevel
{
    public class MineLevelModel 
    {
        private int _mineLevelID;
        private bool _isActive;
        private string _title;
        private string _description;

        public int MineLevelID { get => _mineLevelID; set => _mineLevelID = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public string Title => _title;
        public string Description => _description;

        public MineLevelModel(int levelID, string title, string description)
        {
            _mineLevelID = levelID;
            _title = title;
            _description = description;
        }
    }
}
