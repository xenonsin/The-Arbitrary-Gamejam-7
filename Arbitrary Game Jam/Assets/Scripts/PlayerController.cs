using UnityEngine;
using System.Collections;


public class PlayerController: MonoBehaviour
{
	// movement config
	public float gravity = -15.0f;
	public float runSpeed = 4.0f;
	public float groundDamping = 20.0f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5.0f;
	public float jumpHeight = 2.0f;
    public float dashSpeed = 1.0f;
    public float dashCoolDown = 1.0f;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;

    private float jumpCount = 0;
    private bool jumped;
    //private bool push = false;

    private float timeStamp = 0.0f;

    public AudioClip Jump;
    public AudioClip Dash;

	void Awake()
	{
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();
		_controller.onControllerCollidedEvent += onControllerCollider;
	}


	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );

  
	}


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{

        if (!Die.isAlive)
        {
            //play death animation
        }
		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;

		if( _controller.isGrounded )
        {
            jumpCount = 0;
			_velocity.y = 0;
            jumped = false;
            _animator.Play(Animator.StringToHash("Running"));
        }
/*
        //Left and Right Movement
        if (Input.GetAxis("Horizontal") < 0)
		{
            //Checks if facing right. If so, flip sprite.
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

			//if( _controller.isGrounded )
				//_animator.Play(Animator.StringToHash( "Walk" ) );
		}
        else if (Input.GetAxis("Horizontal") > 0)
		{
            //Checks if facing left. If so, flip sprite.
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

			//if( _controller.isGrounded )
				//_animator.Play( Animator.StringToHash( "Walk" ) );
		}
		else
		{

			//if( _controller.isGrounded )
				//_animator.Play( Animator.StringToHash( "Idle" ) );
		}
*/

		// we can only jump whilst grounded
        if (_controller.isGrounded && Input.GetKeyDown("w") && Die.isAlive)
		{
            jumpCount++;
            _velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity );
            jumped = true;

			_animator.Play( Animator.StringToHash( "Jumping" ) );
            audio.PlayOneShot(Jump);
		}

        //short hop
        if (!_controller.isGrounded && Input.GetKeyUp("w") && jumped)
        {
            _velocity.y /= 2;
            jumped = false;
        }

        //Dash 

        if (Input.GetKeyDown("d") && Die.isAlive)
        {
            if (Time.time > timeStamp)
            {
                timeStamp = Time.time + dashCoolDown;

                _animator.Play(Animator.StringToHash("Dash"));

                audio.PlayOneShot(Dash);

                _controller.move(new Vector2(dashSpeed, 0));
 
            }

           
 
        }


        //Fast Fall
        if (!_controller.isGrounded && Input.GetAxis("Vertical") < 0)
        {
            _velocity.y = -Mathf.Sqrt(2f * jumpHeight * -gravity);
        }

		// apply horizontal speed smoothing it
        float smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
        //_velocity.x = Mathf.Lerp(_velocity.x, Input.GetAxis("Horizontal") * runSpeed, Time.deltaTime * smoothedMovementFactor);


        if (Die.isAlive)
            _velocity.x = Mathf.Lerp(_velocity.x, runSpeed, Time.deltaTime);
        else
            _velocity.x = .01f;

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

        
		_controller.move( _velocity * Time.deltaTime );

        //push = Physics2D.OverlapCircle(transform.localPosition, .4f, 1 << LayerMask.NameToLayer("Moveable"));

        /*if(push && _controller.isGrounded)
        {
            _animator.Play(Animator.StringToHash("Push"));
        }*/
        
        
    }

}


    
