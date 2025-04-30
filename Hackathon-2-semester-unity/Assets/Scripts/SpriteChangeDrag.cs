using UnityEngine;

public class SpriteChangeDrag : GenericDrag
{
    public Sprite newSprite;
    public override void FinalAction()
    {
        currentDraggableObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        objectiveDone = true;
    }
}
