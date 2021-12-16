using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
    Animator animator;
    public bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(jumping) {
                animator.SetTrigger("Landed");
                jumping = false;
            } else {
                animator.SetTrigger("Jump");
                jumping = true;
            }
        }
    }
}
