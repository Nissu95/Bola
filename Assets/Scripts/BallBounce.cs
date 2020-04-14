using System.Collections;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] float bounceDelay;
    [SerializeField] string bounceAnimationTrigger = "Bounce";

    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;

    Rigidbody rigidbody;
    private Vector3 _velocity;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    bool jumping = false;

    float radius;
    Animator animator;

    bool raycastActive = true;

    private void Awake()
    {
        //_controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();

        animator = GetComponentInChildren<Animator>();

        _groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        float horizontal = InputManager.singleton.GetHorizontalInputs();

        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);

        Vector3 move = new Vector3(horizontal, 0, 0);

        rigidbody.velocity += move * Time.deltaTime * Speed;

        //_controller.Move(move * Time.deltaTime * Speed);

       // _velocity.y += Gravity * Time.deltaTime;

        //_controller.Move(_velocity * Time.deltaTime);


    }

    void Bounce()
    {
        rigidbody.AddForce(0, 10, 0,ForceMode.Impulse);
        jumping = false;
    }

    IEnumerator Countdown(float seconds)
    {
        float counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(0.1f);
            counter -= 0.1f;
        }
        Bounce();
    }

    private void OnTriggerEnter(Collider other)
    {

        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

            animator.SetTrigger(bounceAnimationTrigger);

            Invoke("Bounce", bounceDelay);
    }
}
