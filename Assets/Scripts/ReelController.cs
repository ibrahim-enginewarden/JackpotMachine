using UnityEngine;

public class ReelController : MonoBehaviour
{
    // Speed of reel movement
    public float spinSpeed = 600.0f;

    // Position where reel resets back to top
    public float resetPosition = -550.0f;

    private RectTransform reelTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        // Get the RectTransform component
        reelTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Reel downward
        reelTransform.anchoredPosition += Vector2.down * spinSpeed * Time.deltaTime;

        // Reset reel position to create looping effect
        if(reelTransform.anchoredPosition.y < resetPosition)
        {
            reelTransform.anchoredPosition = Vector2.zero;
        }
    }
}
