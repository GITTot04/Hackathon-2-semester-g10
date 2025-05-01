using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class Smacking : MonoBehaviour

{

    public GameObject[] intertactableObject = new GameObject[10];
    public GameObject FlySwatter;
    public Sprite deadFlie;
    TouchState touch;
    Vector2 touchStartPos;
    int deadFlies;
    public GameObject nextArrow;
    private void OnSmacking()
    { 
        touch = Touchscreen.current.primaryTouch.value;
        touchStartPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.startPosition.x, touch.startPosition.y));
        FlySwatter.transform.position = touchStartPos;
        foreach (GameObject intertactableObject in intertactableObject)
        {
            if (intertactableObject != null)
            {
                if (touchStartPos.x + 0.75 > intertactableObject.transform.position.x && touchStartPos.x - 0.75 < intertactableObject.transform.position.x && touchStartPos.y + 0.75 > intertactableObject.transform.position.y && touchStartPos.y - 0.75 < intertactableObject.transform.position.y)
                {
                    if (intertactableObject.GetComponent<SpriteRenderer>().sprite != deadFlie)
                    {
                        intertactableObject.GetComponent<SpriteRenderer>().sprite = deadFlie;
                        deadFlies++;
                        if (deadFlies == 10)
                        {
                            nextArrow.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}