using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableParentBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => transform.parent.gameObject.SetActive(false));
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}
