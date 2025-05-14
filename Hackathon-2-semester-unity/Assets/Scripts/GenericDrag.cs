using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class GenericDrag : MonoBehaviour
{
    TouchState touch;
    Vector2 touchStartPos;
    Vector2 touchCurrentPos;
    public bool dragging;
    public GameObject[] interactableObjects = new GameObject[10];
    public GameObject currentDraggableObject;
    GameObject nextArrow;
    public bool objectiveDone;
    private void Awake()
    {
        nextArrow = GameObject.Find("Næste Pil");
        nextArrow.SetActive(false);
    }
    void OnTestDrag()
    {
        touch = Touchscreen.current.primaryTouch.value;
        if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            touchStartPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.startPosition.x, touch.startPosition.y));
            foreach (GameObject interactableObject in interactableObjects)
            {
                if (interactableObject != null)
                {
                    if (touchStartPos.x + 1 > interactableObject.transform.position.x && touchStartPos.x - 1 < interactableObject.transform.position.x && touchStartPos.y + 1 > interactableObject.transform.position.y && touchStartPos.y - 1 < interactableObject.transform.position.y)
                    {
                        dragging = true;
                        currentDraggableObject = interactableObject;
                    }
                }
            }
        }
        else if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved && dragging)
        {
            touchCurrentPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
            currentDraggableObject.transform.position = touchCurrentPos;
        }
        else if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended && dragging)
        {
            if (currentDraggableObject.GetComponent<DraggableObject>().reachedDestination == true)
            {
                FinalAction();
                CheckIfDone();
            }
            dragging = false;
        }
    }
    public virtual void FinalAction()
    {
        DestroyImmediate(currentDraggableObject);
    }
    void CheckIfDone()
    {
        for (int i = 0; i < interactableObjects.Length; i++)
        {
            if (interactableObjects[i] != null)
            {
                break;
            }
            else if (i == 9 && interactableObjects[i] == null)
            {
                objectiveDone = true;
            }
        }
        if (objectiveDone)
        {
            nextArrow.SetActive(true);
        }
    }
}
