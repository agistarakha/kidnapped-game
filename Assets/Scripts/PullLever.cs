using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PullLever : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 lastMousePosition;
    public RectTransform oriPosRect;
    public RectTransform targetPosRect;
    private Vector3 oriPos;
    private Vector3 targetPos;
    private RectTransform rect;
    private float leverDistance;
    public Sprite electricityOnSprite;
    private bool dragDisabled;
    private Vector3 targetPosOri;

    // private Image leverUI;
    // public Sprite[] leverSprites;
    // private int index;
    // Start is called before the first frame update
    void OnEnable()
    {
        rect = GetComponent<RectTransform>();

        if (Player.obtainedKeys.Contains(Key.typeKey.Lever))
        {
            dragDisabled = true;
            GameObject endPosObj = gameObject.transform.parent.GetChild(gameObject.transform.parent.childCount-1).gameObject;
            // targetPosOri = targetPosRect.position;
            // rect.position = targetPosRect.rect.position;
            endPosObj.GetComponent<Image>().color = Color.white;
            gameObject.GetComponent<Image>().enabled = false;
            transform.parent.GetChild(1).GetComponent<Image>().sprite = electricityOnSprite;
        }
        else
        {


            dragDisabled = false;
            leverDistance = 0;
            // index = 0;
            // leverUI = GetComponent<Image>();
        }
    }


    // void OnDisable()
    // {
    //     targetPosRect.position += new Vector3(0, -20f, 0);
    // }

    // Update is called once per frame
    void Update()
    {
        // if (Player.obtainedKeys.Contains(Key.typeKey.Lever))
        // {
        //     leverUI.sprite = leverSprites[4];
        // }
        // else
        // {
        //     if (Input.GetKeyDown(KeyCode.UpArrow))
        //     {
        //         index = Mathf.Clamp(index + 1, 0, 4);
        //         leverUI.sprite = leverSprites[index];
        //         if (index >= 4)
        //         {
        //             Player.obtainedKeys.Add(Key.typeKey.Lever);
        //         }

        //     }
        //     else if (Input.GetKeyDown(KeyCode.DownArrow))
        //     {
        //         index = Mathf.Clamp(index - 1, 0, 4);
        //         leverUI.sprite = leverSprites[index];


        //     }
        // }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dragDisabled) return;
        Debug.Log("Begin Drag");
        lastMousePosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragDisabled) return;

        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        // leverDistance += diff.y;


        Vector3 newPosition = rect.position + new Vector3(0, diff.y / 1.5f, transform.position.z);
        Vector3 oldPos = rect.position;
        rect.position = newPosition;
        //-166 -645
        Debug.Log("New Position" + newPosition);
        // Debug.Log("Ori Pos:" + oriPos);
        //if (RectOverlaps(rect, targetPosRect))
        if (RectOverlaps(rect, oriPosRect))//(newPosition.y > 216f)
        {
            rect.position = oldPos;

        }
        else if (RectOverlaps(rect, targetPosRect))//(newPosition.y < 112.5)
        {

            dragDisabled = true;
            rect.position = oldPos;
            transform.parent.GetChild(1).GetComponent<Image>().sprite = electricityOnSprite;
            Player.obtainedKeys.Add(Key.typeKey.Lever);
        }
        lastMousePosition = currentMousePosition;
    }

    /// <summary>
    /// This method will be called at the end of mouse drag
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragDisabled) return;

        Debug.Log("End Drag");
        //Implement your funtionlity here
    }


    bool RectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }
}
