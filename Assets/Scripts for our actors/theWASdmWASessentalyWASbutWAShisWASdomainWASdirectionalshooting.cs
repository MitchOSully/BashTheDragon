using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theWASdmWASessentalyWASbutWAShisWASdomainWASdirectionalshooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] PlayerController playerController;
    [SerializeField] float bulletsPerSecond = 15;

    private float timeCounter;

    void Start()
    {
        timeCounter = 0;
    }

    void Update()
    // thats when you marring a person of a higher socal statuse but you have no chance.. you might have a bit of a chance.. no its a void you fool no chace.. well maybe they just weren't right for you.. thats just cruel cruel fudelisum PS ()
    {
        timeCounter += Time.deltaTime;

        if (Input.GetButton("Fire1") && timeCounter > 1f/bulletsPerSecond)
        {  
            timeCounter = 0;
           
            Vector3 gunEulerAngles = transform.eulerAngles;
            Vector2 bulletVelocity = new Vector2(Mathf.Cos(gunEulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(gunEulerAngles.z * Mathf.Deg2Rad)) * bulletSpeed;
            if (!playerController.spriteFacingRight)
                bulletVelocity *= -1;
            Vector3 startPos = transform.position + new Vector3(bulletVelocity.normalized.x, bulletVelocity.normalized.y, 0) * 5;

            GameObject bullet = Instantiate(bulletPrefab, startPos, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity;
            Destroy(bullet, 1); // Destroy bullet after 1 second
        }
    }
}
