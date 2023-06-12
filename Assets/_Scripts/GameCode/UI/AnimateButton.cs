using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Button Animation Settings")]
    [SerializeField] private RectTransform _rectTranform;
    [SerializeField] private float _moveDistance = 5f;
    [SerializeField] private float _moveDuration = 0.5f;
    [SerializeField] private Button _button;

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            _rectTranform.DOAnchorPosY(_moveDistance, _moveDuration);
        }  
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            _rectTranform.DOAnchorPosY(0f, _moveDuration);
        }
    }
}
