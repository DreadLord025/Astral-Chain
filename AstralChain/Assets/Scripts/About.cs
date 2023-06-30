using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class About : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;
    private AutoExposure autoExposure;
    private Vignette vignette;

    public GameObject InfoPanel;

    private void Start()
    {
        postProcessVolume = Camera.main.GetComponent<PostProcessVolume>();
        depthOfField = postProcessVolume.profile.GetSetting<DepthOfField>();
        autoExposure = postProcessVolume.profile.GetSetting<AutoExposure>();
        vignette = postProcessVolume.profile.GetSetting<Vignette>();
    }

    public void AboutClick()
    {
        InfoPanel.active = true;
        depthOfField.enabled.value = true;
        autoExposure.enabled.value = true;
        vignette.enabled.value = true;
    }
    public void AboutOKClick()
    {
        InfoPanel.active = false;
        depthOfField.enabled.value = false;
        autoExposure.enabled.value = false;
        vignette.enabled.value = false;
    }
}
