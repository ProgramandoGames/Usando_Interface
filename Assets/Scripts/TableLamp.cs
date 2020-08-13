using UnityEngine;

public class TableLamp : MonoBehaviour, IInteractable {

    private new Light light;

    bool ligthUp            = true;
    float currentIntensity  = 0;
    float lightUpIntensity  = 3;
    float lightOffIntensity = 0;
    float time              = 50;

    private void Start() {
        light = GetComponentInChildren<Light>();
    }

    void Update() {
        light.intensity = Mathf.MoveTowards(light.intensity, currentIntensity, time * Time.deltaTime);
    }

    public void Interact() {
        LightUp();
    }

    public void LightUp() {

        if(ligthUp) {
            currentIntensity = lightOffIntensity;
            ligthUp = false;
        } else {
            currentIntensity = lightUpIntensity;
            ligthUp = true;
        }

    }
    
}
