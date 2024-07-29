using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerGrantAbility : MonoBehaviour
{
    public AbilityType ability;

    [SerializeField] GameObject DiagonalPrefab;
    [SerializeField] GameObject BombPrefab;
    [SerializeField] GameObject MirrorPrefab;
    [SerializeField] GameObject VaultPrefab;
    [SerializeField] GameObject DashForwardPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<CapsuleCharacterController>())
            return;

        AbilityControls abilityControls = FindObjectOfType<AbilityControls>();
        GameObject selectedPrefab;

        switch (ability)
        {
            case AbilityType.DiagonalBoost:
                selectedPrefab = Instantiate(DiagonalPrefab);
                break;
            case AbilityType.Bomb:
                other.gameObject.AddComponent<BombAbility>();
                selectedPrefab = Instantiate(BombPrefab);
                break;
            case AbilityType.Mirror:
                other.gameObject.AddComponent<MirrorAbility>();
                selectedPrefab = Instantiate(MirrorPrefab);
                break;
            case AbilityType.Vault:
                other.gameObject.AddComponent<VaultAbility>();
                selectedPrefab = Instantiate(VaultPrefab);
                break;
            case AbilityType.DashForward:
                other.gameObject.AddComponent<DashForwardAbility>();
                selectedPrefab = Instantiate(DashForwardPrefab);
                break;
            default:
                Debug.LogWarning("No ability enum set, defaulting to DiagonalPrefab");
                selectedPrefab = Instantiate(DiagonalPrefab);
                break;
        }

        abilityControls.AddAbility(selectedPrefab);
    }
}

public enum AbilityType
{
    DiagonalBoost,
    Bomb,
    Mirror,
    Vault,
    DashForward
}