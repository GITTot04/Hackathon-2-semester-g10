using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class Mediator : MonoBehaviour
{

    public GameObject[] interactableObjects = new GameObject[12];
    TouchState touch;
    Vector2 touchStartPos;
    public GameObject[] ChosenCards = new GameObject[2];
    private bool cardFlipped = false;
    public GameObject nextArrow;
    int pairsMade;
    // Allows for clicking on each individual card and calls the CheckPairs() method when 2 cards have been flipped
    private void OnClick()
    {
        if (!cardFlipped)
        {
            touch = Touchscreen.current.primaryTouch.value;
            touchStartPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.startPosition.x, touch.startPosition.y));
            foreach (GameObject interactableObject in interactableObjects)
            {
                if (interactableObject != null)
                {
                    if (touchStartPos.x + 1.25 > interactableObject.transform.position.x && touchStartPos.x - 1.25 < interactableObject.transform.position.x && touchStartPos.y + 2 > interactableObject.transform.position.y && touchStartPos.y - 0.5 < interactableObject.transform.position.y)
                    {
                        interactableObject.GetComponent<Image>().sprite = interactableObject.GetComponent<MatchingPairsGame>().Cardfront;
                        for (int i = 0; i < ChosenCards.Length; i++)
                        {
                            if (ChosenCards[i] == null && ChosenCards[0] != interactableObject)
                            {
                                ChosenCards[i] = interactableObject;
                                break;
                            }
                        }
                        if (ChosenCards[0] != null && ChosenCards[1] != null)
                        {
                            cardFlipped = true;
                            CheckPairs();
                        }
                    }
                }
            }


        }
    }
    // Starts the coroutine that checks pairs with a slight delay
    void CheckPairs()
    {

        StartCoroutine(WaitForFlip());
    }
    // Checks pairs with a slight delay and destroys them if the pair is correct
    // Turns the cards back around if the pair is incorrect
    // Activates the next arrow when all cards are removed
    IEnumerator WaitForFlip()
    {
        yield return new WaitForSeconds(1);
        if (ChosenCards[0].GetComponent<MatchingPairsGame>().ID == ChosenCards[1].GetComponent<MatchingPairsGame>().ID)
        {
            Destroy(ChosenCards[0]);
            Destroy(ChosenCards[1]);
            pairsMade++;
            if (pairsMade == 6)
            {
                nextArrow.SetActive(true);
            }
        }
        else
        {
            ChosenCards[0].GetComponent<Image>().sprite = ChosenCards[0].GetComponent<MatchingPairsGame>().Cardback;
            ChosenCards[1].GetComponent<Image>().sprite = ChosenCards[1].GetComponent<MatchingPairsGame>().Cardback;
        }
        cardFlipped = false;

        ChosenCards[0] = null;
        ChosenCards[1] = null;

    }
}
