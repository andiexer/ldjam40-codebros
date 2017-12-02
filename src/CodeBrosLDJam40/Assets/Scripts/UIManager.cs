using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public PlayerHealthManager playerHealthManager;
    public Text textHP;
    public Slider healthBar;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    healthBar.maxValue = playerHealthManager.playerMaxHealth;
	    healthBar.value = playerHealthManager.playerCurrentHealth;
	    textHP.text = healthBar.value + " of " + healthBar.maxValue;
	}
}
