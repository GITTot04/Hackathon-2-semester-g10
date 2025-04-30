using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public GameObject dragController;
    public bool reachedDestination;
    private void Start()
    {
        dragController = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destination")
        {
            reachedDestination = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Destination")
        {
            reachedDestination = false;
        }
    }
}
