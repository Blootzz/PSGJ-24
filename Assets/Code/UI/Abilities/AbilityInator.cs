using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInator : MonoBehaviour
{
    [Tooltip("Delay until ability gets destroyed. Zero causes error for some reason")]
    [SerializeField] float destroySeconds;

    GameObject markedForDestruction;
    [SerializeField] AbilityControls canvasHUD;

    public void DestroyThisIcon(GameObject destroyMe)
    {
        markedForDestruction = destroyMe;
        StartCoroutine(nameof(BeginAbilityDestruction));
    }

    IEnumerator BeginAbilityDestruction()
    {
        yield return new WaitForSeconds(destroySeconds);
        print("Destroying");
        Destroy(markedForDestruction);
        yield return new WaitForEndOfFrame();
        canvasHUD.FinishAbility();
    }

}
