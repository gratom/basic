using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools
{
    public static class TransformTool
    {
        #region set position

        public static Transform SetPosition(this Transform transform, Vector3 Pos)
        {
            transform.position = Pos;
            return transform;
        }

        public static Transform SetPositionX(this Transform transform, float XPos)
        {
            transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
            return transform;
        }

        public static Transform SetPositionY(this Transform transform, float YPos)
        {
            transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
            return transform;
        }

        public static Transform SetPositionZ(this Transform transform, float ZPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ZPos);
            return transform;
        }

        #endregion set position

        #region offset position

        public static Transform OffsetPosition(this Transform transform, Vector3 Pos)
        {
            transform.position = transform.position + Pos;
            return transform;
        }

        public static Transform OffsetPositionX(this Transform transform, float XPos)
        {
            transform.position = new Vector3(transform.position.x + XPos, transform.position.y, transform.position.z);
            return transform;
        }

        public static Transform OffsetPositionY(this Transform transform, float YPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + YPos, transform.position.z);
            return transform;
        }

        public static Transform OffsetPositionZ(this Transform transform, float ZPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + ZPos);
            return transform;
        }

        #endregion offset position

        #region set local position

        public static Transform SetLocalPosition(this Transform transform, Vector3 Pos)
        {
            transform.localPosition = Pos;
            return transform;
        }

        public static Transform SetLocalPositionX(this Transform transform, float XPos)
        {
            transform.localPosition = new Vector3(XPos, transform.localPosition.y, transform.localPosition.z);
            return transform;
        }

        public static Transform SetLocalPositionY(this Transform transform, float YPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, YPos, transform.localPosition.z);
            return transform;
        }

        public static Transform SetLocalPositionZ(this Transform transform, float ZPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, ZPos);
            return transform;
        }

        #endregion set local position

        #region offset local position

        public static Transform OffsetLocalPosition(this Transform transform, Vector3 Pos)
        {
            transform.localPosition = transform.localPosition + Pos;
            return transform;
        }

        public static Transform OffsetLocalPositionX(this Transform transform, float XPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + XPos, transform.localPosition.y, transform.localPosition.z);
            return transform;
        }

        public static Transform OffsetLocalPositionY(this Transform transform, float YPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + YPos, transform.localPosition.z);
            return transform;
        }

        public static Transform OffsetLocalPositionZ(this Transform transform, float ZPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + ZPos);
            return transform;
        }

        #endregion offset local position

        #region truncate position

        public static Transform TruncatePositionMax(this Transform transform, Vector3 Pos)
        {
            Vector3 v = transform.position;
            v.x = v.x > Pos.x ? Pos.x : v.x;
            v.y = v.y > Pos.y ? Pos.y : v.y;
            v.z = v.z > Pos.z ? Pos.z : v.z;
            transform.position = v;
            return transform;
        }

        public static Transform TruncatePositionMin(this Transform transform, Vector3 Pos)
        {
            Vector3 v = transform.position;
            v.x = v.x < Pos.x ? Pos.x : v.x;
            v.y = v.y < Pos.y ? Pos.y : v.y;
            v.z = v.z < Pos.z ? Pos.z : v.z;
            transform.position = v;
            return transform;
        }

        public static Transform TruncateLocalPositionMax(this Transform transform, Vector3 Pos)
        {
            Vector3 v = transform.localPosition;
            v.x = v.x > Pos.x ? Pos.x : v.x;
            v.y = v.y > Pos.y ? Pos.y : v.y;
            v.z = v.z > Pos.z ? Pos.z : v.z;
            transform.localPosition = v;
            return transform;
        }

        public static Transform TruncateLocalPositionMin(this Transform transform, Vector3 Pos)
        {
            Vector3 v = transform.localPosition;
            v.x = v.x < Pos.x ? Pos.x : v.x;
            v.y = v.y < Pos.y ? Pos.y : v.y;
            v.z = v.z < Pos.z ? Pos.z : v.z;
            transform.localPosition = v;
            return transform;
        }

        public static Transform TruncateByRadius(this Transform transform, Vector3 center, float radius)
        {
            if ((transform.position - center).magnitude > radius)
            {
                transform.position = center + (transform.position - center).normalized * radius;
            }

            return transform;
        }

        public static Transform TruncateByRadiusLocal(this Transform transform, float radius)
        {
            if (transform.localPosition.magnitude > radius)
            {
                transform.localPosition = transform.localPosition.normalized * radius;
            }

            return transform;
        }

        public static Transform SetPosOnRadius(this Transform transform, Vector3 center, float radius)
        {
            transform.position = center + (transform.position - center).normalized * radius;
            return transform;
        }

        public static Transform SetPosOnRadiusLocal(this Transform transform, float radius)
        {
            transform.localPosition = transform.localPosition.normalized * radius;
            return transform;
        }

        #endregion truncate position

        public static Transform SetRotation(this Transform transform, Vector3 Rot)
        {
            transform.rotation = Quaternion.Euler(Rot);
            return transform;
        }

        public static Transform SetRotationX(this Transform transform, float XRot)
        {
            transform.rotation = Quaternion.Euler(new Vector3(XRot, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
            return transform;
        }

        public static Transform SetRotationY(this Transform transform, float YRot)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, YRot, transform.rotation.eulerAngles.z));
            return transform;
        }

        public static Transform SetRotationZ(this Transform transform, float ZRot)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, ZRot));
            return transform;
        }

        public static RectTransform CopyValuesFrom(this RectTransform transform, RectTransform other)
        {
            transform.anchorMin = other.anchorMin;
            transform.anchorMax = other.anchorMax;
            transform.anchoredPosition = other.anchoredPosition;
            transform.sizeDelta = other.sizeDelta;
            transform.pivot = other.pivot;
            return transform;
        }

        public static string GetHashPos(this Transform transform, string accuracy = "0.000")
        {
            Vector3 pos = transform.position;
            string basic = pos.x.ToString(accuracy) + pos.y.ToString(accuracy) + pos.z.ToString(accuracy);
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(basic));
            return BitConverter.ToString(hashBytes, 0).Replace("-", string.Empty);
        }

        public static void DestroyAllChildren(this Transform transform)
        {
            // Iterate through all the child transforms and destroy them
            foreach (Transform child in transform)
            {
                Object.Destroy(child.gameObject);
            }
        }

        // Extension method to find the first GameObject in children based on a condition
        public static GameObject FirstGOinChild(this Transform parent, Func<GameObject, bool> selector)
        {
            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            foreach (Transform child in parent)
            {
                GameObject childGO = child.gameObject;
                if (selector(childGO))
                {
                    return childGO;
                }
            }

            return null;
        }

        // Extension method to find all GameObjects in children based on a condition
        public static List<GameObject> Where(this Transform parent, Func<GameObject, bool> selector)
        {
            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            List<GameObject> result = new List<GameObject>();

            foreach (Transform child in parent)
            {
                GameObject childGO = child.gameObject;
                if (selector(childGO))
                {
                    result.Add(childGO);
                }
            }

            return result;
        }
    }
}
