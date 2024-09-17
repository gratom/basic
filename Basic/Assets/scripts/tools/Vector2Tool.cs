using UnityEngine;

namespace Tools
{
    public static class Vector2Tool
    {
        public static Vector2 ScreenToLocalByRect(this Vector2 origin, RectComponent rect)
        {
            return rect.World2Local(origin);
        }

        public static Vector2Int ToInt(this Vector2 origin)
        {
            Vector2 v1 = new Vector2();
            return new Vector2Int(Mathf.RoundToInt(origin.x), Mathf.RoundToInt(origin.y));
        }

        public static Vector3 ToX0Y(this Vector2 v)
        {
            return new Vector3(v.x, 0, v.y);
        }

        public static Vector3 ToXZY(this Vector2 v, float Z)
        {
            return new Vector3(v.x, Z, v.y);
        }

        public static Vector3 To0XY(this Vector2 v)
        {
            return new Vector3(0, v.x, v.y);
        }

        public static Vector3 ToZXY(this Vector2 v, float Z)
        {
            return new Vector3(Z, v.x, v.y);
        }

        public static Vector3 ToXY0(this Vector2 v)
        {
            return new Vector3(v.x, v.y, 0);
        }

        public static Vector3 ToXYZ(this Vector2 v, float Z)
        {
            return new Vector3(v.x, v.y, Z);
        }

        public static Vector2 ToXZ(this Vector3 v)
        {
            return new Vector2(v.x, v.z);
        }

        public static Vector2 ToXY(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

    }
}
