using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomiseHandler : MonoBehaviour
{
    //Editor Fields
    public CharacterLookController characterController;

    [SerializeField] private Transform headAnchor;
    [SerializeField] private Transform bodyAnchor;

    public Button[] bodyTypeButtons;
    public Button[] hairStyleButtons;
    public Button[] hairColourButtons;
    public Button[] skinColourButtons;
    public Button[] shirtStyleButtons;

    public GameObject[] bodyTypes;
    public GameObject[] hairStyles;

    public Material[] hairColours;
    public Material[] skinTones;
    public Material[] shirtStyles;

    //Private Fields
    private LookConfig myConfig = new LookConfig();
    private int bodyIndex;
    private int hairIndex;
    private int shirtIndex;
    private int hairColourIndex;
    private int skinColourIndex;


    public void Start()
    {
        myConfig.bodyType = bodyTypes[0];
        myConfig.hairStyle = hairStyles[0];
        myConfig.hairColour = hairColours[0];
        myConfig.skinColour = skinTones[0];
        myConfig.shirtStyle = shirtStyles[0];
        for (int i = 0; i < bodyTypeButtons.Length; i++)
        {
            int bodyIndex = i;
            bodyTypeButtons[bodyIndex].onClick.AddListener(() => OnBodyTypeClick(bodyIndex));
            
        }
        for (int i = 0; i < hairStyleButtons.Length; i++)
        {
            int hairIndex = i;
            hairStyleButtons[hairIndex].onClick.AddListener(() => OnHairStyleClick(hairIndex));
        }
        for (int i = 0; i < shirtStyleButtons.Length; i++)
        {
            int shirtIndex = i;
            shirtStyleButtons[shirtIndex].onClick.AddListener(() => OnShirtStyleClick(shirtIndex));
        }
        for (int i = 0; i < hairColourButtons.Length; i++)
        {
            int hairColourIndex = i;
            hairColourButtons[hairColourIndex].onClick.AddListener(() => OnHairColourClick(hairColourIndex));
        }
        for (int i = 0; i < skinColourButtons.Length; i++)
        {
            int skinColourIndex = i;
            skinColourButtons[skinColourIndex].onClick.AddListener(() => OnSkinColourClick(skinColourIndex));
        }
    }

    public void OnBodyTypeClick(int id)
    {
        myConfig.bodyType = bodyTypes[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Body_Type);
    }

    public void OnHairStyleClick(int id)
    {
        myConfig.hairStyle = hairStyles[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Hair_Style);
        
    }
    
    public void OnShirtStyleClick(int id)
    {
        myConfig.shirtStyle = shirtStyles[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Shirt_Style);
    }

    public void OnHairColourClick(int id)
    {
        myConfig.hairColour = hairColours[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Hair_Colour);
      
    }

    public void OnSkinColourClick(int id)
    {
        myConfig.skinColour = skinTones[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Skin_Colour);
    
    }

    public void SaveAppearanceDetails()
    {
        LookConfig savedAppearance = new LookConfig();
        savedAppearance.bodyType = bodyTypes[bodyIndex];
        savedAppearance.hairStyle = hairStyles[hairIndex];
        savedAppearance.hairColour = hairColours[hairColourIndex];
        savedAppearance.skinColour = skinTones[skinColourIndex];
        savedAppearance.shirtStyle = shirtStyles[shirtIndex];

    }

    public void OnDisable()
    {
        for (int i = 0; i < bodyTypeButtons.Length; i++)
        {
            int bodyIndex = i;
            bodyTypeButtons[bodyIndex].onClick.RemoveListener(() => OnBodyTypeClick(bodyIndex));

        }
        for (int i = 0; i < hairStyleButtons.Length; i++)
        {
            int hairIndex = i;
            hairStyleButtons[hairIndex].onClick.RemoveListener(() => OnHairStyleClick(hairIndex));
        }
        for (int i = 0; i < shirtStyleButtons.Length; i++)
        {
            int shirtIndex = i;
            shirtStyleButtons[shirtIndex].onClick.RemoveListener(() => OnShirtStyleClick(shirtIndex));
        }
        for (int i = 0; i < hairColourButtons.Length; i++)
        {
            int hairColourIndex = i;
            hairColourButtons[hairColourIndex].onClick.RemoveListener(() => OnHairColourClick(hairColourIndex));
        }
        for (int i = 0; i < skinColourButtons.Length; i++)
        {
            int skinColourIndex = i;
            skinColourButtons[skinColourIndex].onClick.RemoveListener(() => OnSkinColourClick(skinColourIndex));
        }
    }
}
