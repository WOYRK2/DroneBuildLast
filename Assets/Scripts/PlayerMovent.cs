using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    private SpriteRenderer _SpriteRenderer;
    private AudioSource _AudioSource;
    private Rigidbody2D _Rigidbody2D;
    private bool _isRun = false;

    void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _AudioSource = GetComponent<AudioSource>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();

        _AudioSource.mute = true;
    }

    void FixedUpdate()
    {
        MOVEPLR();
    }

    private void MOVEPLR()
    {
        float MoveX =  Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        bool _isMoved =  MoveX != 0 || MoveY != 0;
        
        _AudioSource.mute = !_isMoved;

        if (Input.GetKey(KeyCode.LeftShift) && !_isRun) 
        {
            _isRun = true;
            _speed *= _runSpeed;
        }
        
        if (!Input.GetKey(KeyCode.LeftShift) && _isRun) 
        {
            _isRun = false;
            _speed /= _runSpeed;
        }

        // a || d
        if (Input.GetKey(KeyCode.A))
        {
            _SpriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _SpriteRenderer.flipX = false;
        }
        
        Vector2 PowerMove = new Vector2(MoveX, MoveY).normalized;
        _Rigidbody2D.MovePosition(_Rigidbody2D.position + PowerMove * _speed * Time.fixedDeltaTime);
    }
}
