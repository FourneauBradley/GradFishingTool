using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishCountMono : MonoBehaviour
{
    public int m_fishCount;
    public UnityEvent<int> m_fishCountEvent;
    public string m_debugFormat = "Fish: {0}";
    public UnityEvent<string> m_fishCountDebugStringEvent;



    public void Add()
    {

        m_fishCount++;
        ChangeDetected();
    }
    public void ResetFishCount()
    {

        m_fishCount=0;
        ChangeDetected();
    }

    private void ChangeDetected()
    {
        m_fishCountEvent.Invoke(m_fishCount);
        m_fishCountDebugStringEvent.Invoke(string.Format(m_debugFormat, m_fishCount)) ;
    }
}
