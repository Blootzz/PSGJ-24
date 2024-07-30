using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalAbility : AbilityIcon
{
    [SerializeField] Sprite sprite2;
    bool portal1Deployed = false;

    [SerializeField] GameObject portalPrefab;
    GameObject portal1Reference;
    GameObject portal2Reference;

    public override void ExecuteAbility()
    {
        if (!portal1Deployed)
        {
            portal1Reference = Instantiate(portalPrefab, player.transform.position, Quaternion.identity);
            portal1Reference.GetComponent<PortalObject>().isPortal1 = true;

            portal1Deployed = true;
        }
        else
        {
            portal2Reference = Instantiate(portalPrefab, player.transform.position, Quaternion.identity);
            portal2Reference.GetComponent<PortalObject>().isPortal1 = false;
            portal2Reference.GetComponent<PortalObject>().EstablishPortalConnection(portal1Reference, true);

            base.ExecuteAbility();
        }
    }
}
