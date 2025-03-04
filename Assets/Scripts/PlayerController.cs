using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0.01f, 10f)]
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private Transform Orientation;
    [SerializeField] private InputReader inputReader;

    [SerializeField] private Animator animator;

    private Vector3 velocity;
    private Vector2 move;
    private CharacterController controller;

    void OnEnable()
    {
        inputReader.MoveEvent += OnMove;
    }
    void OnDisable()
    {
        inputReader.MoveEvent -= OnMove;
    }
    void OnMove(Vector2 moveInput)
    {
        move = moveInput;
    }
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = transform.Find("GFX")?.GetComponentInChildren<Animator>();
    }
    void Update()
    {
        MovePlayer();
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Animation
        animator.SetFloat("Move", move.magnitude);
    }
    void MovePlayer()
    {
        Vector3 moveDirection = Orientation.forward * move.y + Orientation.right * move.x;
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
