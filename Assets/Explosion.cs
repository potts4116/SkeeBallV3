using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject Grenade;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
        if (Grenade == enabled)
        {
            Invoke("Detonate", 5);
        }
	}

    void Detonate()
    {
        Vector3 explosionPosition = Grenade.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
        Invoke("Destroy", 5);
        
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
