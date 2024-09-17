using UnityEngine;
public class TextSizeChanger : BaseSizeChanger
{
    public TextEventable text;

    public float fontSizeMultiplier;
    public float minSize;

    private void Awake()
    {
        ChangeSize(text.text);
        text.OnTextChange += ChangeSize;
    }

    private void ChangeSize(string s)
    {
        Size = new Vector2(Mathf.Clamp(fontSizeMultiplier * s.Length * text.fontSize, minSize, fontSizeMultiplier * s.Length * text.fontSize), Size.y);
        SizeChange();
    }
}
