using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllScenes : MonoBehaviour
{
    [SerializeField] GameObject loseMenu;

    private void Start()
    {
        GameManager.singleton.SetLoseMenu(loseMenu);
    }
}
