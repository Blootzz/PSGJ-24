using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombAbility : AbilityIcon
{
    [SerializeField] Sprite sprite2;
    bool bombDeployed = false;

    public override void ExecuteAbility()
    {
        if (!bombDeployed)
        {
            print("implemet deploy bomb here");
            bombDeployed = true;
        }
        else
        {
            print("implement Detonate bomb here");
            base.ExecuteAbility();
        }

    }
}
