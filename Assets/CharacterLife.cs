using UnityEngine;
using UnityEngine.UI;

public class CharacterLife : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] Text HpText;
    int currentHealth;
    GameStateManager manager;
    private void Start()
    {
        ChangeHealth(maxHealth);
        manager = FindObjectOfType<GameStateManager>();
    }
    private void Update()
    {
        /* Collider[] targets = Physics.OverlapSphere(transform.position, 3);
         foreach (var item in targets)
             if (item.CompareTag("Heal"))
             {
                 ChangeHealth(50);
                 Destroy(item.gameObject);
             }*/
    }
    public void ChangeHealth(int hp)
    {
        currentHealth += hp;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        else if (currentHealth <= 0)
        {
            manager.Lost();
        }
        HpText.text = currentHealth.ToString();
    }
}
