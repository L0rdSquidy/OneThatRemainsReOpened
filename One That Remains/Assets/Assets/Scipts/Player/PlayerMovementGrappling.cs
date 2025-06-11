using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Unity.VisualScripting;
// using System.Numerics;

public class PlayerMovementGrappling : MonoBehaviour
{
	[Header("Movement")]
	private bool buheheh;
	private float moveSpeed;
	public float walkSpeed;
	public float sprintSpeed;
	public float swingSpeed;
	
	public GameObject HitPOint;

	public Staminas stamina;

	public float groundDrag;

	[Header("Jumping")]
	public float MaxJumpHeight;
	float FullMaxJumpHeight;
	public float jumpForce;
	public float jumpCooldown;
	public float airMultiplier;
	public float FallingMultiplier = 0.1f;
	bool IsJumping;
	bool IsFalling;
	bool readyToJump;

	

	[Header("Keybinds")]
	public KeyCode jumpKey = KeyCode.Space;
	public KeyCode sprintKey = KeyCode.LeftShift;
	// public KeyCode crouchKey = KeyCode.LeftControl;

	[Header("Ground Check")]
	public float playerHeight;
	public LayerMask whatIsGround;
	public bool grounded;
	Vector3 lastGroundedPos;

	
	

	[Header("Camera Effects")]
	public PlayerCam cam;
	public float grappleFov = 95f;

	public Transform orientation;

	float horizontalInput;
	float verticalInput;

	Vector3 moveDirection;

	Rigidbody rb;

	private HP hpScript;

	public GameObject UI;
	

	public MovementState state;
	public enum MovementState
	{
		freeze,
		grappling,
		swinging,
		walking,
		sprinting,
		crouching,
		air
	}

	public bool freeze;

	public bool activeGrapple;
	public bool swinging;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		hpScript = FindObjectOfType<HP>();
		readyToJump = true;
		
