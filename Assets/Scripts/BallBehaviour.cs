using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Vector3 initialPos;

    private void Awake()
    {
        initialPos = transform.position;
    }

    public void PlayerLose()
    {
        gameObject.SetActive(false);
        GameManager.singleton.DisplayLoseMenu();
    }

    public void ResetPlayer()
    {
        transform.position = initialPos;
        gameObject.SetActive(true);
    }
}
