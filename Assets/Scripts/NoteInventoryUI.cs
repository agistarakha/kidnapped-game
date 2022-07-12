using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class yang mengatur UI pada Inventory untuk Note(Catatan)
/// </summary>
public class NoteInventoryUI : MonoBehaviour
{
    public GameObject noteItem;
    public GameObject noteItemParent;
    public GameObject noteDetails;
    private List<string> generatedNote = new List<string>();
    [SerializeField]
    private Color originalColor;
    [SerializeField]
    private Color selectedColor;
    

    

    void OnEnable()
    {
        foreach (KeyValuePair<string, string> note in Player.obtainedNotes)
        {
            if (!generatedNote.Contains(note.Key))
            {
                GameObject obj = Instantiate(noteItem, Vector3.zero, Quaternion.identity, noteItemParent.transform);
                obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = note.Key;
                obj.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
                {
                    ResetColor();
                    ClickColor(obj);
                    ShowDetail(note.Key);
                });
                generatedNote.Add(note.Key);
            }

        }
        // GetComponentInChildren<Text>().text = title;
    }

    /// <summary>
    /// Mengubah warna object UI ketika di click
    /// </summary>
    /// <param name="obj">objek UI yang akan diubah warnanya</param>
    private void ClickColor(GameObject obj)
    {
        obj.GetComponent<Image>().color = selectedColor;
        obj.transform.GetChild(0).GetComponent<Text>().color = originalColor;
    }

    /// <summary>
    /// Mengubah warna menjadi warna default apabila terdapat object tidak memiliki warna default
    /// </summary>
    private void ResetColor()
    {
        for (int i = 0; i < noteItemParent.transform.childCount; i++)
        {
            GameObject obj = noteItemParent.transform.GetChild(i).gameObject;
            if (obj.GetComponent<Image>().color.r == selectedColor.r)
            {
                obj.GetComponent<Image>().color = originalColor;
                obj.transform.GetChild(0).GetComponent<Text>().color = selectedColor;

            }

        }
    }

    /// <summary>
    /// Menampilkan detail text dari sebuah note
    /// </summary>
    /// <param name="title"></param>
    private void ShowDetail(string title)
    {
        noteDetails.transform.GetChild(0).GetComponent<Text>().text = title;
        noteDetails.transform.GetChild(1).GetComponent<Text>().text = Player.obtainedNotes[title];
    }
}
