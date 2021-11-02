﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiUIMan : MonoBehaviour
{
    public NameMenuPair[] nameMenu;
    //public NameMenuPr[] menuPrs;

    private Dictionary<string, PiUI> dict = new Dictionary<string, PiUI>( );
    //private Dictionary<string, isLevelTower> dictionary = new Dictionary<string, isLevelTower>();

    private void Awake()
    {
        foreach(NameMenuPair pair in nameMenu)
        {
            dict.Add(pair.name, pair.menu);
        }
        //foreach (NameMenuPr pair in menuPrs)
        //{
        //    dictionary.Add(pair.name, pair.menu);
        //}
        transform.localScale = new Vector3(1f / Screen.width, 1f / Screen.height);
		transform.position = Vector2.zero;
    }


    /// <summary>
    /// Will open/close the menu name passed at the position passed.
    /// </summary>
    /// <param name="menuName">Menu to open or close.</param>
    /// <param name="pos">Position to open menu.</param>
    public void ChangeMenuState(string menuName, Vector2 pos = default(Vector2))
    {
        PiUI currentPi = GetPiUIOf(menuName);
        if (currentPi.openedMenu)
        {
            currentPi.CloseMenu( );
        }else
        {
            currentPi.OpenMenu(pos);
        }
    }
   
    /// <summary>
    /// Gets if the passed in piUi is currently opened
    /// </summary>
    /// <param name="piName"></param>
    /// <returns></returns>
    public bool PiOpened(string menuName)
    {
        return GetPiUIOf(menuName).openedMenu;
    }
    /// <summary>
    /// Gets if the passed in piUi is currently opened
    /// </summary>
    /// <param name="piName"></param>
    /// <returns></returns>
    //public bool islvlOpened(string mname)
    //{
    //    return GetTower(mname).openedMenu;
    //}
    /// <summary>
    /// Returns the PiUi for the given menu allowing you to change it as you wish
    /// </summary>
    public PiUI GetPiUIOf(string menuName)
    {
        if (dict.ContainsKey(menuName))
        {
            return dict[menuName];
        }
        else{
            NoMenuOfThatName( );
            return null;
        }
    }
    //public isLevelTower GetTower(string mname)
    //{
    //    if (dictionary.ContainsKey(mname))
    //    {
    //        return dictionary[mname];
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}
    //public void RegenerateisLvlMenu(string menuName, Vector2 newPos = default(Vector2))
    //{
    //    GetTower(menuName).GenerateLevel(newPos);
    //} public void ChangeMState(string menuName, Vector2 pos = default(Vector2))
    //{
    //    isLevelTower currentPi = GetTower(menuName);
    //    if (currentPi.openedMenu)
    //    {
    //        currentPi.CloseMenu( );
    //    }else
    //    {
    //        currentPi.OpenMenu(pos);
    //    }
    //}

    //public bool islevelOpened(string menuName)
    //{
    //    return GetTower(menuName).openedMenu;
    //}
    //public void UpdateisLevelMenu(string menuName)
    //{
    //    GetTower(menuName).UpdateislvlUI();
    //}
    /// <summary>
    /// After changing the PiUI.sliceCount value and piData data,call this function with the menu name to recreate the menu, at a given position
    /// </summary>
    public void RegeneratePiMenu(string menuName,Vector2 newPos = default(Vector2))
    {
        GetPiUIOf(menuName).GeneratePi(newPos);
    }
    /// <summary>
    /// After changing the PiUI.PiData call this function to update the slices, if sliceCount is changed call RegeneratePiMenu
    /// </summary>
    public void UpdatePiMenu(string menuName)
    {
        GetPiUIOf(menuName).UpdatePiUI( );
    }

    public bool OverAMenu()
    {
        foreach(KeyValuePair<string,PiUI> pi in dict)
        {
            if (pi.Value.overMenu)
            {
                return true;
            }
        }
        return false;
    }



    private void NoMenuOfThatName()
    {
        Debug.LogError("No pi menu with that name, please check the name of which you're calling");
    }

    [System.Serializable]
    public class NameMenuPair
    {
        public string name;
        public PiUI menu;

    }
    //[System.Serializable]
    //public class NameMenuPr
    //{
    //    public string name;
    //    public isLevelTower menu;
    //}
}
