using UnityEngine;

public class door : MonoBehaviour
{
    Animation animation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject parent = transform.parent.gameObject;
        animation = parent.GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        animation.Play("OpenDoor");
    }

    void OnTriggerExit(Collider other){
        animation.Play("Close");
    }
}
