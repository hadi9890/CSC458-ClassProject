using _Scripts;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private PlayerMovement _playerMovement;

    [Header("Jump Variables")]
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private float maxJumpCount = 1;
    [SerializeField] private float jumpCooldown = 0.1f;
    private float _jumpCooldownTimer, _currJump;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_jumpCooldownTimer > 0)
        {
            _jumpCooldownTimer -= Time.deltaTime;
        }
        
        if (_playerMovement.isGrounded && !Input.GetButton("Jump"))
        {
            _currJump = 0;
        }

        if (_jumpCooldownTimer <= 0)
        {
            if (Input.GetButtonDown("Jump") && _currJump < maxJumpCount)
            {
                Jump();
                _jumpCooldownTimer = jumpCooldown;
            }
        }
    }

    private void Jump()
    {
        _currJump++;
        _rb.velocity = new Vector2(_rb.velocity.x, jumpPower);
    }
}





