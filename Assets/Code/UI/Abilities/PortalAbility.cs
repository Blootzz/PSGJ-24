using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalAbility : AbilityIcon
{
    [SerializeField] Sprite sprite2;
    bool mirror1Deployed = false;

    public override void ExecuteAbility()
    {
        if (!mirror1Deployed)
        {
            print("implement deploy mirror 1 here");
            mirror1Deployed = true;
        }
        else
        {
            print("implement deploy mirror 2 here");
            base.ExecuteAbility();
        }
    }
}
