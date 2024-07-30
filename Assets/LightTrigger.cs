using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightTrigger : MonoBehaviour
{
    [SerializeField]
    UnityEvent triggerEvent;
    [SerializeField]
    bool requireSpecificColor;
    [SerializeField]
    Color triggerColor;
    
    public void DoEvent(Color c)
    {
        if(requireSpecificColor && c.r==triggerColor.r && c.b==triggerColor.b && c.g==triggerColor.g && c.a==triggerColor.a)
        {
            print("Event Done");
            triggerEvent.Invoke();
        }
        else if(!requireSpecificColor)
        {
            print("Event Done");
            triggerEvent.Invoke();
        }
            
    }

}
