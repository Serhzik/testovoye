using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {
    public GameObject GamePanel, PausePanel;
    public GameObject LoadButton;
    public Text Score, Cam;
    public Slider slider;
    public MoveControl Loco;
    public CameraSwitch CS;
    ScoreController SC;
    public event Action<bool> Paused;

    string FL = "FreeLook", HF = "HardFollow";

    private void Start()
    {
        SC = Loco.GetComponent<ScoreController>();
        SC.MayLoad += OnMayLoad;
        SC.Score += OnScore;
        CS.SwitchCamera += OnSwitchCamera;
    }

    public void OnSlider()
    {
        Loco.SetSpeed(slider.value * 10);
    }
    public void Pause(bool state)
    {
        GamePanel.SetActive(!state);
        PausePanel.SetActive(state);
        Loco.Pause(state);
        if (Paused != null)
            Paused(state);
    }
    void OnMayLoad(bool state)
    {
        LoadButton.SetActive(state);
    }
    void OnScore(int score)
    {
        Score.text = score.ToString();
    }
    void OnSwitchCamera(bool isFreeLook)
    {
        if (isFreeLook)
            Cam.text = HF;
        else
            Cam.text = FL;
    }
    private void OnDestroy()
    {
        SC.MayLoad -= OnMayLoad;
    }

}
