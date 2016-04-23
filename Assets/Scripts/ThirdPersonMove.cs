using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThirdPersonMove : MonoBehaviour
{

    // Original gravity was -9.81

    public float speed;
    public float mouseSpeedX;

    Rigidbody rigidbody;
    public Transform anchor;

    public bool canJump = true;
    public float jumpForce;

    public bool canRun = true;
    public float runSpeed;
    bool running;
    public bool jumping;

//	public bool frozen;
    
    Vector3 defaultFollowCamPos;
	Vector3 defaultOverheadCamPos;
    public GameObject camera;
    public float cameraCorrectSpeed = 2.5f;

    public Animator anim;

	public bool cameraIsOverhead = false;

	GameObject targetCircle;

    void Start()
    {
//		stamina = charMaxStamina;
//		charTempStamina = charMaxStamina;
        rigidbody = GetComponent<Rigidbody>();
        defaultFollowCamPos = new Vector3(0, 2, -5);
		defaultOverheadCamPos = new Vector3 (0, 15f, 0);
//		proj = GetComponentInChildren<Projector> ();
//		proj.enabled = true;
//		proj.orthographicSize = stamina / 25f;

    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        if (Mathf.Abs(mouseX) > 0) transform.Rotate(new Vector3(transform.rotation.x, (mouseX * mouseSpeedX), transform.rotation.z));

        float mouseY = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(mouseY) > 0) anchor.transform.Rotate(new Vector3(anchor.transform.rotation.x - (mouseY * mouseSpeedX), 0, 0));

        // [TO-DO] More camera overhead stuff...
		if (!cameraIsOverhead) anchor.transform.eulerAngles = new Vector3(ClampAngle(anchor.transform.eulerAngles.x, -30f, 60f), anchor.transform.eulerAngles.y, 0);

        RaycastHit hit;
        LayerMask layerMask = (1 << 8) | (1 << 9);                            // LayerMask for "Obstacles" and "Ground" -- Make sure these don't change!

        Vector3 dir = camera.transform.position - transform.position;

        // [TO-DO] More camera overhead stuff...
		if (!cameraIsOverhead) {
			if (Physics.Raycast (transform.position, dir, out hit, 5f, layerMask.value)) {     // [TO-DO] Landing on distance of 5f kinda randomly here.  Test this.
				camera.transform.position = hit.point;
			} else {
				//camera.transform.localPosition = defaultFollowCamPos;        // [TO-DO] Make these much less hard-coded.
				camera.transform.localPosition = Vector3.Lerp (camera.transform.localPosition, defaultFollowCamPos, Time.deltaTime * cameraCorrectSpeed);    // Lerp back toward target spot
			}
		} else {
			defaultOverheadCamPos = new Vector3 (0, 4f, -15f);
			anchor.transform.eulerAngles = new Vector3(ClampAngle(anchor.transform.eulerAngles.x, 30f, 80f), anchor.transform.eulerAngles.y, 0);
			camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, defaultOverheadCamPos, Time.deltaTime * cameraCorrectSpeed);    // Lerp back toward target spot
		}
        
        if (canJump)    // [TO-DO] We'll eventually know whether or not we're allowing running/jumping, so this check can be removed.
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            if (Input.GetButtonDown("Jump"))
            {
//				if (stamina > 0) {	// [TO-DO] Remove all stamina stuff
					// 1.1f helps with colliding with steep ramps below character collider
					if (Physics.Raycast (transform.position, Vector3.down, out hit, 1.1f, layerMask.value)) {
						//Debug.Log ("Jumping off of: " + hit.collider.name);
						rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 0, rigidbody.velocity.z);
						rigidbody.AddRelativeForce (Vector3.up * jumpForce);
						anim.SetTrigger ("Jump");
						jumping = true;
					}
//				}
            }
        }

        if (canRun)     // [TO-DO] We'll eventually know whether or not we're allowing running/jumping, so this check can be removed.
        { 
            if (Input.GetKey(KeyCode.LeftShift))
            {
                running = true;
            }
            else
            {
                running = false;
            }
        }

        if (jumping)
        {
            if (rigidbody.velocity.y < 0)
            {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.05f, layerMask.value))
                {
                    //Debug.Log("Ground collision with: " + hit.collider.name);
                    anim.SetTrigger("Grounded");
                    jumping = false;
                }
            }
        }

        // [TO-DO] Remove or implement overhead camera transitions here
//		if (Input.GetButtonUp ("Zoom")) {
		if (Input.GetKeyUp(KeyCode.Z)) {
			cameraIsOverhead = !cameraIsOverhead;
		}

    }

    void FixedUpdate()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        float strafe = Input.GetAxis("Horizontal");
        float walkRun = Input.GetAxis("Vertical");

        anim.SetFloat("Velocity", walkRun);
        anim.SetFloat("Direction", strafe);

        anim.SetBool("Running", running);

        //Debug.Log("Raw: x" + moveX + " / y" + moveY + " | Strafe: " + strafe + " | WalkRun: " + walkRun);

        float tempSpeed = (running) ? runSpeed : speed;

        Vector3 moveDir = (transform.forward * tempSpeed * moveY) + (transform.right * tempSpeed * moveX);
        moveDir.Normalize();

//        if (stamina > 0) {
//            if (moveDir.magnitude > 0) {
//                gameObject.GetComponent<CapsuleCollider>().material = (PhysicMaterial) Resources.Load("PhysicsMaterials/ZeroFriction");
//            } else {
//                gameObject.GetComponent<CapsuleCollider>().material = (PhysicMaterial) Resources.Load("PhysicsMaterials/Friction");
//            }
//        }

        //Debug.Log(moveDir.magnitude);
//		if (!frozen) 
		// [TO-DO] Check animation stuff here
		anim.SetFloat("Magnitude", moveDir.magnitude);

        Vector3 moveVelocity = moveDir * tempSpeed;

		// Uncomment below if no stamina system
		rigidbody.velocity = new Vector3 (moveVelocity.x, rigidbody.velocity.y, moveVelocity.z);

        anim.SetFloat("Gravity", rigidbody.velocity.y);

    }

    float ClampAngle(float angle, float min, float max)
    {

        if (angle < 90 || angle > 270)
        {       // if angle in the critic region...
            if (angle > 180) angle -= 360;  // convert all angles to -180..+180
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }
        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0) angle += 360;  // if angle negative, convert to 0..360
        return angle;
    }

}
