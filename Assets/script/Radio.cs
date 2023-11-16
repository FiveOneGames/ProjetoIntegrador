using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Radio : MonoBehaviour
{
    public Transform objetoParaDetectar;
    public float volumeMaximo = 1.0f;
    public float volumeMinimo = 0.0f;
    public float distanciaMaxima = 10.0f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Garantir que o objeto de áudio esteja configurado para tocar
        audioSource.playOnAwake = true;
    }

    void Update()
    {
        if (objetoParaDetectar != null)
        {
            float distancia = Vector3.Distance(transform.position, objetoParaDetectar.position);
            float novoVolume = Remapear(distancia, 0, distanciaMaxima, volumeMaximo, volumeMinimo);
            novoVolume = Mathf.Clamp(novoVolume, volumeMinimo, volumeMaximo);
            audioSource.volume = novoVolume;
        }
    }

    float Remapear(float valor, float valorMinimo, float valorMaximo, float novoMinimo, float novoMaximo)
    {
        return novoMinimo + (valor - valorMinimo) * (novoMaximo - novoMinimo) / (valorMaximo - valorMinimo);
    }
}
