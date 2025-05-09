using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Вверх вниз по UI элементам
/// Должен подгружаться первее чем UI элементы в которых он используется, чтобы подгрузка не случалась позже
/// </summary>
[RequireComponent(typeof(ScrollRect))]
public class AdaptiveScrollView : MonoBehaviour
{
    public RectTransform content;

    private void Awake() => UpdateContentSize();
    
    public void UpdateContentSize()
    {
        content.sizeDelta = Vector2.zero;

        foreach (RectTransform child in content)
        {
            content.sizeDelta = new Vector2(
                content.sizeDelta.x,
                content.sizeDelta.y + child.sizeDelta.y
            );
        }
        content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y / 1.25f);
    }
}