using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : MonoBehaviour
{
    public bool isPortal1;
    public GameObject otherPortal;

    [SerializeField] GameObject lightSourcePrefab;

    private void OnTriggerEnter(Collider other)
    {
        print("Check if incoming object is light");

        if (isPortal1)
        {
            SendLightToPortal2(/*light data*/);
        }
        else
        {
            EmitLight();
        }
    }

    void SendLightToPortal2(/*light data*/)
    {
        print("Take in light data and send to portal 2");

    }

    public void ReceiveLightFromPortal1(/*light data*/)
    {
        print("receive light from portal 1");
    }

    void EmitLight()
    {
        print("instantiate light with portal 2 as transform");
        Instantiate(lightSourcePrefab, transform);
    }

    /// <summary>
    /// called by portal ability only on portal #2
    /// this method calls the same for portal #1
    /// </summary>
    public void EstablishPortalConnection(GameObject other, bool setOtherPortalRefToo)
    {
        otherPortal = other;
        if (setOtherPortalRefToo)
            other.GetComponent<PortalObject>().EstablishPortalConnection(this.gameObject, false);
    }

}
