using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomiseHandler : MonoBehaviour
{

    public CharacterLookController characterController;

    [SerializeField] private Transform headAnchor;
    [SerializeField] private Transform bodyAnchor;

    public Button[] bodyTypeButtons;
    public Button[] hairStyleButtons;
    public Button[] hairColourButtons;
    public Button[] skinColourButtons;
    public Button[] shirtStyleButtons;

    public GameObject[] bodyType;
    public GameObject[] hairStyle;

    public Material[] hairColour;
    public Material[] skinTone;
    public Material[] shirtStyle;

    LookConfig myConfig = new LookConfig();

    Dictionary<CharacterLookController.AppearanceDetails, int> chosenAppearance;


    int bodyIndex;
    int hairIndex;
    int shirtIndex;
    int hairColourIndex;
    int skinColourIndex;


    public void Start()
    {
        myConfig.bodyType = bodyType[0];
        myConfig.hairStyle = hairStyle[0];
        myConfig.hairColour = hairColour[0];
        myConfig.skinColour = skinTone[0];
        myConfig.shirtStyle = shirtStyle[0];
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
        myConfig.bodyType = bodyType[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Body_Type);
    }

    public void OnHairStyleClick(int id)
    {
        myConfig.hairStyle = hairStyle[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Hair_Style);
        
    }
    
    public void OnShirtStyleClick(int id)
    {
        myConfig.shirtStyle = shirtStyle[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Shirt_Style);
    }

    public void OnHairColourClick(int id)
    {
        myConfig.hairColour = hairColour[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Hair_Colour);
      
    }

    public void OnSkinColourClick(int id)
    {
        myConfig.skinColour = skinTone[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Skin_Colour);
    
    }

    public void SaveAppearanceDetails(CustomiseHandler CH)
    {
        chosenAppearance = new Dictionary<CharacterLookController.AppearanceDetails, int>();
        chosenAppearance.Add(CharacterLookController.AppearanceDetails.Body_Type, bodyIndex);
        chosenAppearance.Add(CharacterLookController.AppearanceDetails.Hair_Style, hairIndex);
        chosenAppearance.Add(CharacterLookController.AppearanceDetails.Shirt_Style, shirtIndex);
        chosenAppearance.Add(CharacterLookController.AppearanceDetails.Hair_Colour, hairColourIndex);
        chosenAppearance.Add(CharacterLookController.AppearanceDetails.Skin_Colour, skinColourIndex);
    }
}
