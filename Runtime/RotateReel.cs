using System;
using UnityEngine;
using UnityEngine.Events;

public class RotateRell : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    private bool isRotating = false;

    public Transform m_whoToRotate;
    public Transform m_directionRaycast;
    public bool m_useDebugTool=true;
    public float m_debugDrawTime = 3;
    public LayerMask m_mask = ~1;

    public UnityEvent<bool> m_onAttempting;
    void LateUpdate()
    {

        bool isEditor = false;
#if UNITY_EDITOR
        isEditor = true;

#endif
        if (m_useDebugTool)
            Debug.DrawLine(m_directionRaycast.position, m_directionRaycast.position + m_directionRaycast.forward
                , Color.red, m_debugDrawTime);

        if (Input.GetMouseButton(0))
        {
            Debug.Log("click");



            bool hasHit = Physics.Raycast(m_directionRaycast.position, m_directionRaycast.forward, out RaycastHit hit, float.MaxValue, m_mask);
            if( hasHit)
            {
                isRotating = true;
                if (hit.transform == transform)
                {
                    isRotating = true;
                }
                
            }

            if (m_useDebugTool) {
                Debug.DrawLine(m_directionRaycast.position, hasHit ? hit.point : m_directionRaycast.position + m_directionRaycast.forward * 10f
                       , hasHit ? Color.green : Color.red, m_debugDrawTime);
                m_onAttempting.Invoke(hasHit);
            }
               
        }
        else
        {
            isRotating = false;
        }

        
        if (isRotating)
        {
            
            Vector3 mousePosition = Input.mousePosition;
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            float horizontalRotation = (mousePosition.x - screenCenter.x) * rotationSpeed * Time.deltaTime;


            m_whoToRotate.Rotate(0, horizontalRotation, 0,Space.Self);
        }
    }
}
