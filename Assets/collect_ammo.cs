using UnityEngine;

public class collect_ammo : MonoBehaviour
{
    int ammo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "AmmoBox"){
            ammo += 20;
            Debug.Log(ammo);
            other.gameObject.SetActive(false);
        }
    }

    void Shoot(){
        if (ammo <= 0){
            Debug.Log("No");
            return;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));

        RaycastHit result;
        bool hit = Physics.Raycast(ray, out result);
        ammo--;

        if (!hit){
            return;
        }

        Debug.Log(result.collider.gameObject);
        GameObject g = result.collider.gameObject;
        
        if (g.name == "Target"){
            Animation animation = g.transform.parent.GetComponent<Animation>();
            animation.Play("LowerBridge");
        } 

        
    }
}
