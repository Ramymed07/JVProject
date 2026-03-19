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
            gameObject.SetActive(false);
        }
    }
}