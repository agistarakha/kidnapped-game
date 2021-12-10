using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBackBtn : MonoBehaviour
{
    private Button backBtn;
    private GameObject firstParent;
    private GameObject secondParent;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        backBtn = GetComponent<Button>();
        firstParent = null;
        secondParent = null;
        backBtn.onClick.AddListener(() => DisableParent());
        backBtn.onClick.AddListener(() => PopUpUIManager.Instance.DeactivateUI());
    }

    void OnDisable()
    {
        backBtn.onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DisableParent()
    {
        int i = 0;
        firstParent = gameObject.transform.parent.gameObject;
        while (!firstParent.CompareTag("PopUpItem"))
        {
            i++;
            firstParent = firstParent.transform.parent.gameObject;
            if (i > 4)
            {
                Debug.Log(firstParent.name);
                break;
            }
        }
        secondParent = firstParent.transform.parent.gameObject;
        firstParent.SetActive(false);
        secondParent.SetActive(false);
    }
}
