using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public Gradient ambianColor;
    public Gradient fogColor;
    public Gradient directionalLightColor;

    public Light directionalLight;

    [Range(0, 24)] public float dayTime;



    void Start()
    {

    }


    void Update()
    {
        dayTime += Time.deltaTime;
        dayTime %= 24;

        UpdateLight(dayTime / 24);
    }

    private void UpdateLight(float timePercent)
    {
        RenderSettings.ambientLight = ambianColor.Evaluate(timePercent);
        RenderSettings.fogColor = fogColor.Evaluate(timePercent);

        directionalLight.color = directionalLightColor.Evaluate(timePercent);
        directionalLight.transform.localRotation = Quaternion.Euler((timePercent * 360) - 90, 270, 0);
    }
}
