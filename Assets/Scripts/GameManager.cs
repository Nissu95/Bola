using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    
    [SerializeField] string playerTag;
    [SerializeField] float distanceFromTarget;
    [SerializeField] float cameraSpeed;

    //.....................................................................
    //Menus 

    [SerializeField] GameObject game;
    [SerializeField] GameObject loseMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;

    //.....................................................................
    //Score

    [SerializeField] Transform startPositionTransform;
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] Text scoreTextMenu;

    int currentScore = 0;
    int highScore = 0;
    Vector3 startPostion;

    //.....................................................................

    Modes modes;
    Transform playerTrans;
    Transform cameraTrans;
    BallBehaviour ballBehaviour;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;

        GetGroundChecker groundChecker = FindObjectOfType<GetGroundChecker>();
        if (groundChecker)
            playerTrans = groundChecker.GetTransform();

        startPostion = startPositionTransform.position;
        cameraTrans = Camera.main.transform;
        ballBehaviour = FindObjectOfType<BallBehaviour>();
        loseMenu.SetActive(false);

        UpdateScoreText();
        game.SetActive(false);
    }

    private void Update()
    {
        float dis = (startPostion - playerTrans.position).magnitude;

        if (playerTrans.position.y > startPostion.y && dis > currentScore)
        {
            currentScore = (int)dis;
            UpdateScoreText();
        }
    }

    public Modes GetGameMode()
    {
        return modes;
    }

    public Transform GetPlayerTrans()
    {
        return playerTrans;
    }

    public Transform GetCameraTrans()
    {
        return cameraTrans;
    }

    public float GetDistanceFromTarget()
    {
        return distanceFromTarget;
    }

    public float GetCameraSpeed()
    {
        return cameraSpeed;
    }

    //.....................................................................
    //Menus 

    public void DisplayLoseMenu()
    {
        loseMenu.SetActive(true);
        HighscoreSelection();

        highScoreText.text = "Máxima puntuación: " + highScore.ToString();
        scoreTextMenu.text = "Puntuación: " + currentScore.ToString();
    }

    //.....................................................................
    //Buttons

    public void RetryButton()
    {
        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        cameraFollow.ResetCamera();
        cameraFollow.ResetGameMode();
        cameraFollow.SetGameMode();

        ballBehaviour.ResetPlayer();

        FindObjectOfType<PlatformManager>().ResetPlatforms();

        ResumeButton();

        currentScore = 0;
        UpdateScoreText();
        loseMenu.SetActive(false);
    }

    public void BackToMenuButton()
    {
        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        cameraFollow.ResetCamera();
        cameraFollow.ResetGameMode();

        ResumeButton();

        game.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void NormalModeButton()
    {
        modes = Modes.Normal;

        mainMenu.SetActive(false);
        game.SetActive(true);

        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        cameraFollow.ResetCamera();
        cameraFollow.SetGameMode();

        ballBehaviour.ResetPlayer();

        FindObjectOfType<PlatformManager>().ResetPlatforms();

        currentScore = 0;
        UpdateScoreText();
        loseMenu.SetActive(false);
    }

    public void HardcoreModeButton()
    {
        modes = Modes.Hardcore;

        mainMenu.SetActive(false);
        game.SetActive(true);

        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        cameraFollow.ResetCamera();
        cameraFollow.SetGameMode();

        ballBehaviour.ResetPlayer();

        FindObjectOfType<PlatformManager>().ResetPlatforms();

        currentScore = 0;
        UpdateScoreText();
        loseMenu.SetActive(false);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MuteButton()
    {
        switch (AudioListener.pause)
        {
            case true:
                AudioListener.pause = false;
                break;
            case false:
                AudioListener.pause = true;
                break;
        }
    }

    public void HighscoreButton()
    {

    }

    public void SettingsButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }

    //.....................................................................
    //Score

    void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    void HighscoreSelection()
    {
        if (highScore < currentScore)
            highScore = currentScore;
    }

    //.....................................................................
}
