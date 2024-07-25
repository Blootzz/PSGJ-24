using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityIcon : MonoBehaviour
{
    public Ability assignedAbility;

    void ExecuteAbility()
    {
        switch (assignedAbility)
        {
            case Ability.DiagonalBoost:
                gameObject.AddComponent<DiagonalAbility>();
                break;
            case Ability.Bomb:
                break;
        }
    }
}
public enum Ability
{
    DiagonalBoost,
    Bomb,
    Portal,
    Vault,
    Dash
}

public class DiagonalAbility : MonoBehaviour
{

}
