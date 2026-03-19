namespace ABCodeworld.Examples
{
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;
        public TextMeshProUGUI inventoryText; // Drag InventoryText here
        private List<string> items = new List<string>();

        private void Awake()
        {
            instance = this;
            UpdateUI();
        }

        public void AddItem(string itemName)
        {
            items.Add(itemName);
            Debug.Log("Added to inventory: " + itemName);
UpdateUI();
        }
        public bool HasItem(string itemName)
        {
            return items.Contains(itemName);
        }
        private void UpdateUI()
        {
            if (inventoryText == null) return;
            if (items.Count == 0)
                inventoryText.text = "Inventory: empty";
            else
                inventoryText.text = "Inventory:\n" + string.Join("\n", items);
        }
    }
}