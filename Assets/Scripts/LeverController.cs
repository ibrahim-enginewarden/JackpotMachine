using UnityEngine;
using UnityEngine.UI;

public class LeverController : MonoBehaviour
{
    // Reel Scripts
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

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
                reel1.shouldSpin = false;
                reel2.shouldSpin = false;
                reel3.shouldSpin = false;

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

        // Start spinning reels
        reel1.shouldSpin = true;
        reel2.shouldSpin = true;
        reel3.shouldSpin = true;
    }
}
