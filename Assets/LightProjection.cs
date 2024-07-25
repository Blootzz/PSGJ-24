using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LightProjection : MonoBehaviour
{
    [SerializeField]
    float maxDistance = 30f;
    [SerializeField]
    LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        Project();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void Project()
    {
        RaycastHit hit;
        float scaleDist;
        if (Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, maxDistance, layerMask))
        {
            scaleDist = hit.distance/2;
            Debug.DrawLine(transform.parent.position, transform.parent.position + transform.parent.forward * hit.distance, Color.yellow, 10);
        }
        else
        {
            scaleDist = maxDistance/2;
            Debug.DrawLine(transform.parent.position,transform.parent.position +  transform.parent.forward * 1000, Color.white, 10);
            Debug.Log("Did not Hit");
        }
        
        this.transform.localScale = new Vector3(this.transform.localScale.x, scaleDist, this.transform.localScale.z);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, scaleDist);
    }
    void OnTriggerEnter(Collider collider)
    {
        float scaleDist = Vector3.Distance(transform.parent.position, collider.gameObject.transform.position)/2;
        this.transform.localScale = new Vector3(this.transform.localScale.x, scaleDist, this.transform.localScale.z);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, scaleDist);
    }
    void OnTriggerStay(Collider collider)
    {
        float scaleDist = Vector3.Distance(transform.parent.position, collider.gameObject.transform.position)/2;
        this.transform.localScale = new Vector3(this.transform.localScale.x, scaleDist, this.transform.localScale.z);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, scaleDist);
    }
    void OnTriggerExit(Collider collider)
    {
        Project();
    }
    
}
