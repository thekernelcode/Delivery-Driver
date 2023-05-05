using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    [SerializeField] float destroyDelay = 0.5f;

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;
    Driver driverScript;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        driverScript = GetComponent<Driver>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You cunt");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Package") && hasPackage == false)
        { 
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.tag == ("Customer") && hasPackage == true)
        {
            Debug.Log("Package delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        else if (other.tag == ("Boost"))
        {
            Debug.Log("Boost!");
        }
    }
}
