using System.Linq.Expressions;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    // Speed of reel movement
    public float spinSpeed = 600.0f;

    // Position where reel resets back to top
    public float resetPosition = -550.0f;

    public bool shouldSpin = false;

    public float stopPosition = 120f;

    private RectTransform reelTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        reelTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only spin when allowed
        if (shouldSpin)
        {
            reelTransform.anchoredPosition += Vector2.down * spinSpeed * Time.deltaTime;

            // Reset strip position
            if (reelTransform.anchoredPosition.y < resetPosition)
            {
                reelTransform.anchoredPosition = Vector2.zero;
            }
        }
        else
        {
            reelTransform.anchoredPosition = new Vector2(reelTransform.anchoredPosition.x, stopPosition);
        }
    }
}
