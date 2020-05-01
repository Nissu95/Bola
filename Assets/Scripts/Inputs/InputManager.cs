using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager singleton;

    AllInputs inputs;
    float horizontal;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;

#if UNITY_EDITOR

        inputs = new PCInputs();
#else
        inputs = new MobileInputs();
#endif
    }

    public float GetHorizontalInputs()
    {
        inputs.UpdateInputs();
        return inputs.GetHorizontal();
    }
}
