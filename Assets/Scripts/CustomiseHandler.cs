using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

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

    public Texture2D[] shirtStyles;

    public Color32[] hairColours;
    public Color32[] skinTones;

    //Private Fields
    private LookConfig myConfig = new LookConfig();

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
        print("Button " + id + " was clicked");
        myConfig.shirtStyle = shirtStyles[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Shirt_Style);
    }

    public void OnHairColourClick(int id)
    {
        print("Button " + id + " was clicked");
        myConfig.hairColour = hairColours[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Hair_Colour);
      
    }

    public void OnSkinColourClick(int id)
    {
        print("Button " + id + " was clicked");
        myConfig.skinColour = skinTones[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.AppearanceDetails.Skin_Colour);
    
    }

    public void SaveAppearanceDetails()
    {
        LookConfig savedAppearance = new LookConfig();
        savedAppearance.bodyType = myConfig.bodyType;
        savedAppearance.hairStyle = myConfig.hairStyle;
        savedAppearance.hairColour = myConfig.hairColour;
        savedAppearance.skinColour = myConfig.skinColour;
        savedAppearance.shirtStyle = myConfig.shirtStyle;
    }

    public void OnDisable()
    {
        foreach(Button button in bodyTypeButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        foreach(Button button in hairStyleButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        foreach(Button button in hairColourButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        foreach(Button button in skinColourButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        foreach(Button button in shirtStyleButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
