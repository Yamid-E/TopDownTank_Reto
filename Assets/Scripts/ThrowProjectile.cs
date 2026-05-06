using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public Rigidbody projectilePrefab;
    public Transform throwPoint;
    public float launchForce = 15f;

    [Header("Fire Rate")]
    public float timeBetweenShots = 0.5f;

    [Header("VFX")]
    public ParticleSystem muzzleFlash; 

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            ThrowProjectile1();
            nextTimeToFire = Time.time + timeBetweenShots;
        }
    }

    private void ThrowProjectile1()
    {
        if (projectilePrefab == null || throwPoint == null)
        {
            Debug.LogWarning("ProjectileThrower: Assign 'projectilePrefab' and 'throwPoint' in the Inspector.");
            return;
        }

        // Activamos el destello justo antes o después de instanciar la bala
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        Rigidbody projInstance = Instantiate(
            projectilePrefab,
            throwPoint.position,
            throwPoint.rotation
        );

        projInstance.velocity = throwPoint.forward * launchForce;
    }
}