using UnityEngine;

namespace Tools
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteRendererBorders : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Camera mainCamera;

        public Rect3D rect;

        private void OnDrawGizmosSelected()
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
            }

            if (spriteRenderer != null && spriteRenderer.sprite != null)
            {
                if (mainCamera == null)
                {
                    mainCamera = Camera.main;
                }

                if (mainCamera != null)
                {
                    DrawSpriteBorders(spriteRenderer);
                }
            }
        }

        private void DrawSpriteBorders(SpriteRenderer spriteRenderer)
        {
            // Get the sprite's texture rectangle in pixels
            Rect spriteRect = spriteRenderer.sprite.rect;
            Vector2 size = new Vector2(spriteRect.width / spriteRenderer.sprite.pixelsPerUnit,
                spriteRect.height / spriteRenderer.sprite.pixelsPerUnit);

            // Calculate the local positions of the corners
            Vector3 bottomLeft = -size / 2;
            Vector3 bottomRight = new Vector3(size.x / 2, -size.y / 2, 0);
            Vector3 topRight = size / 2;
            Vector3 topLeft = new Vector3(-size.x / 2, size.y / 2, 0);

            Vector3 pivotWorld = transform.position;

            // Translate corners to world space
            rect = new Rect3D(
                pivotWorld + spriteRenderer.transform.TransformVector(bottomLeft),
                pivotWorld + spriteRenderer.transform.TransformVector(bottomRight),
                pivotWorld + spriteRenderer.transform.TransformVector(topRight),
                pivotWorld + spriteRenderer.transform.TransformVector(topLeft)
            );

            Gizmos.color = Color.red;
            rect.DrawGizmos();

            Plane spritePlane = rect.Plane();
            Rect3D rectCamera = new Rect3D(mainCamera.GetFrustumDotsIntersections(spritePlane));

            Gizmos.color = Color.green;
            rectCamera.DrawGizmos();
        }
    }
}
