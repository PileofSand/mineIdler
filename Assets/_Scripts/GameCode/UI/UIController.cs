using GameCode.MineLevel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace GameCode.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button _mineSelectionButton;
        [SerializeField] private GameObject _mineSelection;

        private void Start()
        {
            _mineSelectionButton.onClick.AddListener(() =>
            {
                _mineSelection.SetActive(true);
            });
        }

    }
}