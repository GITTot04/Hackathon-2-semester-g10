using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class Smacking : MonoBehaviour
{

    public GameObject[] interactableObjects = new GameObject[10];
    public GameObject FlySwatter;
    public Sprite deadFly;
    TouchState touch;
    Vector2 touchStartPos;
    int deadFlies;
    public GameObject nextArrow;
    // Allows for smacking of each individual fly based on the touch position and activates the next arrow when all flyes have been swatted
    private void OnSmacking()
    { 
        touch = Touchscreen.current.primaryTouch.value;
        touchStartPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.startPosition.x, touch.startPosition.y));
        FlySwatter.transform.position = touchStartPos;
        foreach (GameObject interactableObject in interactableObjects)
        {
            if (interactableObject != null)
            {
                if (touchStartPos.x + 0.75 > interactableObject.transform.position.x && touchStartPos.x - 0.75 < interactableObject.transform.position.x && touchStartPos.y + 0.75 > interactableObject.transform.position.y && touchStartPos.y - 0.75 < interactableObject.transform.position.y)
                {
                    if (interactableObject.GetComponent<SpriteRenderer>().sprite != deadFly)
                    {
                        interactableObject.GetComponent<SpriteRenderer>().sprite = deadFly;
                        deadFlies++;
                        if (deadFlies == interactableObjects.Length)
                        {
                            nextArrow.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}