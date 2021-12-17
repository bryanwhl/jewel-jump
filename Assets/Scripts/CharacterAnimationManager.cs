using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ready() {
        animator.SetTrigger("Ready");
        animator.ResetTrigger("Jump");
        animator.ResetTrigger("Landed");
    }

    public void Jump() {
        animator.SetTrigger("Jump");
        animator.ResetTrigger("Landed");
    }

    public void Land() {
        animator.SetTrigger("Landed");
    }
}
