using System;
using Tools;
public abstract class BaseSizeChanger : RectComponent
{
    public event Action<BaseSizeChanger> OnSizeChange;

    protected void SizeChange()
    {
        OnSizeChange?.Invoke(this);
    }
}
