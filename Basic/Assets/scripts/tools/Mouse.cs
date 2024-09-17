using UnityEngine;

namespace Tools
{
    public static class Mouse
    {
        public static bool TryGetObjectUnderCursorFirst<T>(out T obj, int layer = -1)
        {
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isHitSomething = layer >= 0 ? Physics.Raycast(ray, out hit, layer) : Physics.Raycast(ray, out hit);
                if (isHitSomething)
                {
                    T hitObject = hit.collider.GetComponent<T>();
                    if (hitObject != null)
                    {
                        obj = hitObject;
                        return true;
                    }
#if UNITY_EDITOR
                    Debug.Log($"can not find object with type {typeof(T).Name}under mouse");
#endif
                    obj = default;
                    return false;
                }
#if UNITY_EDITOR
                Debug.Log("no colliders under mouse");
#endif
                obj = default;
                return false;
            }
#if UNITY_EDITOR
            Debug.LogError("no default main camera!");
#endif
            obj = default;
            return false;
        }

        public static bool TryGetObjectUnderCursor<T>(out T obj, int layer = -1)
        {
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits = layer >= 0 ? Physics.RaycastAll(ray, layer) : Physics.RaycastAll(ray);
                if (hits.Length > 0)
                {
                    foreach (RaycastHit hit in hits)
                    {
                        T hitObject = hit.collider.GetComponent<T>();
                        if (hitObject != null)
                        {
                            obj = hitObject;
                            return true;
                        }
                    }
#if UNITY_EDITOR
                    Debug.Log($"can not find object with type {typeof(T).Name}under mouse");
#endif
                    obj = default;
                    return false;
                }
#if UNITY_EDITOR
                Debug.Log("no colliders under mouse");
#endif
                obj = default;
                return false;
            }
#if UNITY_EDITOR
            Debug.LogError("no default main camera!");
#endif
            obj = default;
            return false;
        }
    }
}
