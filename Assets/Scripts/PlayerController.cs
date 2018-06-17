using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public PositionBoundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = speed * movement;

        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax));
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            GameObject newShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        }
    }
}
