using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digits;
    [SerializeField]
    private Image[] number;

    private string sequence;
    void Start()
    {
        sequence = "";
        for (int i=0;i<=number.Length - 1; i++)
        {
            number[i].sprite = digits[2];
        }

        button.ButtonPressed += AddDigitToSequence;
    }

    private void AddDigitToSequence(string digitEnter)
    {
        if (sequence.Length < 4)
        {
            switch (digitEnter)
            {
                case "Zero":
                    sequence += 0;
                    DisplaySequence(0);
                    break;
                case "One":
                    sequence += 1;
                    DisplaySequence(1);
                    break;
            }
        }
        switch (digitEnter)
        {
            case "Enter":
                if (sequence.Length > 0)
                {
                    CheckResults();
                }
                break;

            case "Blank":
                ResetDisplay();
                break;
        }
    }

    private void DisplaySequence(int digitJustEnter)
    {
        switch (sequence.Length)
        {
            case 1:
                number[0].sprite = digits[2];
                number[1].sprite = digits[2];
                number[2].sprite = digits[digitJustEnter];
                break;
            case 2:
                number[0].sprite = digits[2];
                number[1].sprite = number[2].sprite;
                number[2].sprite = digits[digitJustEnter];
                break;
            case 3:
                number[0].sprite = number[1].sprite;
                number[1].sprite = number[2].sprite;
                number[2].sprite = digits[digitJustEnter];
                break;
        }
    }

    private void CheckResults()
    {
        if(sequence == "101")
        {
            Debug.Log("Correct!");
            ResetDisplay();
        }
        else
        {
            Debug.Log("Wrong!");
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {
        for (int i= 0; i<=number.Length - 1; i++)
        {
            number[i].sprite = digits[2];
        }
        sequence = "";
    }

    private void OnDestroy()
    {
        button.ButtonPressed -= AddDigitToSequence;
    }
}
