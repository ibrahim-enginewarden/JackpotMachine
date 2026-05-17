using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverController : MonoBehaviour
{
    // Coin System
    public TMP_Text coinText;
    public TMP_Text moneyChangeText;

    private int coins = 100;
    private int currentBet = 0;

    // Bet Buttons
    public GameObject bet10Button;
    public GameObject bet50Button;
    public GameObject bet100Button;

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

    // EndGame PopUp
    public GameObject jackpotPopup;
    public GameObject tryagainPopup;
    public GameObject moneyChangeBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheckBetButtons();
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

                // Check win condition
                if(random1 == random2 && random2 == random3)
                {
                    jackpotPopup.SetActive(true);
                    moneyChangeBox.SetActive(true);

                    coins += currentBet * 5;
                    coinText.text = coins.ToString();
                    moneyChangeText.text = "+" + (currentBet * 5).ToString();
                }
                else
                {
                    tryagainPopup.SetActive(true);
                    moneyChangeBox.SetActive(true);

                    coinText.text = coins.ToString();
                    moneyChangeText.text = "-" + currentBet.ToString();
                }

                if (coins <= 0)
                {
                    moneyChangeText.text = "NO COINS";

                    leverUp.SetActive(false);

                    bet10Button.SetActive(false);
                    bet50Button.SetActive(false);
                    bet100Button.SetActive(false);
                }

                // Reset lever Position
                leverDown.SetActive(false);
                leverUp.SetActive(true);

                // Show bet buttons
                CheckBetButtons();

                // Resetting Values
                currentBet = 0;
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
        if(currentBet == 0)
        {
            return;
        }
        if (coins < currentBet)
        {
            moneyChangeText.text = "NO COINS";
            moneyChangeBox.SetActive(true);

            return;
        }
        isSpinning = true;

        coins -= currentBet;
        coinText.text = coins.ToString();

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

        // Disabling EndGame PopUps
        jackpotPopup.SetActive(false);
        tryagainPopup.SetActive(false);

        // Hide money change box
        moneyChangeBox.SetActive(false);

        // Start spinning reels
        reel1.shouldSpin = true;
        reel2.shouldSpin = true;
        reel3.shouldSpin = true;

        // Disabling Bet Buttons
        bet10Button.SetActive(false);
        bet50Button.SetActive(false);
        bet100Button.SetActive(false);
    }

    // Functions for Enabling/Disabling Bet Buttons
    public void Bet10()
    {
        currentBet = 10;

        bet50Button.SetActive(false);
        bet100Button.SetActive(false);
    }
    public void Bet50()
    {
        currentBet = 50;

        bet10Button.SetActive(false);
        bet100Button.SetActive(false);
    }
    public void Bet100()
    {
        currentBet = 100;

        bet10Button.SetActive(false);
        bet50Button.SetActive(false);
    }
    void CheckBetButtons()
    {
        // Bet 10
        if (coins >= 10)
        {
            bet10Button.SetActive(true);
        }
        else
        {
            bet10Button.SetActive(false);
        }

        // Bet 50
        if (coins >= 50)
        {
            bet50Button.SetActive(true);
        }
        else
        {
            bet50Button.SetActive(false);
        }

        // Bet 100
        if (coins >= 100)
        {
            bet100Button.SetActive(true);
        }
        else
        {
            bet100Button.SetActive(false);
        }
    }
}
