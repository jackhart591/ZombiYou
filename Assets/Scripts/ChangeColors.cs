using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    [Tooltip("This is the object that'll have the player health and player class")]
    public GameObject entity;
    //vars for color stuff
    public float health = 10f;
    float prevHealth;
    public float maxHealth = 10f;
    float counter = 0f;
    bool crit = false;
    Renderer playerRender;
    Material[] materials;
    List<Color> colors = new List<Color>();
    List<Color> originalColors = new List<Color>();
    int materialLength;

    void SetGradientColor(float amount, Color color)
    {

        for(int i = 0 ; i < materialLength; i++)
        {
            colors[i] = originalColors[i];
        }

        for (int i = 0; i < materialLength; i++)
        {
            colors[i] = Color.Lerp(colors[i], color, amount);
        }

        for (int i = 0; i < materialLength; i++)
        {
            materials[i].color = colors[i];
            playerRender.materials = materials;
        }
    }

    void BackandFourthColor(Color a, Color b)
    {
        
        for (int i = 0; i < materialLength; i++)
        {
            colors[i] = Color.Lerp(b, a, Mathf.Abs(Mathf.Sin(5 * counter)));
        }

        for (int i = 0; i < materialLength; i++)
        {
            materials[i].color = colors[i];
            playerRender.materials = materials;
        }
        
    }

    void Start()
    {
        //set color stuff
        health = entity.GetComponent<Entity>().Health;
        maxHealth = entity.GetComponent<Entity>().MaxHealth;
        prevHealth = health;

        playerRender = GetComponent<Renderer>();
        materials = playerRender.materials;
        materialLength = materials.Length;
        for (int i = 0; i < materialLength; i++)
        {
            originalColors.Add(Color.blue);
        }
        for (int i = 0; i < materialLength; i++)
        {
            colors.Add(Color.blue);
        }
        for (int i = 0; i < materialLength; i++)
        {
            originalColors[i] = materials[i].color;
            colors[i] = originalColors[i];
        }
        
    }

    void Update()
    {
        health = entity.GetComponent<Entity>().Health;
        maxHealth = entity.GetComponent<Entity>().MaxHealth;
        float healthPercent = (health / maxHealth);
        if (health != prevHealth)
        {
            if (healthPercent >= 0.2f)
            {
                counter = 0f;
                crit = false;
                SetGradientColor((1-healthPercent), Color.red);
            }
            else
            {
                crit = true;
                
            }
            prevHealth = health;
        }
        if (crit)
        {
            BackandFourthColor(Color.black, Color.red);
            counter += 1f;
        }
        
    }
}
