using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools
{
    public class Dragable : DragInfo, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public Dragable3D dragable3D;

        private bool isDrag;

        public void OnDrag(PointerEventData eventData)
        {
            if (dragable3D.IsMouseOverObject() && isDrag)
            {
                OnDrag(eventData.delta);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (dragable3D.IsMouseOverObject())
            {
                isDrag = true;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isDrag = false;
        }
    }

    public abstract class DragInfo : MonoBehaviour
    {
        public event Action<Vector2> OnDragAction;

        protected void OnDrag(Vector2 v)
        {
            OnDragAction?.Invoke(v);
        }

    }
}
