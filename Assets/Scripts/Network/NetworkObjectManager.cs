using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkObjectManager : NetworkBehaviour {

   [Command]
    public void CmdTransferRocket(float x, float rotX, float rotY, float speed, int currentSprite)
    {
		Camera.main.GetComponent<UpperRocketManager> ().SpawnRocket (x, new Vector2 (rotX, rotY), speed, currentSprite);
    }
}
