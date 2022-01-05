using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumLock : MonoBehaviour
{
    private int index;
    private string password;
    private Text numText;
    private string numStr;
    public string GetNumStr()
    {
        return numStr;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        numText = GetComponentsInChildren<Text>()[1];
        password = "5371";
        GetComponentsInChildren<Button>()[0].onClick.AddListener(() => IncIndex());
        GetComponentsInChildren<Button>()[1].onClick.AddListener(() => DecIndex());
        index = 0;
        numStr = "" + index;
        numText.text = numStr;

    }

    void OnDisable()
    {
        GetComponentsInChildren<Button>()[0].onClick.RemoveAllListeners();
        GetComponentsInChildren<Button>()[1].onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    public void IncIndex()
    {
        index++;
        if (index > 9)
        {
            index = 0;
        }
        numStr = "" + index;
        numText.text = numStr;
        transform.parent.GetComponent<NumLockChecker>().CodeCheck();
    }

    public void DecIndex()
    {
        index--;
        if (index < 0)
        {
            index = 9;
        }
        numStr = "" + index;
        numText.text = numStr;
        transform.parent.GetComponent<NumLockChecker>().CodeCheck();

    }


}
