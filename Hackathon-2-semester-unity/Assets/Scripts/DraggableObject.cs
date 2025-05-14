using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public bool reachedDestination;
    // Checks if the object has reached its destination by checking the triggers tag
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destination")
        {
            reachedDestination = true;
        }
    }
    // Checks if the object has left its destination by checking the triggers tag
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Destination")
        {
            reachedDestination = false;
        }
    }
}
