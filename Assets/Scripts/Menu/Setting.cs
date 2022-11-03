using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [Tooltip("_sceneToLoadOnPlay is the name of the scene that will be loaded when users click play")]
	public string _sceneToLoadOnPlay = "MainMenu";
	[Tooltip("_soundButtons define the SoundOn[0] and SoundOff[1] Button objects.")]
	public Button[] _soundButtons;
	[Tooltip("_audioClip defines the audio to be played on button click.")]
	public AudioClip _audioClip;
	[Tooltip("_audioSource defines the Audio Source component in this scene.")]
	public AudioSource _audioSource;
    
    public static bool gamePaused = false;
    public GameObject gameMenuUI;
    public Button MenuButton;

    UnityEngine.SceneManagement.Scene scene;


    // Start is called before the first frame update
    void Awake () {
		if(!PlayerPrefs.HasKey("_Mute")){
			PlayerPrefs.SetInt("_Mute", 0);
		}
		
		scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
		PlayerPrefs.SetString("_LastScene", scene.name.ToString()); 
		//Debug.Log(scene.name);
	}

    void Start()
    {
        Button btn = MenuButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        } 
    }

    private void TaskOnClick(){
		if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            };
	}

    public void ExitGame () {
		_audioSource.PlayOneShot(_audioClip);
		PlayerPrefs.SetString("_LastScene", scene.name);
		UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneToLoadOnPlay);
	}

    public void Mute () {
		_audioSource.PlayOneShot(_audioClip);
		_soundButtons[0].interactable = true;
		_soundButtons[1].interactable = false;
		PlayerPrefs.SetInt("_Mute", 1);
	}
	
	public void Unmute () {
		_audioSource.PlayOneShot(_audioClip);
		_soundButtons[0].interactable = false;
		_soundButtons[1].interactable = true;
		PlayerPrefs.SetInt("_Mute", 0);
	}

    public void PauseGame ()
    {
        Time.timeScale = 0;
        gameMenuUI.SetActive(true);
        gamePaused = true;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
        gameMenuUI.SetActive(false);
        gamePaused = false;
    }
}
