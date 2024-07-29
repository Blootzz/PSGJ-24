using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombAbility : AbilityIcon
{
    [SerializeField] Sprite sprite2;
    bool bombDeployed = false;

    [SerializeField] GameObject bombPrefab;
    GameObject bombReference;

    public override void ExecuteAbility()
    {
        if (!bombDeployed)
        {
            print("implemet deploy bomb here");
            bombReference = Instantiate(bombPrefab, player.transform.position, Quaternion.identity);
            bombDeployed = true;
        }
        else
        {
            print("implement Detonate bomb here");
            Destroy(bombReference);
            base.ExecuteAbility();
        }

    }
}
