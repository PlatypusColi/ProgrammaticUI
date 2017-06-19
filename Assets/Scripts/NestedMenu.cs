using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

public class NestedMenu : MonoBehaviour
{
    internal int menuWidth = 160;
    public MenuItem parentMenuItem = null;
    Dictionary<string, MenuItem> menuItems = new Dictionary<string, MenuItem>();

    public void Start()
    {
        //If this is a root node, generate a test menu
        if (parentMenuItem == null)
        {
            MenuItem baseItem = this.AddMenuItem("Base Menu", null);


        }
    }

    public MenuItem AddMenuItem(string name, Action<BaseEventData> method)
    {
        GameObject menuItemGO = GameObject.Instantiate(Resources.Load<GameObject>("MenuItem"));
        MenuItem menuItem = menuItemGO.GetComponent<MenuItem>();
        menuItem.Configure(this, name);
        menuItem.AddEvent(EventTriggerType.PointerClick, method);
        menuItems.Add(name, menuItem);
        menuItemGO.transform.SetParent(this.transform);

        RectTransform rect2D = this.GetComponent<RectTransform>();

        int menuOffset = menuItem.menuItemWidth;
        if (parentMenuItem == null)
        {
            menuOffset = 0;
        }

        rect2D.SetInsetAndSizeFromParentEdge(
            RectTransform.Edge.Left, menuOffset, menuWidth);
        rect2D.SetInsetAndSizeFromParentEdge(
            RectTransform.Edge.Top, 0,
            rect2D.sizeDelta.y + menuItem.menuItemHeight + 1);

        return menuItem;
    }

    //Walk up the menu tree, closing everything that's not part of this path
    public void Opening(string openingItem)
    {
        foreach (string key in menuItems.Keys)
        {
            if (key != openingItem)
            {
                menuItems[key].CloseSubMenu();
            }
        }
    }

    //Walk down the menu tree, closing everything in this subtree
    public void CloseAll()
    {
        foreach (string key in menuItems.Keys)
        {
            menuItems[key].CloseSubMenu();
        }
    }

    //A basic click event for testing our menu
    public void MenuItemClick(BaseEventData baseEventData)
    {
        Debug.Log(baseEventData.selectedObject.name);
    }

    //A basic click event for testing our menu
    public void MenuItemClickAlt(BaseEventData baseEventData)
    {
        Debug.Log("Alternate" + baseEventData.selectedObject.name);
    }
}