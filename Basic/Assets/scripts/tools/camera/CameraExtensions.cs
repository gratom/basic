using UnityEngine;

namespace Tools
{
    public static class CameraExtensions
    {
        public static Vector3[] GetFrustumCorners(this Camera camera)
        {
            Vector3[] frustumCorners = new Vector3[4];
            camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
            for (int i = 0; i < frustumCorners.Length; i++)
            {
                frustumCorners[i] = camera.transform.TransformVector(frustumCorners[i]) + camera.transform.position;
            }
            return frustumCorners;
        }

        public static Vector3[] GetFrustumVectors(this Camera camera)
        {
            Vector3[] frustumCorners = new Vector3[4];
            camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
            for (int i = 0; i < frustumCorners.Length; i++)
            {
                frustumCorners[i] = camera.transform.TransformVector(frustumCorners[i]);
            }
            return frustumCorners;
        }

        public static Vector3 GetPointIntersectionOnPlane(this Plane plane, Vector3 startPoint, Vector3 direction)
        {
            if (plane.Raycast(new Ray(startPoint, direction), out float distance))
            {
                return startPoint + direction.normalized * distance;
            }
            return Vector3.zero;
        }

        public static Vector3[] GetFrustumDotsIntersections(this Camera camera, Plane plane)
        {
            Vector3[] v = camera.GetFrustumVectors();

            Vector3[] vRet = new Vector3[4];

            for (int i = 0; i < vRet.Length; i++)
            {
                vRet[i] = plane.GetPointIntersectionOnPlane(camera.transform.position, v[i]);
            }
            return vRet;
        }
    }
}
