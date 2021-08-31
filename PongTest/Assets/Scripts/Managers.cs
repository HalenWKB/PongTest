using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static public Managers Instance;
    static public GameplayManager Gameplay;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }

    public void GameplaySignIn(GameplayManager manager)
    {
        Gameplay = manager;
    }
}
