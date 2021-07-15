using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnimator;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void SetPlayerState(int playerState)
    {
       playerAnimator.SetInteger("transition",playerState);
    }
}
