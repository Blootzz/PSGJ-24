using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityControls : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] KeyCode scrollForwardKey;
    [SerializeField] KeyCode scrollBackwardKey;
    [SerializeField] KeyCode activateKey;
    [SerializeField] KeyCode unequipKey;

    [Header("UI Panel References")]
    [SerializeField] GameObject panelEquip;
    [SerializeField] GameObject panelUnequip;
    [SerializeField] GameObject panelActivate;

    [Header("Ability Selection")]
    [SerializeField] GameObject panelScroller;
    [SerializeField] GameObject selectIndicator; // DO NOT MAKE CHILD OF Panel Scroller. Using childCount to keep track of abilities
    [SerializeField] int selectedIndex;

    void Start()
    {
        if (panelScroller.transform.childCount > 0)
        {
            // set indicator to first position
            selectIndicator.SetActive(true);
            selectIndicator.transform.position = panelScroller.transform.GetChild(0).transform.position;
        }
        else
            selectIndicator.SetActive(false);
    }

    // return after each action to prevent actions on same frame (even though it should be fine)
    void Update()
    {
        if (Input.GetKeyDown(scrollForwardKey))
        {
            ScrollForward();
            return;
        }
        if (Input.GetKeyDown(scrollBackwardKey))
        {
            ScrollBackward();
            return;
        }

        if (Input.GetKeyDown(activateKey) && panelEquip.activeInHierarchy)
        {
            EquipAbility();
            return;
        }
        if (Input.GetKeyDown(activateKey) && panelActivate.activeInHierarchy)
        {
            ActivateAbility();
            return;
        }
        if (Input.GetKeyDown(unequipKey) && panelUnequip.activeInHierarchy)
        {
            UnequipAbility();
            return;
        }

    }

    void ScrollForward()
    {
        selectedIndex += 1;
        CheckIndexOOB();
        UpdateSelectIndicator();
    }
    void ScrollBackward()
    {
        selectedIndex -= 1;
        CheckIndexOOB();
        UpdateSelectIndicator();
    }
    void CheckIndexOOB()
    {
        if (selectedIndex > panelScroller.transform.childCount - 1)
            selectedIndex = 0;
        if (selectedIndex < 0)
            selectedIndex = 0;
    }

    void UpdateSelectIndicator()
    {
        Vector2 targetPos = panelScroller.transform.GetChild(selectedIndex).transform.position;
        selectIndicator.transform.position = targetPos;
    }

    void EquipAbility()
    {
        panelEquip.SetActive(false);
        panelActivate.SetActive(true);
        panelUnequip.SetActive(true);

        SetPlayerTranslation(false);
    }
    void ActivateAbility()
    {
        panelEquip.SetActive(true);
        panelActivate.SetActive(false);
        panelUnequip.SetActive(false);

        SetPlayerTranslation(true);

        print("Do ability according to icon");

        // remove activated ability
        Destroy(panelScroller.transform.GetChild(selectedIndex).gameObject);
        // update selection (keep selectedIndex the same)
        CheckIndexOOB();
        if (panelScroller.transform.childCount <= 0)
            selectIndicator.SetActive(false);
        else
            UpdateSelectIndicator();
    }
    void UnequipAbility()
    {
        panelEquip.SetActive(true);
        panelActivate.SetActive(false);
        panelUnequip.SetActive(false);

        SetPlayerTranslation(true);
    }

    void SetPlayerTranslation(bool canMove)
    {
        print("Set player translation to: "+canMove);
    }

}