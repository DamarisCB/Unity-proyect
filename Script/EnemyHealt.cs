using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealt : MonoBehaviour
{
    private string life_points;
    public float destroyText;
   
    Enemy enemy;
    public GameObject deathEffect;
    public bool isDamaget;
    SpriteRenderer sprite;
    Effect material;
    Rigidbody2D rb;

    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Effect>();
        enemy = GetComponent<Enemy>();
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamaget)
        {

            //Debug.Log("Puntos de vida: " + enemy.healtpoinst);
            enemy.healtpoinst -= 2f;
            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.recoilX, enemy.recoilY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-enemy.recoilX, enemy.recoilY), ForceMode2D.Force);
            }
            StartCoroutine(Damager());

            /* GameObject objetoDeTexto = GameObject.FindWithTag("LifeEnemy");
               Text textoVariable = objetoDeTexto.GetComponent<Text>();
               Debug.Log("Puntos de vida: " + life_points);
               */
            if (enemy.healtpoinst > 0)
            {
                /* life_points = enemy.healtpoinst.ToString();
                 textoVariable.text = life_points;
            */

            }
            else if (enemy.healtpoinst <= 0)
            {/*
                life_points = "0";
                textoVariable.text = life_points;
                Destroy(textoVariable, destroyText);*/
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
  
   IEnumerator Damager ()
    {
        isDamaget = true;
        sprite.material = material.Efecto;
        yield return new WaitForSeconds (0.5f);
        isDamaget = false;
        sprite.material = material.Original;
    }
}
