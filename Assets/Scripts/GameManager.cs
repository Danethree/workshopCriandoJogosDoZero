using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int totalCoins;
    public Text coinText;
    public Image healthBar;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCoins()
    {
        totalCoins++;
        if (totalCoins < 10)
        {
            coinText.text = "0" + totalCoins.ToString();
        }
        else
        {
            coinText.text = totalCoins.ToString();
        }
       
    }

    public void TakeDamage(float valor )
    {
        healthBar.fillAmount = valor / 10;
        
    }
}
