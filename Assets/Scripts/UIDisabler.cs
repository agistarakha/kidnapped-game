using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class UIDisabler : MonoBehaviour
{
    public GameObject UIGameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableUI()
    {
        UIGameObject.SetActive(false);
        Player.gameState = Player.GameState.GAMEPLAY;
    }


}
