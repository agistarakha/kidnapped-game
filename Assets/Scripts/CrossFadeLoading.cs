using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossFadeLoading : MonoBehaviour
{
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isLoadGame)
        {
            Player.isLoadGame = false;
            img.CrossFadeAlpha(0, 1f, false);
        }
        else if (Player.isSaveGame)
        {
            Player.isSaveGame = false;
            img.CrossFadeAlpha(255f, 1f, false);
        }
    }
}
