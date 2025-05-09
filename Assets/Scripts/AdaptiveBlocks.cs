using UnityEngine;

/// <summary>
/// Должен подгружаться первее чем UI элементы в которых он используется, чтобы подгрузка не случалась позже
/// </summary>
public class AdaptiveBlock : MonoBehaviour
{
    public RectTransform content;

    //private void Awake() => UpdateContentSize();

    public void UpdateContentSize() {
        content.sizeDelta = Vector2.zero;
        float newY = -86.5f; // -100 для вычета текста как child
        foreach (RectTransform child in content)
            newY += 86.5f;
        content.sizeDelta = new Vector2(500f, newY);
    }
}