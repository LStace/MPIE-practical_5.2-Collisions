using UnityEngine;

public class door : MonoBehaviour
{
    Animation animation;
    AudioSource DoorSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject parent = transform.parent.gameObject;
        animation = parent.GetComponent<Animation>();
        DoorSFX = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        animation.Play("OpenDoor");
        DoorSFX.Play();
    }

    void OnTriggerExit(Collider other){
        animation.Play("Close");
        DoorSFX.Play();
    }
}
