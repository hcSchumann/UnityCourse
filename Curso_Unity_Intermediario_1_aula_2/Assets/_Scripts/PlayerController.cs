using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Utility;

public class PlayerController : NetworkBehaviour {
    private readonly float rotationSpeed = 300f;
    private readonly float translationSpeed = 6f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Use this for initialization
    void Start () {
		
	}

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        Camera.main.GetComponent<SmoothFollow>().target = transform;
    }

    [Command]
    void CmdFire()
    {

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation
            );

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }


    // Update is called once per frame
    void Update() {
        if (isLocalPlayer)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * translationSpeed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                CmdFire();
                CmdFire();
                CmdFire();
                CmdFire();
                CmdFire();
            }
        }
	}
}
