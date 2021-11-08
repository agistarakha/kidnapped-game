using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.typeKey> typeList;

    private void Awake()
    {
        typeList = new List<Key.typeKey>();
    }

    public void AddKey(Key.typeKey typeKey)
    {
        Debug.Log("ADD KEY " + typeKey);
        typeList.Add(typeKey);
    }

    public void RemoveKey(Key.typeKey typeKey)
    {
        typeList.Remove(typeKey);
    }

    public bool ContainsKey(Key.typeKey typeKey)
    {
        return typeList.Contains(typeKey);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        DoorKey doorKey = collider.GetComponent<DoorKey>();
        if (ContainsKey(doorKey.GetTypeKey()))
        {
            //Jika player memiliki kunci untuk buka pintu
            doorKey.OpenDoor();
        }
    }
}
