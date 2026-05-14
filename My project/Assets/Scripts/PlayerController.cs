using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 5f;
    public ParticleSystem destructionParticle;
    private CinemachineImpulseSource _impulseSource;

    private Vector2 movementInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y) * speed;
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(destructionParticle, transform.position, Quaternion.identity);
            _impulseSource.GenerateImpulse();
            Destroy(gameObject);
        }

    }
}
