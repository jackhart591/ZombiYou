using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    [Tooltip("This is the object that'll have the player health and player class")]
    public GameObject player;
    //vars for color stuff
    public float health = 10f;
    float prevHealth;
    public float maxHealth = 10f;
    float counter = 0f;
    bool crit = false;
    Renderer playerRender;
    Material[] materials;
    Material hairMaterial;
    Material bodyMaterial;
    Material pantsMaterial;
    Material coatMaterial;
    Material shoesMaterial;
    Color hairColor;
    Color bodyColor;
    Color pantsColor;
    Color coatColor;
    Color shoesColor;
    Color originalHairColor;
    Color originalBodyColor;
    Color originalPantsColor;
    Color originalCoatColor;
    Color originalShoesColor;

    void SetGradientColor(float amount, Color color)
    {
        hairColor = originalHairColor;
        coatColor = originalCoatColor;
        bodyColor = originalBodyColor;
        shoesColor = originalShoesColor;
        pantsColor = originalPantsColor;

        hairColor = Color.Lerp(hairColor, color, amount);
        coatColor = Color.Lerp(coatColor, color, amount);
        bodyColor = Color.Lerp(bodyColor, color, amount);
        shoesColor = Color.Lerp(shoesColor, color, amount);
        pantsColor = Color.Lerp(pantsColor, color, amount);

        coatMaterial.color = coatColor;
        hairMaterial.color = hairColor;
        bodyMaterial.color = bodyColor;
        shoesMaterial.color = shoesColor;
        pantsMaterial.color = pantsColor;
        materials[0] = coatMaterial;
        materials[1] = hairMaterial;
        materials[2] = bodyMaterial;
        materials[3] = shoesMaterial;
        materials[4] = pantsMaterial;
    }

    void BackandFourthColor(Color a, Color b)
    {
        hairColor = Color.Lerp(b, a, Mathf.Abs(Mathf.Sin(5*counter)));
        coatColor = Color.Lerp(b, a, Mathf.Abs(Mathf.Sin(5*counter)));
        bodyColor = Color.Lerp(b, a, Mathf.Abs(Mathf.Sin(5*counter)));
        shoesColor = Color.Lerp(b, a, Mathf.Abs(Mathf.Sin(5*counter)));
        pantsColor = Color.Lerp(b, a, Mathf.Abs(Mathf.Sin(5*counter)));

        coatMaterial.color = coatColor;
        hairMaterial.color = hairColor;
        bodyMaterial.color = bodyColor;
        shoesMaterial.color = shoesColor;
        pantsMaterial.color = pantsColor;
        materials[0] = coatMaterial;
        materials[1] = hairMaterial;
        materials[2] = bodyMaterial;
        materials[3] = shoesMaterial;
        materials[4] = pantsMaterial;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        //set color stuff
        health = player.GetComponent<Player>().Health;
        maxHealth = player.GetComponent<Player>().MaxHealth;
        prevHealth = health;
        playerRender = GetComponent<Renderer>();
        
        if (playerRender != null)
        {
            materials = playerRender.materials;
            coatMaterial = materials[0];
            originalCoatColor = coatMaterial.color;
            hairMaterial = materials[1];
            originalHairColor = hairMaterial.color;
            bodyMaterial = materials[2];
            originalBodyColor = bodyMaterial.color;
            shoesMaterial = materials[3];
            originalShoesColor = shoesMaterial.color;
            pantsMaterial = materials[4];
            originalPantsColor = pantsMaterial.color;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<Player>().Health;
        maxHealth = player.GetComponent<Player>().MaxHealth;
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
