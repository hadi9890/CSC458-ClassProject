using System;
using _Scripts;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 1;
    [SerializeField] private float currHealth;
    [SerializeField] private Image healthbarImg;
    [SerializeField] private GameObject gameOver;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 1;
    }

    private void Start()
    {
        currHealth = maxHealth;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            ApplyDamage(0.1f);
        }

        if (currHealth <= 0)
        {
            // Die();
            anim.SetTrigger("Death");
        }
    }

    public void ApplyDamage(float dmgValue)
    {
        currHealth -= dmgValue;
        currHealth = Mathf.Clamp(currHealth, 0, 1);
        healthbarImg.transform.localScale = new Vector3(currHealth,1,1);
    }

    private void Die()
    {
        Debug.Log("Player died.");
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
}









