using System;
using UnityEngine;

namespace Tools
{
    [Serializable]
    public struct Rect3D
    {
        public Vector3 bottomLeft;
        public Vector3 bottomRight;
        public Vector3 topRight;
        public Vector3 topLeft;

        public Rect3D(Vector3 bottomLeft, Vector3 bottomRight, Vector3 topRight, Vector3 topLeft)
        {
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
            this.topRight = topRight;
            this.topLeft = topLeft;
        }

        public Rect3D(Vector3[] v)
        {
            bottomLeft = v[0];
            bottomRight = v[1];
            topRight = v[2];
            topLeft = v[3];
        }

        public Vector3 this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return bottomLeft;
                    case 1: return bottomRight;
                    case 2: return topRight;
                    case 3: return topLeft;
                    default: return Vector3.zero;
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        bottomLeft = value;
                        break;
                    case 1:
                        bottomRight = value;
                        break;
                    case 2:
                        topRight = value;
                        break;
                    case 3:
                        topLeft = value;
                        break;
                }
            }
        }

        public void DrawGizmos()
        {
            Gizmos.DrawLine(bottomLeft, bottomRight);
            Gizmos.DrawLine(bottomRight, topRight);
            Gizmos.DrawLine(topRight, topLeft);
            Gizmos.DrawLine(topLeft, bottomLeft);
        }

        public Plane Plane()
        {
            return new Plane(bottomLeft, bottomRight, topLeft);
        }
    }
}
