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
    [SerializeField] int MAX_ABILITIES;

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
            if (panelScroller.transform.childCount > 0)
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

    /// <summary>
    /// Not sure why, but when adding new ability, UpdateSelectIndicator doesn't work until next frame
    /// </summary>
    IEnumerator UpdateSelectorNextFrame()
    {
        yield return new WaitForEndOfFrame();
        UpdateSelectIndicator();
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

        panelScroller.transform.GetChild(selectedIndex).GetComponent<AbilityIcon>().PrepareAbility();
    }
    void ActivateAbility()
    {
        panelEquip.SetActive(true);
        panelActivate.SetActive(false);
        panelUnequip.SetActive(false);

        scrollFrozen = false;
        SetPlayerTranslation(true);

        // Execute ability
        // ability will destroy itself if applicable
        panelScroller.transform.GetChild(selectedIndex).GetComponent<AbilityIcon>().ExecuteAbility();

        //// update selection (keep selectedIndex the same)
        //CheckIndexOOB();
        //if (panelScroller.transform.childCount <= 0)
        //    selectIndicator.SetActive(false);
        //else
        //    UpdateSelectIndicator();
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
        print("Set player translation to: " + canMove);
    }

    public void FinishAbility()
    {
        if (panelScroller.transform.childCount == 0)
        {
            selectIndicator.SetActive(false);
            print("Finished last ability");
        }
        else
        {
            CheckIndexOOB();
            UpdateSelectIndicator();
        }
    }

    public void AddAbility(GameObject newAbility)
    {
        if (panelScroller.transform.childCount >= MAX_ABILITIES)
        {
            Destroy(newAbility);
            return;
        }
        newAbility.transform.SetParent(panelScroller.transform, false);
        selectIndicator.SetActive(true); // in case this is the first ability
        StartCoroutine(nameof(UpdateSelectorNextFrame));
    }

}
