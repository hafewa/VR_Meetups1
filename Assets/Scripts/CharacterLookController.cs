using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLookController : MonoBehaviour
{
    public Transform headAnchor;
    public Transform bodyAnchor;

    public enum AppearanceDetails
    {
        Body_Type,
        Hair_Style,
        Hair_Colour,
        Skin_Colour,
        Shirt_Style,
        Shirt_Colour,
    }

    public GameObject activeHead;
    public GameObject activeBody;
    public GameObject activeHair;
    public GameObject activeShirt;

    public void ApplyChanges(LookConfig myConfig, AppearanceDetails details)
    {
        switch (details){
            case AppearanceDetails.Body_Type:
                {
                    if (activeBody !=null)
                    {
                        GameObject.Destroy(activeBody);
                    }
                    activeBody = GameObject.Instantiate(myConfig.bodyType);
                    activeBody.transform.SetParent(bodyAnchor);
                    activeBody.transform.ResetTransform();
                }
                break;
            case AppearanceDetails.Hair_Style:
                {
                    if (activeHair != null)
                    {
                        GameObject.Destroy(activeHair);
                    }
                    activeHair = GameObject.Instantiate(myConfig.hairStyle);
                    activeHair.transform.SetParent(headAnchor);
                    activeHair.transform.ResetTransform();
                }
                break;
            case AppearanceDetails.Shirt_Style:
                {
                    if (activeShirt != null)
                    {
                        activeShirt.GetComponent<SkinnedMeshRenderer>().material = myConfig.shirtStyle;
                    }
                }
                break;
            case AppearanceDetails.Hair_Colour:
                {
                    if (activeHair != null)
                    {
                        foreach (MeshRenderer mesh in activeHair.GetComponentsInChildren<MeshRenderer>())
                        {
                            mesh.material = myConfig.hairColour;
                        }
                    }
                }
                break;
            case AppearanceDetails.Skin_Colour:
                {
                    if (activeBody != null)
                    {
                        activeHead.GetComponent<SkinnedMeshRenderer>().material = myConfig.skinColour;
                    }
                    break;
                }
        }

    }
}
