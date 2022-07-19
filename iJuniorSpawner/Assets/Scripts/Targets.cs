using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public List<Transform> _transforms = new List<Transform>();

    public int Count { get; private set; }
    
    private void Awake()
    {
        Count = transform.childCount;

        for (int i = 0; i < Count; i++)
        {
            _transforms.Add(transform.GetChild(i));
        }
    }

}
