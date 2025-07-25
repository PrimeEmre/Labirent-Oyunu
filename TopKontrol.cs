using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // It is best practice to add this line when using UI elements.

public class TopKontrol : MonoBehaviour
{
    public Text zaman, can, durum;

    private Rigidbody rg;
    float zamanSayici = 65;
     int canSayici = 40;
     bool oyunDevam = true;
   bool oyunTamam = false;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (oyunDevam && !oyunTamam)
        {
            zamanSayici -= Time.deltaTime;
            zaman.text = (int)zamanSayici + ""; 
        }
      
      
        else if (!oyunTamam)
        {
            durum.text = "Game over ";
        }

        // This check stops the game if the time runs out.
        if (zamanSayici < 0)
        {
            oyunDevam = false;
        }
    }

    void FixedUpdate()
    {
        // Player can only move if the game is active and not finished.
        if (oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");

            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * 5f);
        }
        else
        {
         
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision cls)
    {
        // Only check for collisions if the game is still running.
        if (oyunDevam && !oyunTamam)
        {
            string objIsmi = cls.gameObject.name;

            if (objIsmi.Equals("bitis"))
            {
                oyunTamam = true; // This stops player movement and the timer text.
                durum.text = "Game finished Good Job !";
            }
            else if (!objIsmi.Equals("LabirentZemini") && !objIsmi.Equals("Zemin"))
            {
                canSayici -= 1;
                can.text = canSayici + "";
                if (canSayici == 0)
                {
                    oyunDevam = false; // This stops the game and triggers the "Game over" message.
                }
            }
        }
    }
}
