using UnityEngine;

public class Food : MonoBehaviour, IInteractable {

    public void Interact() {
        Eat();
    }

    public void Eat() {
        Destroy(gameObject);
    }

}
