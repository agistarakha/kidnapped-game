using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Brankas : MonoBehaviour
{
    private int index;
    private int lastIndex;
    private Text textBrankas;
    private Text codeText;
    private bool lastDir;
    private bool curDir;
    private string code;
    private bool zeroIndexPass;
    private string password;
    // Start is called before the first frame update
    void Start()
    {
        password = "5371";
        GetComponentsInChildren<Button>()[0].onClick.AddListener(() => IncIndex());
        GetComponentsInChildren<Button>()[1].onClick.AddListener(() => DecIndex());
        GetComponentsInChildren<Button>()[2].onClick.AddListener(() => ConfirmCode());
        index = 0;
        lastIndex = index;
        code = "";
        zeroIndexPass = false;

        textBrankas = GetComponentsInChildren<Text>()[2];
        codeText = GetComponentsInChildren<Text>()[3];
        textBrankas.text = "" + index;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncIndex()
    {
        index++;
        if (index > 9)
        {
            index = 0;
        }
        textBrankas.text = "" + index;
        curDir = true;

        BrankasCheck();
        lastDir = curDir;
        lastIndex = index;
    }

    public void DecIndex()
    {
        index--;
        if (index < 0)
        {
            index = 9;
        }
        textBrankas.text = "" + index;
        curDir = false;
        BrankasCheck();
        lastDir = curDir;
        lastIndex = index;

    }

    private void ConfirmCode()
    {
        code += index;
        if (code == password)
        {
            Player.obtainedKeys.Add(Key.typeKey.WineA);
            Debug.Log("OPPPPEEEEN");
            transform.parent.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        }
        else
        {
            Debug.Log("SALAHHHH");
            code = "";
            codeText.text = "Code: ";
        }
    }

    private void BrankasCheck()
    {
        if (zeroIndexPass)
        {
            // if (code.Length + 1 == password.Length)
            // {
            //     StringBuilder sb = new StringBuilder(code);
            //     if (code.Length == password.Length)
            //     {
            //         sb[password.Length - 1] = (char)index;
            //     }
            //     else
            //     {
            //         code += index;
            //     }
            //     code = sb.ToString();
            //     Debug.Log(code);
            //     codeText.text = "Code: " + code;
            // }
            if (lastDir != curDir)
            {
                code += lastIndex;
                codeText.text = "Code: " + code;
                Debug.Log(code);
            }
        }
        zeroIndexPass = true;
    }

}
