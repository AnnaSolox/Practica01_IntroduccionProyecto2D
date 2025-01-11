using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Color originalColor;
    private SpriteRenderer blockRenderer;
    private AudioSource audioSource;
    public float colorChangeDuration = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blockRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (blockRenderer != null)
        {
            originalColor = blockRenderer.color;
        }
        else
        {
            Debug.LogError("No SpriteRenderer encontrado en " + gameObject.name);
        }

        if (audioSource == null)
        {
            Debug.LogError("No se encontró AudioSource en " + gameObject.name);
        }
    }


    void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Pelota")) 
        {
            Debug.Log("Colisión detectada con Pelota.");
            StopCoroutine(CambiarColorTemporalmente(Color.yellow));
            StartCoroutine(CambiarColorTemporalmente(Color.yellow));

            if (audioSource != null){
                audioSource.Play();
            }
        }
    }

    private System.Collections.IEnumerator CambiarColorTemporalmente(Color newColor)
    {
            blockRenderer.color = newColor;
            yield return new WaitForSeconds(colorChangeDuration); 
            Debug.Log("Color cambiado a amarillo en: " + gameObject.name);

            blockRenderer.color = originalColor;
            Debug.Log("Color restaurado a su valor original en: " + gameObject.name);
    }
}
