using System;
using Tools;
using UnityEngine;

namespace Tools
{
    public class Dragable3D : MonoBehaviour
    {
        public bool IsMouseOverObject()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                return hit.collider.gameObject == gameObject;
            }

            return false;
        }
    }
}
