using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeDelayInSecond;
    
    private event Action _action;
    private float _currentTime;

    public bool IsStop { private get; set; }

    public void Init(Action action)
    {
        _action = action;
        _currentTime = _timeDelayInSecond;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (IsStop == false)
        {
            
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
            }
            else
            {
                _currentTime = _timeDelayInSecond;
                _action.Invoke();
            }
        }
        
    }
}
