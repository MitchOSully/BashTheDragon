using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] float m_bulletSpeed = 10;
    [SerializeField] GameObject m_gunGFX;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 vBulletStartPos = transform.position;
            SpriteRenderer sr = m_gunGFX.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                vBulletStartPos += new Vector2(sr.bounds.extents.x, 0);
            }

            Vector3 gunEulerAngles = transform.eulerAngles;
            Vector2 vBulletVel = new Vector2(m_bulletSpeed * Mathf.Cos(gunEulerAngles.z * Mathf.Deg2Rad), m_bulletSpeed * Mathf.Sin(gunEulerAngles.z * Mathf.Deg2Rad));

            GameObject bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = vBulletVel;
            Destroy(bullet, 1); // Destroy created bullet prefab after 1 second
        }
    }

    public void OnDrawGizmosSelected()
    {
        SpriteRenderer sr = m_gunGFX.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            var bounds = sr.bounds;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
}
