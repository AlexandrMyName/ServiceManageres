using Game.Models.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    internal class ItemView : MonoBehaviour, IItemView
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        [SerializeField] private GameObject _selectedBackGround;
        [SerializeField] private GameObject _unselectedBackGround;


        private void OnDestroy()
        {
            DeInit();
        }
        public void Init(IItem item, UnityAction clickAction)
        {
            _text.text = item.Info.Title;
            _icon.sprite = item.Info.Icon;
            _button.onClick.AddListener(clickAction);
        }
        public void DeInit()
        {
            _text.text = string.Empty;
            _icon.sprite = null;
            _button.onClick.RemoveAllListeners();
        }
        public void Select() => SetSelected(true);
        public void Unselect() => SetSelected(false);
        private void SetSelected(bool isSelect)
        {
            _selectedBackGround.SetActive(isSelect);
            _unselectedBackGround.SetActive(!isSelect);
        }

    }
}