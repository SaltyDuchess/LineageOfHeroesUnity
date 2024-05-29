using UnityEngine;

public interface IBaseGameObject
{
    string displayName { get; set; }
    Sprite uiElement { get; set; }
    string descriptionLong { get; set; }
}
