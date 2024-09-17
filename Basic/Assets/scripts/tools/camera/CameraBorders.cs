using System;
using Tools;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraBorders : MonoBehaviour
{
    public SpriteRendererBorders borders;
    public Camera thisCamera;

    private Rect3D rectBorders => borders.rect;

    private void OnValidate()
    {
        if (thisCamera == null)
        {
            thisCamera = GetComponent<Camera>();
        }
    }

    private void LateUpdate()
    {
        Rect3D rectCamera = new Rect3D(thisCamera.GetFrustumDotsIntersections(borders.rect.Plane()));

        if (rectCamera.bottomLeft.y < rectBorders.bottomLeft.y)
        {
            transform.OffsetPositionY(rectBorders.bottomLeft.y - rectCamera.bottomLeft.y);
        }
        if (rectCamera.bottomLeft.x < rectBorders.bottomLeft.x)
        {
            transform.OffsetPositionX(rectBorders.bottomLeft.x - rectCamera.bottomLeft.x);
        }
        if (rectCamera.topRight.y > rectBorders.topRight.y)
        {
            transform.OffsetPositionY(rectBorders.topRight.y - rectCamera.topRight.y);
        }
        if (rectCamera.topRight.x > rectBorders.topRight.x)
        {
            transform.OffsetPositionX(rectBorders.topRight.x - rectCamera.topRight.x);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (thisCamera != null && borders != null)
        {
            DrawSpriteBorders();
        }
    }

    private void DrawSpriteBorders()
    {
        Gizmos.color = Color.red;
        rectBorders.DrawGizmos();

        Rect3D rectCamera = new Rect3D(thisCamera.GetFrustumDotsIntersections(borders.rect.Plane()));

        Gizmos.color = Color.green;
        rectCamera.DrawGizmos();
    }

}
