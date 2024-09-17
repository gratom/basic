using UnityEngine;

namespace Tools
{
    public static class GameObjectExtensions
    {
#pragma warning disable

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T returned = gameObject.GetComponent<T>();
            if (returned == null)
            {
                returned = gameObject.AddComponent<T>();
            }
            return returned;
        }

#pragma warning restore
    }

}
