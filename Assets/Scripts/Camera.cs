using UnityEngine;
public class Camera : MonoBehaviour
{
  [SerializeField] Transform targetTransform;
  [SerializeField] float IndexZ;
  
  private void LateUpdate()
  {
        transform.position = new Vector3(transform.position.x, transform.position.y, targetTransform.position.z -IndexZ);
  }
}