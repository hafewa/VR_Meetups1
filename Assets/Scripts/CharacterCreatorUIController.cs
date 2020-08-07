using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterCreatorUIController : MonoBehaviour
{


    public enum Menus
    {
        BodyMenu = 0,
        HairMenu = 1,
        SkinMenu = 2,
        ShirtMenu = 3,
    }

    public enum Buttons
    {
        BodyButton = 0,
        HairButton = 1,
        SkinButton = 2,
        ShirtButton = 3,
    }

    public GameObject[] menus;
    public GameObject[] buttons;

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

    private void ShowButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    public void OnBodyTypeMenu()
    {
        ShowButtons();
        ShowMenu(Menus.BodyMenu);
        buttons[0].SetActive(false);
    }

    public void OnHairMenu()
    {
        ShowButtons();
        ShowMenu(Menus.HairMenu);
        buttons[1].SetActive(false);
    }

    public void OnSkinMenu()
    {
        ShowButtons();
        ShowMenu(Menus.SkinMenu);
        buttons[2].SetActive(false);
    }

    public void OnShirtMenu()
    {
        ShowButtons();
        ShowMenu(Menus.ShirtMenu);
        buttons[3].SetActive(false);
    }


}
