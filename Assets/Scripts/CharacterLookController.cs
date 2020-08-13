using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLookController : MonoBehaviour
{
    public enum BodyPart
    {
        Body,
        ShirtTexture,
        SkinColor,
        Hair
    }

    public GameObject head;
    public GameObject body;
    public GameObject hair;

    public void ApplyChanges(LookConfig myConfig, BodyPart details)
    {
        switch (details){
            case BodyPart.Body:
                {
                    body.GetComponent<SkinnedMeshRenderer>().sharedMesh = myConfig.bodyType;
                    break;
                }
            case BodyPart.ShirtTexture:
                {
                    body.GetComponent<SkinnedMeshRenderer>().material.mainTexture = myConfig.shirtStyle;
                    break;
                }
            case BodyPart.SkinColor:
                {
                    head.GetComponent<SkinnedMeshRenderer>().material.color = myConfig.skinColour;
                    break;
                }
            case BodyPart.Hair:
                {
                    foreach(Transform t in hair.transform)
                    {
                        Destroy(t.gameObject);
                    }

                    var hairGO = Instantiate(myConfig.hairStyle, hair.transform, false);

                    foreach(MeshRenderer mesh in hair.GetComponentsInChildren<MeshRenderer>())
                    {
                        mesh.material.color = myConfig.hairColour;
                    }
                    break;
                }
        }
    }
}
