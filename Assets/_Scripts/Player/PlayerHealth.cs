using _Scripts;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 1;
    [SerializeField] private float currHealth;
    [SerializeField] private Image healthbarImg;

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
            Die();
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
    }
}
