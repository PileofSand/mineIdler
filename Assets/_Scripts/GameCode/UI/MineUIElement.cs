using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;

namespace GameCode.UI
{
    public class MineUIElement : MonoBehaviour
    {
        [SerializeField] private Button _mineButton;
        [SerializeField] private TextMeshProUGUI _titleField;
        [SerializeField] private TextMeshProUGUI _descriptionField;
        private int _id;

        public int Id => _id;

        public Button MineButton => _mineButton;

        public void Initialise(string title, string description, int id, Action<int> changeLevelAction)
        {
            _id = id;
            MineButton.onClick.AddListener(() => changeLevelAction(_id));
            _titleField.text = title;
            _descriptionField.text = description;
        }

        public void Deinitialise()
        {
            MineButton.onClick.RemoveAllListeners();
        }
    }
}