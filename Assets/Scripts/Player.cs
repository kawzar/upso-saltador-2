using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float distanciaAlSuelo;
    [SerializeField] private float distanciaAlEnemigo;
    [SerializeField] private LayerMask sueloLayer;
    [SerializeField] private LayerMask enemigoLayer;
    [SerializeField] private Animator animator;

    private bool estaEnElSuelo = true;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hola desde Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;

        if(estaEnElSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }

        ChequeoSuelo();
        ChequeoEnemigo();
    }

    private void Saltar()
    {
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse); // (0,1)
        estaEnElSuelo = false;
        AudioManager.Instance.PlaySound(AudioClipEnum.Jump);
    }

    private void ChequeoSuelo()
    {
        var raycast = Physics2D.RaycastAll(transform.position, Vector2.down, distanciaAlSuelo, sueloLayer);
        estaEnElSuelo = raycast.Length > 0;

        animator.SetBool("isJumping", !estaEnElSuelo);
    }

    private void ChequeoEnemigo()
    {
        var origin = transform.position + Vector3.left * 0.025f;  // (x,y,z) - (0.25f, 0, 0)

        var raycast = Physics2D.Raycast(origin, Vector2.down, distanciaAlEnemigo, enemigoLayer);

        if(raycast.collider != null)
        {
            GameManager.Instance.AddScore(1);
            raycast.collider.enabled = false;
        }
    }

    public void OnPerder()
    {
       //TODO
    }

    private void OnDrawGizmos()
    {
        var origin = transform.position + Vector3.left * 0.025f;  // (x,y,z) - (0.25f, 0, 0)
        Gizmos.DrawLine(origin, origin + Vector3.down * distanciaAlEnemigo);
    }
}
