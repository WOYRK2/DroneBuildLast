using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    [SerializeField] private float _speed;
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
        bool _isMoved =  Input.GetKey(KeyCode.A) || 
                     Input.GetKey(KeyCode.D) || 
                     Input.GetKey(KeyCode.W) || 
                     Input.GetKey(KeyCode.S);
        
        _AudioSource.mute = !_isMoved;

        if (Input.GetKey(KeyCode.LeftShift) && !_isRun) 
        {
            _isRun = true;
            _speed *= 2.5f;
        }
        
        if (!Input.GetKey(KeyCode.LeftShift) && _isRun) 
        {
            _isRun = false;
            _speed /= 2.5f;
        }

        // a || d
        if (Input.GetKey(KeyCode.A))
        {
            _SpriteRenderer.flipX = true;
            _Rigidbody2D.AddForce(new Vector2(-_speed * Time.fixedDeltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            _SpriteRenderer.flipX = false;
            _Rigidbody2D.AddForce(new Vector2(_speed * Time.fixedDeltaTime, 0f));
        }

        // w || s
        if (Input.GetKey(KeyCode.W))
            _Rigidbody2D.AddForce(new Vector2(0f, _speed * Time.fixedDeltaTime));
        if (Input.GetKey(KeyCode.S))
            _Rigidbody2D.AddForce(new Vector2(0f, -_speed * Time.fixedDeltaTime));
    }
}
