using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowMenus : MonoBehaviour
{


    public enum Menus
    {
        BodyMenu = 0,
        HairMenu = 1,
        SkinMenu = 2,
        ShirtMenu = 3,
    }

    public GameObject[] menus;

    private void Start()
    {
        HideAllMenus();
    }

    public void ShowMenu(Menus pMenu)
    {
        for (int i=0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == (int)pMenu);
        }
    }

    public void HideAllMenus()
    {
        for (int i=0; i < menus.Length; i++)
        {
            menus[i].SetActive(false);
        }
    }

    public void OnBodyTypeMenu()
    {
        ShowMenu(Menus.BodyMenu);
    }

    public void OnHairMenu()
    {
        ShowMenu(Menus.HairMenu);
    }

    public void OnSkinMenu()
    {
        ShowMenu(Menus.SkinMenu);
    }

    public void OnShirtMenu()
    {
        ShowMenu(Menus.ShirtMenu);
    }


}
