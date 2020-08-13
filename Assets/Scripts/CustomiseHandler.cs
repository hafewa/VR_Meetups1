using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class CustomiseHandler : MonoBehaviour
{
    public CharacterLookController characterController;

    [Header("UI Buttons")]
    public Button[] bodyTypeButtons;
    public Button[] hairStyleButtons;
    public Button[] hairColourButtons;
    public Button[] skinColourButtons;
    public Button[] shirtStyleButtons;

    [Header("Options")]
    public Mesh[] bodyTypes;
    public GameObject[] hairStyles;
    public Texture2D[] shirtStyles;
    public Color32[] hairColours;
    public Color32[] skinTones;

    private LookConfig myConfig;

    public void Start()
    {
        myConfig = new LookConfig()
        {
            bodyType = bodyTypes[0],
            hairStyle = hairStyles[0],
            hairColour = hairColours[0],
            skinColour = skinTones[0],
            shirtStyle = shirtStyles[0]
        };
    }

    private void OnEnable()
    {
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

    public void OnDisable()
    {
        foreach (Button button in bodyTypeButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        foreach (Button button in hairStyleButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        foreach (Button button in hairColourButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        foreach (Button button in skinColourButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        foreach (Button button in shirtStyleButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }

    public void OnBodyTypeClick(int id)
    {
        myConfig.bodyType = bodyTypes[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.BodyPart.Body);
    }

    public void OnHairStyleClick(int id)
    {
        myConfig.hairStyle = hairStyles[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.BodyPart.Hair);
        
    }
    
    public void OnShirtStyleClick(int id)
    {
        myConfig.shirtStyle = shirtStyles[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.BodyPart.ShirtTexture);
    }

    public void OnHairColourClick(int id)
    {
        myConfig.hairColour = hairColours[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.BodyPart.Hair);
      
    }

    public void OnSkinColourClick(int id)
    {
        myConfig.skinColour = skinTones[id];
        characterController.ApplyChanges(myConfig, CharacterLookController.BodyPart.SkinColor);
    
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
}
