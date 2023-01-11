using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] public Slider DefaultTimeSlider;
    [SerializeField] public Slider ReduceTimeSlider;
    [SerializeField] public Slider MinimumTimeSlider;

    [Header("Sliders Text")]
    [SerializeField] public TMP_Text DefaultTimeText;
    [SerializeField] public TMP_Text ReduceTimeText;
    [SerializeField] public TMP_Text MinimumTimeText;

    [Header("Default Values")]
    private float DefaultTime = 3f;
    private float ReduceTime = 5f;
    private float MinimumTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        DefaultTimeSlider.value = DefaultTime;
        ReduceTimeSlider.value = ReduceTime;
        MinimumTimeSlider.value = MinimumTime;
        if (PlayerPrefs.HasKey("DefaultTime")) DefaultTimeSlider.value = PlayerPrefs.GetFloat("DefaultTime", DefaultTime);
        else if (PlayerPrefs.HasKey("DefaultTime")) ReduceTimeSlider.value = PlayerPrefs.GetFloat("ReduceTime", ReduceTime) / 100;
        else if (PlayerPrefs.HasKey("MinimumTime")) MinimumTimeSlider.value = PlayerPrefs.GetFloat("MinimumTime", MinimumTime);
        DefaultTimeText.text = DefaultTimeSlider.value.ToString();
        ReduceTimeText.text = ReduceTimeSlider.value.ToString();
        MinimumTimeText.text = MinimumTimeSlider.value.ToString();
    }

    public void OnDefaultTimeValueChange(System.Single value)
    {
        DefaultTimeText.text = value.ToString();
        PlayerPrefs.SetFloat("DefaultTime", value);
    }

    public void OnReduceTimeValueChange(System.Single value)
    {
        ReduceTimeText.text = value.ToString();
        PlayerPrefs.SetFloat("ReduceTime", value);
    }

    public void OnMinimumTimeValueChange(System.Single value)
    {
        MinimumTimeText.text = value.ToString();
        PlayerPrefs.SetFloat("MinimumTime", value);
    }

    public void ChangeScene() {
        SceneManager.LoadScene("AntoineCopyPaste");
    }
}
