using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject explosion;

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            GameObject obj = Pool.singleton.Get("bullet");
            if(obj != null)
            {
                obj.transform.position = this.transform.position;
            }   
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position) + new Vector3(3, -75, 0);
        healthBar.transform.position = screenPos;
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("asteroid"))
        {
            other.gameObject.SetActive(false);
            healthBar.value -= 30;
            CheckHealth();       
        }    
    }

    void CheckHealth()
    {
        if(healthBar.value <= 0)
        {
            OnDestroyShip();
        }
    }

    void OnDestroyShip()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(healthBar.gameObject, 0.1f);
        Destroy(this.gameObject, 0.1f);
    }
}