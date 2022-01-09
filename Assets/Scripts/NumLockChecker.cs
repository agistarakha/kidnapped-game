using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumLockChecker : MonoBehaviour
{

    private string input;
    private string code;
    public string Code
    {
        get
        {
            return code;
        }
        set
        {
            code = value;
        }
    }
    private Key.typeKey keyType;
    public Key.typeKey KeyType { get { return keyType; } set { keyType = value; } }
    // Start is called before the first frame update
    void OnEnable()
    {
        input = "";
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    public void CodeCheck()
    {
        for (int i = 0; i < transform.childCount; i++)
        {

            input += transform.GetChild(i).GetComponent<NumLock>().GetNumStr();
        }
        Debug.Log(input);
        Debug.Log(code);
        if (input == code)
        {
            AudioManager.instance.PlaySFX("BukaKunci");
            Player.obtainedKeys.Add(keyType);
            Debug.Log("OPPPPEEEEN");
            Button backBtn = transform.parent.parent.GetChild(1).gameObject.GetComponent<Button>();
            //backBtn.onClick.AddListener(() => DialogManager.Instance.ShowDialogUI("Terbukaa!"));
            backBtn.onClick.Invoke();
        }
        input = "";
    }
}
