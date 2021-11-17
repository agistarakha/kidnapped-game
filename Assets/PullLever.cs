using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullLever : MonoBehaviour
{
    private Image leverUI;
    public Sprite[] leverSprites;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        leverUI = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.obtainedKeys.Contains(Key.typeKey.Lever))
        {
            leverUI.sprite = leverSprites[4];
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                index = Mathf.Clamp(index + 1, 0, 4);
                leverUI.sprite = leverSprites[index];
                if (index >= 4)
                {
                    Player.obtainedKeys.Add(Key.typeKey.Lever);
                }

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                index = Mathf.Clamp(index - 1, 0, 4);
                leverUI.sprite = leverSprites[index];


            }
        }
    }
}
