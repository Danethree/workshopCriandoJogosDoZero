using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{

    public float transitionTime;
    void Start()
    {
        
    }

  
    void Update()
    {
        Invoke("TransitionScene",transitionTime);
    }

    void TransitionScene()
    {
        SceneManager.LoadScene("Intro");
    }
}
