using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//#if UNITY_EDITOR 
//using UnityEditor.SceneManagement;
//#endif
public class GameMenuUI : MonoBehaviour {
    [SerializeField]
    private GameObject WinPanel;
    [SerializeField]
    private GameObject GameOverPanel;
	// Use this for initialization
	void Start () {
        HideAllPanel();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.R)) 
        {
            OnRestartBtnDown();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            OnBackBtnDown();
        }
	}
    public void OnBackBtnDown() 
    {
        SceneManager.LoadScene(GameSetting.MainMenuSceneIndex);
        //else code
    }
    public void OnRestartBtnDown() 
    {
        SceneManager.LoadScene(GameSetting.GameSceneIndex);
        //else code
    }

    //
    private void HideAllPanel() 
    {
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }
    public void showWinpanel() 
    {
        WinPanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }
    public void showGameOverPanel() 
    {
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
}
