using UnityEngine;



public class CameraController : MonoBehaviour


{
    private Camera playerCam;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerCam.transform.position = player.transform.position + new Vector3(0, 20, 0);
    }
}
