using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raflar : MonoBehaviour
{
    public List<GameObject> siseObj;
    public static raflar instance = null;
    GameObject childd;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        
        foreach (Transform child in gameObject.transform)
        {
              childd = child.gameObject;
              siseObj.Add(childd);           
        }

    }
}
