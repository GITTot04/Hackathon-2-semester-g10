using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class Mediator : MonoBehaviour
{

    public GameObject[] intertactableObject = new GameObject[12];
    TouchState touch;
    Vector2 touchStartPos;
    public GameObject[] ChosenCards = new GameObject[2];
    private bool cardFillped = false;
    public GameObject nextArrow;
    int pairsMade;
    private void OnClick()
    {
        if (!cardFillped)
        {
            touch = Touchscreen.current.primaryTouch.value;
            touchStartPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.startPosition.x, touch.startPosition.y));
            foreach (GameObject intertactableObject in intertactableObject)
            {
                if (intertactableObject != null)
                {
                    if (touchStartPos.x + 1.25 > intertactableObject.transform.position.x && touchStartPos.x - 1.25 < intertactableObject.transform.position.x && touchStartPos.y + 2 > intertactableObject.transform.position.y && touchStartPos.y - 0.5 < intertactableObject.transform.position.y)
                    {
                        intertactableObject.GetComponent<Image>().sprite = intertactableObject.GetComponent<MatchingPairsGame>().Cardfront;
                        for (int i = 0; i < ChosenCards.Length; i++)
                        {
                            if (ChosenCards[i] == null && ChosenCards[0] != intertactableObject)
                            {
                                ChosenCards[i] = intertactableObject;
                                break;
                            }
                        }
                        if (ChosenCards[0] != null && ChosenCards[1] != null)
                        {
                            cardFillped = true;
                            CheckPairs();
                        }
                    }
                }
            }


        }
    }

    void CheckPairs()
    {

        StartCoroutine(WaitForFilp());
    }

    IEnumerator WaitForFilp()
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
        cardFillped = false;

        ChosenCards[0] = null;
        ChosenCards[1] = null;

    }
}
