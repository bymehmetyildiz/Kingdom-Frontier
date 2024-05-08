using System.Collections;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public Gradient ambianColor;
    public Gradient fogColor;
    public Gradient directionalLightColor;

    public Light directionalLight;

    [Range(0, 24)] public float dayTime;

    private bool dayEnd;
    private int dayCounter;
    [SerializeField] private TMP_Text dayCountText;



    void Start()
    {
        dayCounter = 1;
        dayCountText.text = "Day: " + dayCounter.ToString();
    }


    void Update()
    {
        float previousDayTime = dayTime;
        dayTime += Time.deltaTime;
        dayTime %= 24;

        // Check if dayTime has wrapped around
        if (previousDayTime > dayTime)
        {
            dayCounter++;
            dayCountText.text = "Day: " + dayCounter.ToString();
        }

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
