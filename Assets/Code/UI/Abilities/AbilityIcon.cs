using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] Sprite baseSprite;
    public GameObject player;
        
    public virtual void Start()
    {
        GetComponent<Image>().sprite = baseSprite;
    }

    public virtual void ExecuteAbility()
    {
        print("Base ability execution");
        Destroy(this);
    }
}