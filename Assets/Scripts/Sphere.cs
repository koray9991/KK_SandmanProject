using UnityEngine;
public class Sphere : MonoBehaviour
{
  
  [SerializeField] LimbControl limbScript;
  private Vector3 startLocalPosition, endLocalPosition;
  private bool goLocalPosition;
  public float startYPosition;
  private void Start()
  {
    Manager.Instance.ActiveSpheres.Add(this);
   
    
  }
  private void Update()
  {
    if (goLocalPosition)
    {
     
      transform.localPosition = Vector3.Slerp(startLocalPosition, endLocalPosition, 1);
     
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