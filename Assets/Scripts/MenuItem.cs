using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour
{
    public NestedMenu parentMenu = null;
    NestedMenu subMenu = null;
    internal int menuItemWidth = 150;
    internal int menuItemHeight = 30;

    //Inititalize this menu item by setting 
    // its parent, name and base events
    public void Configure(NestedMenu parent, string name)
    {
        this.name = name;
        this.GetComponentInChildren<Text>().text = name;
        this.parentMenu = parent;
        AddEvent(EventTriggerType.PointerEnter, this.OpenSubMenu);
        AddEvent(EventTriggerType.PointerExit, this.CloseSubMenu);
    }

    //Add a submenu to this item
    public NestedMenu AddSubMenu()
    {
        GameObject nestedMenuGO =
            GameObject.Instantiate(
                Resources.Load<GameObject>("NestedMenu"));

        NestedMenu nestedMenu = nestedMenuGO.
            GetComponent<NestedMenu>();

        //Inset the menu item
        GetComponent<RectTransform>()
            .SetInsetAndSizeFromParentEdge
            (RectTransform.Edge.Right,
            -nestedMenu.menuWidth,
            nestedMenu.menuWidth);

        nestedMenu.transform.SetParent(this.transform);
        nestedMenu.parentMenuItem = this;
        this.subMenu = nestedMenu;

        subMenu.gameObject.SetActive(false);

        return nestedMenu;
    }

    //Event that triggers when the sub menu is opened
    public void OpenSubMenu(BaseEventData eventData)
    {
        if (subMenu != null)
        {
            subMenu.gameObject.SetActive(true);
        }
        parentMenu.Opening(this.name);
    }

    //Event that triggers when the sub menu is closed
    public void CloseSubMenu(BaseEventData eventData = null)
    {
        if (subMenu != null && subMenu.enabled)
        {
            subMenu.CloseAll();
            subMenu.gameObject.SetActive(false);
        }
    }

    //Add events to the local event trigger
    public void AddEvent(EventTriggerType triggerType,
        Action<BaseEventData> method)
    {
        if (method == null)
            return;

        EventTrigger localEventTrigger =
            this.GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = triggerType;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(
            new UnityEngine.Events.
            UnityAction<BaseEventData>(method));

        if (localEventTrigger.triggers == null)
        {
            localEventTrigger.triggers =
                new System.Collections.Generic.
                List<EventTrigger.Entry>();
        }

        localEventTrigger.triggers.Add(entry);
    }
}
