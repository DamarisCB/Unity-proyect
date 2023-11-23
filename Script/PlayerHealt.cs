using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public float recoilX;
    public float recoilY;
    public Image healthImg;
    Rigidbody2D rb;
    bool isInmune;
    public float inmunityTime;
    
    Effect material;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Effect>();
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        healthImg.fillAmount = health / 100;


        if (health> maxHealth)
        {

            health = maxHealth;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());

            if (collision.transform.position.x > transform.position.x)
             {
                 rb.AddForce(new Vector2(-recoilX, recoilY),ForceMode2D.Force);
             }
             else
             {
                 rb.AddForce(new Vector2(recoilX, recoilY), ForceMode2D.Force);
             }
            if (health <=0)
            {
                print("GAME OVER:'C");
            }
        }
    }


    IEnumerator Inmunity()
    {

        isInmune = true;
        sprite.material = material.Efecto;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.Original;
        isInmune = false;
    }

}
