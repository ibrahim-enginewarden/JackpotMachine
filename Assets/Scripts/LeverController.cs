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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        reel1.enabled = true;
        reel2.enabled = true;
        reel3.enabled = true;

    }
}
