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

    private float DefaultTime = 5f;
    private float ReduceTime = 0.05f;
    private float MinimumTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("DefaultTime")) {
            DefaultTimeSlider.value = PlayerPrefs.GetFloat("DefaultTime", DefaultTime);
            ReduceTimeSlider.value = PlayerPrefs.GetFloat("ReduceTime", ReduceTime) * 100;
            MinimumTimeSlider.value = PlayerPrefs.GetFloat("MinimumTime", MinimumTime);
        }
        else {
            DefaultTimeSlider.value = DefaultTime;
            ReduceTimeSlider.value = ReduceTime * 100;
            MinimumTimeSlider.value = MinimumTime;
        }
        // DefaultTimeSlider.onValueChanged.AddListener(delegate {ValueChange("Default Slider", DefaultTimeSlider.value);});
        // ReduceTimeSlider.onValueChanged.AddListener(delegate {ValueChange("Reduce Slider", ReduceTimeSlider.value);});
        // MinimumTimeSlider.onValueChanged.AddListener(delegate {ValueChange("Minimum Slider", MinimumTimeSlider.value);});
    }

    // Update is called once per frame
    void Update()
    {
        if (DefaultTime != DefaultTimeSlider.value) {
            DefaultTime = DefaultTimeSlider.value;
            ValueChange("DefaultTime", DefaultTime);
            DefaultTimeText.text = DefaultTime.ToString();
        }
        if ((ReduceTime * 100.0f) != ReduceTimeSlider.value * 1.0f) {
            ReduceTime = ReduceTimeSlider.value / 100;
            ValueChange("ReduceTime", ReduceTime);
            ReduceTimeText.text = ReduceTime.ToString();
        }        
        if (MinimumTime != MinimumTimeSlider.value) {
            MinimumTime = MinimumTimeSlider.value;
            ValueChange("MinimumTime", MinimumTime);
            MinimumTimeText.text = MinimumTime.ToString();
        }
    }

    void ValueChange(string type, float value)
    {
        //Debug.Log("Changing " + type + " to " + value.ToString());
        PlayerPrefs.SetFloat(type, value);
    }

    public void changeScene() {
        SceneManager.LoadScene("AntoineCopyPaste");
    }
}
