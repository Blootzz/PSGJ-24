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

    bool scrollFrozen = false;

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
        if (Input.GetKeyDown(scrollForwardKey) && !scrollFrozen)
        {
            ScrollForward();
            return;
        }
        if (Input.GetKeyDown(scrollBackwardKey) && !scrollFrozen)
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
            selectedIndex = panelScroller.transform.childCount - 1;
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

        scrollFrozen = true;
        SetPlayerTranslation(false);
    }
    void ActivateAbility()
    {
        panelEquip.SetActive(true);
        panelActivate.SetActive(false);
        panelUnequip.SetActive(false);

        scrollFrozen = false;
        SetPlayerTranslation(true);

        // ability will destroy itself if applicable
        print("Do ability according to icon");

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

        scrollFrozen = false;
        SetPlayerTranslation(true);
    }

    void SetPlayerTranslation(bool canMove)
    {
        print("Set player translation to: "+canMove);
    }

}
