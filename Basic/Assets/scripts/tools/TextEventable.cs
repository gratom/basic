using System;
using UnityEngine;
using UnityEngine.UI;
public class TextEventable : Text
{
    public event Action<string> OnTextChange;

    public override string text
    {
        get => m_Text;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(m_Text))
                {
                    return;
                }
                m_Text = "";
                SetVerticesDirty();
            }
            else if (m_Text != value)
            {
                m_Text = value;
                OnTextChange?.Invoke(m_Text);
                SetVerticesDirty();
                SetLayoutDirty();
            }
        }
    }

#if UNITY_EDITOR

    private bool isUpdateTest = false;

    [ContextMenu("Start test")]
    private void ToggleUpdateTest()
    {
        isUpdateTest = !isUpdateTest;
    }

    private void Update()
    {
        if (isUpdateTest)
        {
            OnTextChange?.Invoke(text);
        }
    }
#endif
}
