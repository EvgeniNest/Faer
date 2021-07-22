using UnityEngine;


[RequireComponent(typeof(Light))]
public class LightSeting : MonoBehaviour
{
    [SerializeField]
    private Color _colorSky;

    [SerializeField]
    private Color _colorEquator;

    [SerializeField]
    private Color _ColorGround;

    [SerializeField]
    private Color _ColorLight;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
        ChangeAmbientColor();
    }

    private void ChangeAmbientColor()
    {
        RenderSettings.ambientSkyColor = _colorSky;
        RenderSettings.ambientEquatorColor = _colorEquator;
        RenderSettings.ambientGroundColor = _ColorGround;

        _light.color = _ColorLight;
    }

}