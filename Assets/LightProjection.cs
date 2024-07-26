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
    [SerializeField]
    Color color;
    [SerializeField]
    string ability;

    // Start is called before the first frame update
    void Start()
    {
       onSetActive();
    }

    void onSetActive()
    {
         this.gameObject.GetComponent<MeshRenderer>().material.color = color;
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
            UpdateMirror(hit.collider);
            scaleDist = hit.distance/2;
            Debug.DrawLine(transform.parent.position, transform.parent.position + transform.parent.forward * hit.distance, Color.yellow, 10);
        }
        else
        {
            scaleDist = maxDistance/2;
            Debug.DrawLine(transform.parent.position,transform.parent.position +  transform.parent.forward * 1000, Color.white, 10);
            Debug.Log("Did not Hit");
        }
        ExtendObject(scaleDist);
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "LightProjection")
            return;
        UpdateMirror(collider); 
        float scaleDist = Vector3.Distance(transform.parent.position, collider.gameObject.transform.position)/2;
        ExtendObject(scaleDist);
    }
    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "LightProjection")
            return;
        UpdateMirror(collider);
        float scaleDist = Vector3.Distance(transform.parent.position, collider.gameObject.transform.position)/2;
        ExtendObject(scaleDist);
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "LightProjection")
            return;
        Project();
        if(collider.tag == "Mirror")
        {
            collider.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void ExtendObject(float scaleDist)
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, scaleDist+0.1f, this.transform.localScale.z);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, scaleDist);

    }
    void UpdateMirror(Collider collider)
    {
        if(collider.tag == "Mirror")
        {
            collider.transform.GetChild(0).gameObject.SetActive(true);
            collider.transform.GetChild(0).gameObject.GetComponent<LightProjection>().color = this.color;
            collider.transform.GetChild(0).gameObject.GetComponent<LightProjection>().ability = this.ability;
            collider.transform.GetChild(0).gameObject.GetComponent<LightProjection>().onSetActive();
        }
    }
    
}
