using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerModel;
    [SerializeField] private InputReader inputReader;
    [Range(0.01f, .1f)]
    [SerializeField] private float rotationSpeed = 1f;

    private Vector2 move;

    private void OnEnable()
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
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        float horizontal = move.x;
        float vertical = move.y;
        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;
        if (moveDirection != Vector3.zero)
        {
            playerModel.forward = Vector3.Slerp(playerModel.forward, moveDirection, rotationSpeed);
        }
    }
}
