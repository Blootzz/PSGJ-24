using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] Image baseImage;
    public GameObject player;

    public virtual void ExecuteAbility()
    {
        print("Base ability execution");
        Destroy(this);
    }
}

// ====================== Implementations ======================

public class DiagonalAbility : AbilityIcon
{
    public override void ExecuteAbility()
    {
        print("Yeet player diagonally here");
        base.ExecuteAbility();
    }
}

public class DashForwardAbility : AbilityIcon
{
    public override void ExecuteAbility()
    {
        print("implement dash forward here");
        base.ExecuteAbility();
    }
}

public class VaultAbility : AbilityIcon
{
    public override void ExecuteAbility()
    {
        print("implemet vault ability here");
        base.ExecuteAbility();
    }
}

public class BombAbility : AbilityIcon
{
    [SerializeField] Image image2;
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

public class MirrorAbility : AbilityIcon
{
    [SerializeField] Image image2;
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
