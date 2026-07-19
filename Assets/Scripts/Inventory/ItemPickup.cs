using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickup : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] private ItemData item;
    [SerializeField] private int quantity = 1;
 
    [Header("Config")]
    [SerializeField] private string playerTag = "Player";
 
    private void Reset()
    {
        // Garante que o collider já vem configurado como trigger ao adicionar o script
        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;
 
        // Pega o componente Inventory no objeto que colidiu (o Player)
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogWarning($"{other.name} não tem componente Inventory.");
            return;
        }
 
        int leftover = inventory.AddItem(item, quantity);
 
        if (leftover == 0)
        {
            // Coletou tudo -> remove o item do chão
            Destroy(gameObject);
        }
        else
        {
            // Inventário cheio -> deixa só o restante no chão
            quantity = leftover;
        }
    }
}
 