using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class MovementAnimator : MonoBehaviour
{
    private const string WALKING_PARAMETER_NAME = "walking";
    private Animator animator;
    private new Rigidbody2D rigidbody2D;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        animator.SetBool(WALKING_PARAMETER_NAME, rigidbody2D.velocity == Vector2.zero);
    }
}
