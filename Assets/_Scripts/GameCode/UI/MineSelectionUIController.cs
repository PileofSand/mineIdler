using DG.Tweening;
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
        [SerializeField] private RectTransform _rectTransform;

        [Header("Darken Settings")]
        [SerializeField] private Image _darkenBackground;
        [SerializeField] [Range(0f, 1f)] private float _darkenAmount;

        private MineLevelsCollection _mineLevelsCollection;
        private List<MineUIElement> _mineElements = new List<MineUIElement>();
        private Vector3 _onScreenPosition;
        private Vector3 _offScreenPosition;
        private bool _isActive;

        public RectTransform RectTransform => _rectTransform;
        public bool IsActive => _isActive;

        private void Start()
        {
            InitaliseMineUI();
            SelectMine(1);
            _mineSelectionExitButton.onClick.AddListener(() =>
            {
                HidePanel();
            });

            _onScreenPosition = new Vector3(_rectTransform.sizeDelta.x / 2, _rectTransform.anchoredPosition.y, 0);
            _offScreenPosition = _rectTransform.anchoredPosition;
        }

        private void OnDestroy()
        {
            DeinitialiseMineUI();
        }

        public void ShowPanel()
        {
            if (IsActive)
            {
                return;
            }

            _isActive = true;
            _darkenBackground.raycastTarget = true;
            _darkenBackground.DOFade(_darkenAmount, 1f);
            _rectTransform.DOAnchorPos(_onScreenPosition, 1.0f);
        }

        public void HidePanel()
        {
            if (!IsActive)
            {
                return;
            }

            _isActive = false;
            _darkenBackground.raycastTarget = false;
            _darkenBackground.DOFade(0f, 1f);
            _rectTransform.DOAnchorPos(_offScreenPosition, 1.0f);
        }

        private void InitaliseMineUI()
        {
            for (int i = 1; i <= _mineLevelsCollection.GetCount(); i++)
            {
                MineUIElement mineUI = Instantiate(_mineUIElement, _mineUIParent);
                mineUI.Initialise(_mineLevelsCollection.GetModel(i).Title, _mineLevelsCollection.GetModel(i).Description, i, SelectMine);
                _mineElements.Add(mineUI);
            }
        }

        private void DeinitialiseMineUI()
        {
            for (int i = 0; i < _mineElements.Count; i++)
            {
                MineUIElement mineUI = _mineElements[i];
                mineUI.Deinitialise();
                Destroy(mineUI);
            }
            _mineElements.Clear();
        }

        private void SelectMine(int id)
        {
            _mineLevelsCollection.ActivateLevel(id);          
            HidePanel();
            RefreshButtons(id);
        }

        private void RefreshButtons(int id)
        {
            foreach (var mineUI in _mineElements)
            {
                if (mineUI.Id == id)
                {
                    mineUI.MineButton.interactable = false;
                }
                else
                {
                    mineUI.MineButton.interactable = true;
                }
            }
        }

        [Inject]
        private void Inject(MineLevelsCollection mineLevelsCollection)
        {
            _mineLevelsCollection = mineLevelsCollection;
        }

    }
}