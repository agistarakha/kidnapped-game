using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNum : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digits;
    [SerializeField]
    private Image[] number;
    public Key.typeKey typeKey;

    private string sequence;
    public string password;
    void Start()
    {
        sequence = "";
        for (int i=0;i<=number.Length - 1; i++)
        {
            number[i].sprite = digits[10];
        }

        BtnClicked.ButtonPressed += AddDigitToSequence;
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
                case "Two":
                    sequence += 2;
                    DisplaySequence(2);
                    break;
                case "Three":
                    sequence += 3;
                    DisplaySequence(3);
                    break;
                case "Four":
                    sequence += 4;
                    DisplaySequence(4);
                    break;
                case "Five":
                    sequence += 5;
                    DisplaySequence(5);
                    break;
                case "Six":
                    sequence += 6;
                    DisplaySequence(6);
                    break;
                case "Seven":
                    sequence += 7;
                    DisplaySequence(7);
                    break;
                case "Eight":
                    sequence += 8;
                    DisplaySequence(8);
                    break;
                case "Nine":
                    sequence += 9;
                    DisplaySequence(9);
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
                number[0].sprite = digits[10];
                number[1].sprite = digits[10];
                number[2].sprite = digits[10];
                number[3].sprite = digits[digitJustEnter];
                break;
            case 2:
                number[0].sprite = digits[10];
                number[1].sprite = digits[10];
                number[2].sprite = number[3].sprite;
                number[3].sprite = digits[digitJustEnter];
                break;
            case 3:
                number[0].sprite = digits[10];
                number[1].sprite = number[2].sprite;
                number[2].sprite = number[3].sprite;
                number[3].sprite = digits[digitJustEnter];
                break;
            case 4:
                number[0].sprite = number[1].sprite;
                number[1].sprite = number[2].sprite;
                number[2].sprite = number[3].sprite;
                number[3].sprite = digits[digitJustEnter];
                break;
        }
    }

    private void CheckResults()
    {
        if(sequence == password)
        {
            Debug.Log("Correct!");
            Player.obtainedKeys.Add(typeKey);
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
            number[i].sprite = digits[10];
        }
        sequence = "";
    }

    private void OnDestroy()
    {
        BtnClicked.ButtonPressed -= AddDigitToSequence;
    }
}
