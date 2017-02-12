using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkObjectManager : NetworkBehaviour {

    [Command]
    public void CmdTransferRocket(float x, float rotZ, float speed, int currentSprite)
    {
		Camera.main.GetComponent<UpperRocketManager> ().SpawnRocket (x, rotZ, speed, currentSprite);
    }
}
