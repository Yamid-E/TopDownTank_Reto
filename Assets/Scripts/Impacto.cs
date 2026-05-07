using UnityEngine;

public class Impacto : MonoBehaviour
{
    public AudioClip sonidoExplosion;

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("¡La bala chocó contra: " + collision.gameObject.name + "!");

        if (sonidoExplosion != null)
        {
         
            GameObject audioTemp = new GameObject("SonidoImpactoTemp");
            AudioSource fuenteAudio = audioTemp.AddComponent<AudioSource>();
            
            fuenteAudio.clip = sonidoExplosion;
            fuenteAudio.spatialBlend = 0f;
            fuenteAudio.volume = 1f;
            
            fuenteAudio.Play();


            Destroy(audioTemp, sonidoExplosion.length);
        }


        Destroy(gameObject);
    }
}