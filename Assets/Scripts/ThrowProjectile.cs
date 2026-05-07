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

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sonidoDisparo;
    [Range(0f, 5f)] 
    public float volumenDisparo = 3f; 
    private float nextTimeToFire = 0f;
    [Header("Animación")]
    public Animator cañonAnimator;

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

        if (audioSource != null && sonidoDisparo != null)
        {
            audioSource.PlayOneShot(sonidoDisparo, volumenDisparo);
        }

        if (cañonAnimator != null)
        {
            cañonAnimator.SetTrigger("Disparar");
        }
    }
}