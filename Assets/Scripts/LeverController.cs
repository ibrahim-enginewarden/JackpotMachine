using UnityEngine;
using UnityEngine.UI;

public class LeverController : MonoBehaviour
{
    // Reel Scripts
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    // Final Result Symbols
    public Sprite[] symbols;
    public Image result1;
    public Image result2;
    public Image result3;

    // Spinning Reel Content
    public GameObject content1;
    public GameObject content2;
    public GameObject content3;

    // Lever Image 
    public GameObject leverUp;
    public GameObject leverDown;

    // Stops repeated clicking
    private bool isSpinning = false;

    // Time to reel stoppage
    private float spinTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Counting Spinning Time
        if (isSpinning)
        {
            spinTime += Time.deltaTime;

            // Stop reels after 3 seconds
            if (spinTime >= 3f)
            {
                // Stop spinning
                reel1.shouldSpin = false;
                reel2.shouldSpin = false;
                reel3.shouldSpin = false;

                // Hide spinning reels
                content1.SetActive(false);
                content2.SetActive(false);
                content3.SetActive(false);
                
                // Random Results
                int random1 = Random.Range(0, symbols.Length);
                int random2 = Random.Range(0, symbols.Length);
                int random3 = Random.Range(0, symbols.Length);

                // Finals Symbols
                result1.sprite = symbols[random1];
                result2.sprite = symbols[random2];
                result3.sprite = symbols[random3];

                result1.gameObject.SetActive(true);
                result2.gameObject.SetActive(true);
                result3.gameObject.SetActive(true);

                // Reset lever Position
                leverDown.SetActive(false);
                leverUp.SetActive(true);

                isSpinning = false;
                spinTime = 0f;
            }
        }
    }

    public void PullLever()
    {
        // Ignore clicks if alrady spinning
        if (isSpinning)
        {
            return;
        }
        isSpinning = true;

        //  Change lever image to down
        leverUp.SetActive(false);
        leverDown.SetActive(true);

        // Show spinning reels
        content1.SetActive(true);
        content2.SetActive(true);
        content3.SetActive(true);

        // Hide previous results
        result1.gameObject.SetActive(false);
        result2.gameObject.SetActive(false);
        result3.gameObject.SetActive(false);

        // Start spinning reels
        reel1.shouldSpin = true;
        reel2.shouldSpin = true;
        reel3.shouldSpin = true;
    }
}
