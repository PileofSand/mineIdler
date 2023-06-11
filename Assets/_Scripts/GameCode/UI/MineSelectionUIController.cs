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
    public class MineSelectionUIController : MonoBehaviour
    {
        [SerializeField] private MineUIElement _mineUIElement;
        [SerializeField] private Button _mineSelectionExitButton;
        [SerializeField] private Transform _mineUIParent;

        private MineLevelsCollection _mineLevelsCollection;


        private void Start()
        {
            CreateMineUIElements();
            _mineSelectionExitButton.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
            });
        }

        private void CreateMineUIElements()
        {
            for (int i = 1; i <= _mineLevelsCollection.GetCount(); i++)
            {
                var mineUI = Instantiate(_mineUIElement, _mineUIParent);
                mineUI.Initialise(_mineLevelsCollection.GetModel(i).Title, _mineLevelsCollection.GetModel(i).Description, i, SelectMine);
            }
        }

        private void SelectMine(int id)
        {
            _mineLevelsCollection.ActivateLevel(id);
            gameObject.SetActive(false);
        }

        [Inject]
        private void Inject(MineLevelsCollection mineLevelsCollection)
        {
            _mineLevelsCollection = mineLevelsCollection;
        }

    }
}