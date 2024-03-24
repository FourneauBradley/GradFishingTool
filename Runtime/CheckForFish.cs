using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CheckForFish : MonoBehaviour
{
    public float time=5f;
    public float percentage=30f;
    private bool hasCap=false;
    public UnityEvent m_onFishBite;
    private int nb=0;
    public LayerMask m_checkOnlyOn = ~1;
   
    void Start()
    {
        InvokeRepeating("CheckFish", 0f, time);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (BelongsToLayerMask (other.gameObject, m_checkOnlyOn)&&  other.gameObject.GetComponentInChildren<FishingCapTagMono>())
        {
            hasCap = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (BelongsToLayerMask(other.gameObject, m_checkOnlyOn) && other.gameObject.GetComponentInChildren<FishingCapTagMono>())
        {
            hasCap = false;
        }
    }

    public bool BelongsToLayerMask(GameObject obj, LayerMask layerMask)
    {
        // Get the object's layer
        int objLayer = obj.layer;

        // Check if the object's layer is included in the layer mask
        return ((1 << objLayer) & layerMask.value) != 0;
    }
    public bool m_useDebug;
    public void CheckFish()
    {
        if (hasCap)
        {
            float random = Random.Range(0f, 100f);
            if (random <= percentage)
            {
                if(m_useDebug)
                    Debug.Log("fish bite");
                nb++; 
                m_onFishBite.Invoke();


            }
            else
            {

                if (m_useDebug)
                    Debug.Log("fish dont bite :" + random + " p:" + percentage);
            }
        }
       
        
    }
}
