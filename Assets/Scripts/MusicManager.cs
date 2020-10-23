using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip mainTheme;
    public AudioClip menuTheme;

    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        OnLevelWasLoaded(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            AudioManager.instance.PlayMusic(mainTheme, 3);
        }
    }

    void OnLevelWasLoaded(int sceneIndex){
        string newSceneName = SceneManager.GetActiveScene().name;
        if(newSceneName != sceneName){
            sceneName = newSceneName;
            Invoke("PlayMusic", .2f);
        }
    }

    void PlayMusic(){
        AudioClip clipToPlay = null;

        if(sceneName == "Menu"){
            clipToPlay = menuTheme;
        }else if(sceneName == "Game"){
            clipToPlay = mainTheme;
        }

        if(clipToPlay != null){
            AudioManager.instance.PlayMusic(clipToPlay, 2);
            Invoke("PlayMusic", clipToPlay.length);
        }
    }
}
