using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Transform startPositionTransform;
    [SerializeField] Text scoreText;

    int currentScore = 0;

    Transform playerTransform;
    Vector3 startPostion;

    private void Start()
    {
        startPostion = startPositionTransform.position;

        playerTransform = GameManager.singleton.GetPlayerTrans();

        UpdateScoreText();
    }

    void Update()
    {
        float dis = (startPostion - playerTransform.position).magnitude;

        if (playerTransform.position.y > startPostion.y && dis > currentScore)
        {
            currentScore = (int)dis;

            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }
}
