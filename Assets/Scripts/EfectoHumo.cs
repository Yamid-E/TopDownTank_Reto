using UnityEngine;

public class EfectoHumo : MonoBehaviour
{
    private ParticleSystem _particulas;
    private ParticleSystem.EmissionModule _emision;
    
    [Header("Configuración")]
    public Rigidbody tanqueRB; 
    public float humoQuieto = 5f;
    public float humoMoviendo = 40f;

    void Start()
    {
        _particulas = GetComponent<ParticleSystem>();
        _emision = _particulas.emission;
    }

    void Update()
    {
        // Medimos la velocidad actual del tanque
        float velocidad = tanqueRB.velocity.magnitude;

        // Si la velocidad es mayor a un umbral pequeño, aumentamos el humo
        if (velocidad > 0.1f)
        {
            _emision.rateOverTime = humoMoviendo;
        }
        else
        {
            _emision.rateOverTime = humoQuieto;
        }
    }
}