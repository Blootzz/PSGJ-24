using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashForwardAbility : AbilityIcon
{
    [SerializeField] float forceMagnitude;
    [SerializeField] float heightY;
    public override void ExecuteAbility()
    {
        Vector3 forceDirection = new Vector3(player.transform.forward.x, player.transform.forward.y + heightY, player.transform.forward.z);
        player.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
        base.ExecuteAbility();
    }
}
