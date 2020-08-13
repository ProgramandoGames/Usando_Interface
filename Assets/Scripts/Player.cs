using UnityEngine;

public class Player : MonoBehaviour {

    private new Camera camera;

    CharacterController controller;

    #region MOVE_PROPERTIES

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    float forwardSpeed = 3f;
    float strafeSpeed = 3f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;

    #endregion

    float distanceToInteract = 4f;

    void Start() {

        camera = Camera.main;

        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

    }

    void Update() {

        Interact();
        Move();

    }

    void Interact() {

        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, distanceToInteract, LayerMask.GetMask("Interactable"))) {

                IInteractable obj = hitInfo.transform.GetComponent<IInteractable>();

                if (obj == null) return;

                obj.Interact();

            }
        }
    }

    void Move() {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        // force = input * speed * direction
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded) {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0) {
            vertical = Vector3.zero;
        }

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }

}
