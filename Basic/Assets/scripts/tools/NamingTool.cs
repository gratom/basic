#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace Tools
{

    public class NamingTool : MonoBehaviour
    {
        private const string s = "c";

        [MenuItem("Assets/" + nameof(RenameFrom0toN))]
        public static void RenameFrom0toN()
        {
            Object[] selectedObjects = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
            List<Object> objs = selectedObjects.OrderBy(x => x.name).ToList();
            for (int i = 0; i < objs.Count(); i++)
            {
                if (objs[i] is Object asset)
                {
                    string path = AssetDatabase.GetAssetPath(asset);
                    string newName = i.ToString() + s;
                    AssetDatabase.RenameAsset(path, newName);
                }
            }
            AssetDatabase.Refresh();
        }
    }
}

#endif
