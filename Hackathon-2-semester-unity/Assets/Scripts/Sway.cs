using UnityEngine;

public class Sway : MonoBehaviour
{
    public Sprite leftSprite;
    public Sprite middleSprite;
    public Sprite rightSprite;
    public Sprite leftSpriteChild;
    public Sprite middleSpriteChild;
    public Sprite rightSpriteChild;
    float swayCooldown = 1;
    float timeSinceSway;
    int currentSprite = 1;
    int correctSprite = 0;
    int timesMatched;
    GameObject nextArrow;
    GameObject child;
    // Enables the gyroscope
    private void OnEnable()
    {
        if (Input.gyro.enabled != true)
        {
            Input.gyro.enabled = true;
        }
    }
    // DIsables the gyroscype when no longer needed
    private void OnDisable()
    {
        Input.gyro.enabled = false;
    }
    // Sets some variables and deactivates the nextarrow
    private void Awake()
    {
        nextArrow = GameObject.Find("Næste Pil");
        nextArrow.SetActive(false);
        child = GameObject.Find("Child");
    }
    // Updates the time and checks for rotation of the phone which then changes sprites on the plant based on direction
    private void Update()
    {
        if (timeSinceSway > 0)
        {
            timeSinceSway -= Time.deltaTime;
        }
        else
        {
            if (!Input.gyro.enabled)
            {
                Input.gyro.enabled = true;
            }
            if (Input.gyro.rotationRate.z > 3)
            {
                switch (currentSprite)
                {
                    case 1:
                        GetComponent<SpriteRenderer>().sprite = leftSprite;
                        currentSprite = 0;
                        timeSinceSway = swayCooldown;
                        break;
                    case 2:
                        GetComponent<SpriteRenderer>().sprite = middleSprite;
                        currentSprite = 1;
                        timeSinceSway = swayCooldown;
                        break;
                    default:
                        break;
                }
                CheckSway();
            }
            else if (Input.gyro.rotationRate.z < -3)
            {
                switch (currentSprite)
                {
                    case 1:
                        GetComponent<SpriteRenderer>().sprite = rightSprite;
                        currentSprite = 2;
                        timeSinceSway = swayCooldown;
                        break;
                    case 0:
                        GetComponent<SpriteRenderer>().sprite = middleSprite;
                        currentSprite = 1;
                        timeSinceSway = swayCooldown;
                        break;
                    default:
                        break;
                }
                CheckSway();
            }
        }
    }
    // Changes the sprite of the child when the correct orientation is reached and also activates the next arrow when all objectives are done
    void CheckSway()
    {
        if (currentSprite == correctSprite)
        {
            timesMatched++;
            switch (timesMatched)
            {
                case 1:
                    correctSprite = 2;
                    child.GetComponent<SpriteRenderer>().sprite = rightSpriteChild;
                    break;
                case 2:
                    correctSprite = 0;
                    child.GetComponent<SpriteRenderer>().sprite = leftSpriteChild;
                    break;
                case 3:
                    correctSprite = 1;
                    child.GetComponent<SpriteRenderer>().sprite = middleSpriteChild;
                    break;
                case 4:
                    nextArrow.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
