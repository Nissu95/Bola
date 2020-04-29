using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    [SerializeField] Modes modes;
    [SerializeField] string playerTag;
    [SerializeField] float distanceFromTarget;
    [SerializeField] float cameraSpeed;

    //.....................................................................
    //Menus 

    [SerializeField] GameObject game;
    [SerializeField] GameObject loseMenu;
    [SerializeField] GameObject mainMenu;

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
        FindObjectOfType<CameraFollow>().ResetCamera();
        ballBehaviour.ResetPlayer();
        FindObjectOfType<PlatformManager>().ResetPlatforms();
        currentScore = 0;
        UpdateScoreText();
        loseMenu.SetActive(false);
    }

    public void BackToMenuButton()
    {
        game.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayButton()
    {
        mainMenu.SetActive(false);
        game.SetActive(true);
        FindObjectOfType<CameraFollow>().ResetCamera();
        ballBehaviour.ResetPlayer();
        FindObjectOfType<PlatformManager>().ResetPlatforms();
        currentScore = 0;
        UpdateScoreText();
        loseMenu.SetActive(false);
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
