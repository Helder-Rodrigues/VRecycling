using UnityEngine;

public class VRSceneInput : MonoBehaviour
{
    [SerializeField] private SceneFader fader;
    [SerializeField] private string sceneToLoad;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) ||   
            OVRInput.GetDown(OVRInput.Button.Two))
        {
            fader.FadeAndLoadScene(sceneToLoad);
        }
    }
}