		// startYScale = transform.localScale.y;
	}

	private void Update()
	{
		
		
		if(buheheh == true && state == MovementState.sprinting)
		{
			CameraShake.Shake(2f, 0.02f);
		}
		grounded = Physics.Raycast(transform.position, Vector3.down * 2, playerHeight * 0.5f + 0.2f, whatIsGround);

		
		Jump();
		MyInput();
		SpeedControl();
		StateHandler();

		if (grounded && !activeGrapple)
		{
			FullMaxJumpHeight = transform.position.y + MaxJumpHeight;
			lastGroundedPos = transform.position;
			rb.drag = groundDrag;
			IsFalling = false;
			// ResetJump();
		}
		else
			rb.drag = 1;

		if (!grounded){
		buheheh = false;
		HitPOint.SetActive(false);
		} 
		if (hpScript != null)
		{
			if(hpScript.returnHitcounter() == 1)
		{
			
		   
		   UI.SetActive(true); 

		   StartCoroutine(WaitForHitScreen());
		}
		
		}
		
	}

	IEnumerator WaitForHitScreen()
	{
		yield return new WaitForSeconds(0.9f);
		UI.SetActive(false);
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void MyInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");

		// when to jump
		if (Input.GetKey(jumpKey) && readyToJump && grounded)
		{
			readyToJump = false;
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			IsJumping = true;
			
		} 

	   
	}

	private void StateHandler()
	{
		// Mode - Freeze
		if (freeze)
		{
			state = MovementState.freeze;
			moveSpeed = 0;
			rb.velocity = Vector3.zero;
		}

		// Mode - Grappling
		else if (activeGrapple)
		{
			state = MovementState.grappling;
			moveSpeed = sprintSpeed;
		}

		// Mode - Swinging
		else if (swinging)
		{
			state = MovementState.swinging;
			moveSpeed = swingSpeed;
			rb.drag = 0;
			
		}

		
		else if (grounded && Input.GetKey(sprintKey))
		{
			HitPOint.SetActive(false);
			
			state = MovementState.sprinting;
			moveSpeed = sprintSpeed;
			
			 Debug.Log(stamina.StaminaDeplete());

			if (moveSpeed == sprintSpeed && Stamina.instance != null)
			{
				 Staminas.instance.UseStamina(1);
			}
			if (stamina.StaminaDeplete() <= 1)
			{   
				moveSpeed = walkSpeed;
				
			}

		}
		else if (grounded)
		{
			HitPOint.SetActive(true);
			state = MovementState.walking;
			moveSpeed = walkSpeed;
		}

		// Mode - Air
		else
		{
			state = MovementState.air;
		}
	}

	private void MovePlayer()
	{
		if (activeGrapple) return;
		if (swinging) return;

		// calculate movement direction
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
		
		// on ground
		if (grounded)
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

		// in air
		else if (!grounded)
			if (!IsJumping)
			{
				IsFalling = true;
			}
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

		
	}

	private void SpeedControl()
	{
		if (activeGrapple) return;
		

		// limiting speed on ground or in air
		else
		{
			Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

			// limit velocity if needed
			if (flatVel.magnitude > moveSpeed)
			{
				Vector3 limitedVel = flatVel.normalized * moveSpeed;
				rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
			}
		}
	}

	private void Jump()
	{
		float JumpPercentages =  ((transform.position.y - lastGroundedPos.y)/(FullMaxJumpHeight-lastGroundedPos.y)) * 100;
		// Debug.Log("JP%" + JumpPercentages);
		// reset y velocity
		if (IsJumping && !readyToJump)
		{
			if (JumpPercentages < 50)
			{
				rb.velocity = new Vector3(rb.velocity.x, jumpForce + 0.1f, rb.velocity.z);
			} else if (JumpPercentages >= 50 && JumpPercentages < 90)
			{
				float jumpProgress = Mathf.Clamp01((JumpPercentages - 50) / 50f); 
				float reducedJumpForce = Mathf.SmoothStep(jumpForce, 0, jumpProgress);
				rb.velocity = new Vector3(rb.velocity.x, reducedJumpForce, rb.velocity.z);
			} else if (JumpPercentages > 90 && !grounded)
			{
				
				IsJumping = false;
				IsFalling = true;
				
			} else
			{
				IsFalling = false;
				IsJumping = false;
				
			}
		}
		
		if (IsFalling)
		{
			ResetJump();
			rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - FallingMultiplier, rb.velocity.z);
		}
		

	}
	private void ResetJump()
	{
		readyToJump = true;
	}

	private bool enableMovementOnNextTouch;
	public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
	{
		activeGrapple = true;

		velocityToSet = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
		Invoke(nameof(SetVelocity), 0.01f);

		Invoke(nameof(ResetRestrictions), 3f);
	}

	private Vector3 velocityToSet;
	private void SetVelocity()
	{
		enableMovementOnNextTouch = true;
		rb.velocity = velocityToSet;

		cam.DoFov(grappleFov);
	}

	public void ResetRestrictions()
	{
		activeGrapple = false;
		cam.DoFov(85f);
	}

	private void OnCollisionEnter(Collision collision)
	{
		IsJumping = false;
		IsFalling = true;
		
		if (enableMovementOnNextTouch)
		{
			enableMovementOnNextTouch = false;
			ResetRestrictions();

			// GetComponent<DualHooks>().CancelActiveGrapples();
		}
		if (collision.gameObject.CompareTag("Wotah"))
		{
			buheheh = true;
		} 
	}

	

	public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
	{
		float gravity = Physics.gravity.y * 6;
		float displacementY = endPoint.y - startPoint.y;
		Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
		Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity) 
			+ Mathf.Sqrt(4 * (displacementY - trajectoryHeight) / gravity));
		return velocityXZ + velocityY;
	}


	public static float Round(float value, int digits)
	{
		float mult = Mathf.Pow(10.0f, (float)digits);
		return Mathf.Round(value * mult) / mult;
	}

	public float returnSpeed(){
		return moveSpeed;
	}

	public float returnWalkSpeed(){
		return walkSpeed;
	}

	public float returnsprintSpeed(){
		return sprintSpeed;
	}

   
}
