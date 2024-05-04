using System.Collections;
using System.Collections.Generic;
using Global.Components.Localization;
using UnityEngine;

public class test1 : MonoBehaviour
{

    [SerializeField] private StringLocalizer description;

    public void Test()
    {
        string s = description;
    }

}
