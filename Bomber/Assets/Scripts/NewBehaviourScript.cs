using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	/// This script moves the character controller forward   
/// and sideways based on the arrow keys.  
/// It also jumps when pressing space.  
/// Make sure to attach a character controller to the same game object.  
/// It is recommended that you make only one call to Move or SimpleMove per frame.      
  
float speed = 6.0f;  
float jumpSpeed = 8.0f;  
float gravity = 20.0f;  
  
private Vector3 moveDirection = Vector3.zero;  
  
    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {  
            // We are grounded, so recalculate  
            // move direction directly from axes  
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,  
                                    Input.GetAxis("Vertical"));   
            // 这里获取了键盘的前后左右的移动，但注意，这是相对于自己的。  
            moveDirection = transform.TransformDirection(moveDirection);   
            // 还有一个TransformPoint。这里是把相对于自己的  
            // 坐标转换为相对于世界的坐标。  
            moveDirection *= speed;  
          
            if (Input.GetButton ("Jump")) {  
                moveDirection.y = jumpSpeed;  
            }  
        }  
  
        // Apply gravity  
        moveDirection.y -= gravity * Time.deltaTime;  
      
        // Move the controller  
        controller.Move(moveDirection * Time.deltaTime);  
    }  
}
