using UnityEngine;
using UnityEngine.UI;

namespace GameCode.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button _mineSelectionButton;
        [SerializeField] private MineSelectionUIController _mineSelection;

        void Start()
        {
            _mineSelectionButton.onClick.AddListener(() =>
            {
                _mineSelection.ShowPanel();
            });
        }
    }
}