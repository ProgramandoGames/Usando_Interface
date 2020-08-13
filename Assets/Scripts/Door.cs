using UnityEngine;

public class Door : MonoBehaviour, IInteractable {

    bool open = false;

    float angle = 0;
    float openAngle   = 90;
    float closedAngle = 0;
    float targetAngle = 0;

    float time = 80f;

    private void Update() {
        angle = Mathf.MoveTowards(angle, targetAngle, time * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    public void Interact() {
        OpenClose();
    }

    public void OpenClose() {
        if(open) {
            targetAngle = closedAngle;
            open = false;
        } else {
            targetAngle = openAngle;
            open = true;
        }
    }

}







