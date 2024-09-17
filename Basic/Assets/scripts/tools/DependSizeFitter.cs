using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class DependSizeFitter : RectComponent
{

    public BaseSizeChanger dependTo;

    public Vector2 offset;

    private void Awake()
    {
        ChangeSize(dependTo);
        dependTo.OnSizeChange += ChangeSize;
    }

    private void ChangeSize(BaseSizeChanger d)
    {
        Vector2 v = d.Size + offset;
        Size = v;
    }

}
