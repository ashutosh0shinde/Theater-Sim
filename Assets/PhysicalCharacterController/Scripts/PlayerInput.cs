using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public float speed = 5;
	public float sprintSpeed = 8;
	float finalSpeed;
	public bool canRun;

	public PhysicalCC physicalCC;

	public LayerMask stairLayerMask;

	public Transform cameraTransform; // Reference to the camera's transform

	public float cameraBobOffset; // Current offset for camera bobbing
	public float cameraBobSpeed = 9f; // Speed of the camera bobbing effect
	public float cameraBobAmount = 0.05f; // Amount of camera bobbing

	public bool bobbingEnabled = true;

	[Space]
	[Header("Scripts")]


	[Space]
	public AudioSource stoneSolidWalk;
	public AudioSource stoneSolidRun;
	public AudioSource grassWalk;
	public AudioSource grassRun;

	public bool isRunning = false;
	public bool stepSoundEnabled;

	private void Start()
	{
		finalSpeed = speed;
	}

	void Update()
	{
		if (physicalCC.isGround)
		{
			physicalCC.moveInput = Vector3.ClampMagnitude(transform.forward
							* Input.GetAxis("Vertical")
							+ transform.right
							* Input.GetAxis("Horizontal"), 1f) * finalSpeed;
		}
		ApplyCameraBobbing();

		//  Check If Running Or Walking
		if (canRun == true)
		{
			if (Input.GetKeyDown(KeyCode.LeftShift)) { isRunning = true; finalSpeed = sprintSpeed; cameraBobSpeed = 14; }
			if (Input.GetKeyUp(KeyCode.LeftShift)) { isRunning = false; finalSpeed = speed; cameraBobSpeed = 9; }
		}

		void ApplyCameraBobbing()
		{
			if (bobbingEnabled)
			{
				// Calculate the camera bob offset based on player's movement
				float horizontalMovement = Mathf.Abs(Input.GetAxis("Horizontal"));
				float verticalMovement = Mathf.Abs(Input.GetAxis("Vertical"));
				float bobFactor = Mathf.Clamp01(Mathf.Max(horizontalMovement, verticalMovement));
				float targetCameraBobOffset = Mathf.Sin(Time.time * cameraBobSpeed) * bobFactor * cameraBobAmount;

				// Set the default camera bob offset value
				float defaultCameraBobOffset = 0.8f; // Adjust this value as per your desired default camera position

				// Calculate the final camera bob offset
				float finalCameraBobOffset = bobFactor > 0 ? targetCameraBobOffset + defaultCameraBobOffset : defaultCameraBobOffset;

				// Apply the camera bob offset to the camera's position
				Vector3 cameraPosition = cameraTransform.localPosition;
				cameraPosition.y = finalCameraBobOffset;
				cameraTransform.localPosition = cameraPosition;
			}
		}
	}
}



