using UnityEngine;

public class MotorTanque : MonoBehaviour
{
    private AudioSource _audioSource;
    private Tank_Inputs _input; 

    [Header("Configuración de Volumen")]
    public float Minimo = 0.5f;  
    public float Maximo = 1.5f; 

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _input = GetComponent<Tank_Inputs>(); 
    }

    void Update()
    {
        if (_input != null)
        {
         
            float intensidadMovimiento = Mathf.Abs(_input.ForwardInput);
            
            _audioSource.volume = Mathf.Lerp(Minimo, Maximo, intensidadMovimiento);
        }
    }
}