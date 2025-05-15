using UnityEngine;

public class SpriteChangeDrag : GenericDrag
{
    public Sprite newSprite;
    public GameObject oldPotSprite;
    public Sprite newPotSprite;
    // Changes the function of FinalAction() to replace the current sprite instead of deleting the object
    public override void FinalAction()
    {
        currentDraggableObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        oldPotSprite.GetComponent<SpriteRenderer>().sprite = newPotSprite;
        objectiveDone = true;
    }
}
