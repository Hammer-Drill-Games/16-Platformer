using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [System.Obsolete]
    void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		Screen.SetResolution(1024, 640, FullScreenMode.Windowed, Screen.currentResolution.refreshRate);
	}

	void TaskOnClick(){
        SceneManager.LoadSceneAsync("Level-1");
	}
}