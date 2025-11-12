using UnityEngine;

public class collect_ammo : MonoBehaviour
{
    public AudioClip GunEmptySFX;
    public AudioClip GunShotSFX;
    public AudioClip AmmoSFX;
    public AudioClip GunReloadSFX;
    int ammo = 0;
    AudioSource GunSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GunSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
            Reload();
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "AmmoBox"){
            ammo += 20;
            Debug.Log(ammo);
            other.gameObject.SetActive(false);
            GunSFX.clip = AmmoSFX;
            GunSFX.Play();
        }
    }

    void Shoot(){
        if (ammo <= 0){
            Debug.Log("no");
            GunSFX.clip = GunEmptySFX;
            GunSFX.Play();
            return;
        }
        GunSFX.clip = GunShotSFX;
        GunSFX.Play();

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
            AudioSource loweringSFX = g.transform.parent.GetComponent<AudioSource>();
            loweringSFX.Play();
        } 
    }

    void Reload(){
        if (ammo == 0){
            return;
        }
        yield return new WaitForSecondsRealTime(2);
        GunSFX.clip = GunReloadSFX;
        GunSFX.Play();
    }
}
