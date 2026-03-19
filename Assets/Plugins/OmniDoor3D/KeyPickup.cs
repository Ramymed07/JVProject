namespace ABCodeworld.Examples
{
    using UnityEngine;

    public class KeyPickup : MonoBehaviour
    {
        public static bool hasKey = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            hasKey = true;
            Debug.Log("Key picked up!");

            if (Inventory.instance == null)
            {
                Debug.LogError("Inventory instance is null! Make sure Inventory script is on the Player.");
                return;
            }

            Inventory.instance.AddItem("Key");
            gameObject.SetActive(false);
        }
    }
}