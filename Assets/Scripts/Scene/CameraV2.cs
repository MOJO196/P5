using UnityEngine;

public class CameraV2 : MonoBehaviour
{
 public GameObject player;
  public float offset;
  private Vector3 playerPosition;
  public float offsetSmoothing;
  // Use this for initialization
  void Start () {
  
  }
  
  // Update is called once per frame
  void Update () 
  {
    playerPosition = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
    
    if (player.transform.localScale.x > 0f) 
    {
      playerPosition = new Vector3 (playerPosition.x + offset, playerPosition.y, playerPosition.z);
    }
    else 
    {
      playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
    }
    transform.position = Vector3.Lerp (transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
  }
}