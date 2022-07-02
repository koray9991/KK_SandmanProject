using UnityEngine;
public class Sphere : MonoBehaviour
{
  [SerializeField] Rigidbody rb;
  [SerializeField] LimbControl limbScript;
  
  private Vector3 startLocalPosition, endLocalPosition;
  private float localPositionCounter;
  private bool goLocalPosition;
  public float startYPosition;
  private void Start()
  {
    Manager.Instance.sphereActiveObjectList.Add(this);
   
    startYPosition = transform.position.y;
  }
  private void Update()
  {
    if (goLocalPosition)
    {
      localPositionCounter += Time.deltaTime * 2f;
      transform.localPosition = Vector3.Slerp(startLocalPosition, endLocalPosition, localPositionCounter);
      if (localPositionCounter > 1f)
      {
        localPositionCounter = 0;
        goLocalPosition = false;
        Manager.Instance.DeactiveteObject(this);
        Character.Instance.ControlAnimation();
      }
    }
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Obstacle") && transform.parent.GetComponent<LimbControl>())
    {
            limbScript.DeactivateItem(this);
            gameObject.SetActive(false);
        }
  }
  
 


  public void GoTargetSphere(Sphere targetSphere)
  {
    
    goLocalPosition = true;
  }
}