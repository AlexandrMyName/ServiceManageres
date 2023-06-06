using Game.Models.Items;
using UnityEngine.Events;

namespace UI
{
    internal interface IItemView
    {
        void Init(IItem item, UnityAction clickAction);
        void Select();
        void Unselect();
    }
}