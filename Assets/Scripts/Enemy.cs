using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float rapidez;
        
    void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying) return;

        var bordeIzquierdo = Camera.main.ViewportToWorldPoint(Vector3.left);
        if(transform.position.x < bordeIzquierdo.x)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.left * rapidez);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag ==  "Player")
        {
            collision.gameObject.GetComponent<Player>().OnPerder();
        }
          
        GameManager.Instance.Perder();
    }

    private void OnDestroy()
    {
       // Debug.Log("Me destrui");
    }
}
