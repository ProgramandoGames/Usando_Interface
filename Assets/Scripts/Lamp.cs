using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable {

    float movementEnergy = 0;
    float currentAngle   = 0;
    float moveSpeed      = 2;
    float stopSpeed      = 1;
    float time           = 0;

    void Update() {

        movementEnergy = Mathf.MoveTowards(movementEnergy, 0, stopSpeed * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(time) * movementEnergy);

        time += moveSpeed * Time.deltaTime;

    }

    public void Interact() {
        Move();
    }

    public void Move() {
        movementEnergy = 15;
        time           = 0;
    }
 


}
