using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {
    public GameObject MainPanel, ConnectPanel;
    public string GameScene;

	void Start () {
		
	}
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameScene);
    }
    public void Connect()
    {
        MainPanel.SetActive(false);
        ConnectPanel.SetActive(true);
    }
    public void Back()
    { 
        MainPanel.SetActive(true);
        ConnectPanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
