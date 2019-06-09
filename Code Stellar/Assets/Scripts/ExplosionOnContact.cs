using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnContact : MonoBehaviour {
    public GameObject explosion;
    public float positionZ;
    void OnTriggerEnter(Collider other)
    {
        //Instantiate(explosion, transform.position + new Vector3(0,0,positionZ), Quaternion.identity);
        Destroy(gameObject);
    }
}
