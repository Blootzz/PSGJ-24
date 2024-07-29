using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] Sprite baseSprite;
    public GameObject player;

    //[InspectorButton(nameof(OnButtonClicked))]
    //public bool killMe;
    //public void OnButtonClicked()
    //{
    //    transform.parent.GetComponent<AbilityInator>().DestroyThisIcon(this.gameObject);
    //}

    public virtual void Start()
    {
        GetComponent<Image>().sprite = baseSprite;
        player = FindObjectOfType<CapsuleCharacterController>().gameObject;
    }

    public virtual void PrepareAbility()
    {
        print("implement preparation visual here");
    }

    public virtual void ExecuteAbility()
    {
        print("Base ability execution");
        transform.parent.GetComponent<AbilityInator>().DestroyThisIcon(this.gameObject);
     }
}