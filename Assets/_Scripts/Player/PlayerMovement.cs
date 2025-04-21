using UnityEngine;

namespace _Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Components")]
        [HideInInspector] public Rigidbody2D rb;
        [HideInInspector] public Animator anim;
    
        [Space(10), Header("Variables/Walk-Run")]
        [HideInInspector] public float moveHorizontal;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float sprintSpeed;
        private float _currSpeed;
        private bool _isSprinting;
    
        [Space(5), Header("Ground Check")]
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;
        public LayerMask groundLayer;
        public bool isGrounded;

        #region Anim Hashes
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsSprinting = Animator.StringToHash("IsSprinting");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");

        #endregion

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            _isSprinting = Input.GetKey(KeyCode.LeftShift);
        
            // Draw a circle at the groundCheck position. Return true if overlaps with groundLayer
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
            // Check if player sprite needs rotation
            FlipCharacter();
            
            anim.SetBool(IsGrounded, isGrounded);
            anim.SetFloat(Speed, Mathf.Abs(rb.velocity.x));
            anim.SetBool(IsSprinting, _isSprinting);
        }

        private void FixedUpdate()
        {
            _currSpeed = _isSprinting ? sprintSpeed : walkSpeed;
            rb.velocity = new Vector2(moveHorizontal * _currSpeed, rb.velocity.y);
        }

        private void FlipCharacter()
        {
            var characterScale = transform.localScale;

            if (moveHorizontal < 0)
            {
                characterScale.x = -Mathf.Abs(transform.localScale.x);
            }
            else if (moveHorizontal > 0)
            {
                characterScale.x = Mathf.Abs(transform.localScale.x);
            }
        
            transform.localScale = characterScale;
        }
    }
}
