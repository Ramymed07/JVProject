namespace ABCodeworld.Examples
{
    using ABCodeworld.OmniDoor3D;
    using UnityEngine;

    public class DoorControllerExample : MonoBehaviour
    {
        [HideInInspector, SerializeField] public SpriteRenderer spaceHint;
        [SerializeField] private OmniDoor3DController dc;
        private bool playerNearby = false;
	private bool doorOpen = false; // ADD THIS

        private void Awake()
	{
    if (dc == null) Debug.LogError("Dc slot is empty — drag OmniDoor3DController object into the Inspector 	slot!");
    	else Debug.Log("DoorController: dc assigned OK!");
	}

        private void Update()
	{
	    if (playerNearby && Input.GetKeyDown(KeyCode.E))
	    {
 	       if (!Inventory.instance.HasItem("Key"))
	{
	    Debug.Log("The door is locked! Find the key first.");
	    return;
	}
 	       if (doorOpen)
 	       {
 	           CloseDoor();
 	           doorOpen = false;
  	      }
  	      else
  	      {
  	          OpenDoor();
  	          doorOpen = true;
  	      }
  	  }
	}

        public void OpenDoor()
        {
            dc.OpenDoor?.Invoke();
        }
        public void CloseDoor()
        {
            dc.CloseDoor?.Invoke();
        }

        public void LockDoor()
        {
            dc.LockDoor?.Invoke();
        }

        public void UnlockDoor()
        {
            dc.UnlockDoor?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("DoorController: Something entered trigger: " + other.gameObject.name + " | Tag: " + other.tag);
            if (!other.CompareTag("Player"))
                return;
            playerNearby = true;
            Debug.Log("DoorController: Player entered! playerNearby = true");
            if (spaceHint != null) spaceHint.enabled = true;
            PlayerOrbital po = other.GetComponent<PlayerOrbital>();
            if (po != null) po.doorController = dc;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;
            playerNearby = false;
            Debug.Log("DoorController: Player exited! playerNearby = false");
            if (spaceHint != null) spaceHint.enabled = false;
            PlayerOrbital po = other.GetComponent<PlayerOrbital>();
            if (po != null) po.doorController = null;
        }
    }
}