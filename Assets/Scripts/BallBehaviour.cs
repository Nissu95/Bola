using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public void PlayerLose()
    {
        gameObject.SetActive(false);
        GameManager.singleton.DisplayLoseMenu();
    }
}
