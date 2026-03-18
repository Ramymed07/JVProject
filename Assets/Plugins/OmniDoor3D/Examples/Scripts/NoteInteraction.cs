namespace ABCodeworld.Examples
{
    using UnityEngine;

    public class NoteInteraction : MonoBehaviour
    {
        public GameObject noteCanvas; // Drag NoteCanvas here in the Inspector
        private bool playerNearby = false;
        private bool noteOpen = false;

        private void Update()
        {
            if (playerNearby && Input.GetKeyDown(KeyCode.E))
            {
                if (noteOpen)
                {
                    noteCanvas.SetActive(false);
                    noteOpen = false;
                    Debug.Log("Note closed");
                }
                else
                {
                    noteCanvas.SetActive(true);
                    noteOpen = true;
                    Debug.Log("Note opened");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;
            playerNearby = true;
            Debug.Log("Near note, press E to read");
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;
            playerNearby = false;
            noteCanvas.SetActive(false); // Auto-close if player walks away
            noteOpen = false;
            Debug.Log("Left note area");
        }
    }
}