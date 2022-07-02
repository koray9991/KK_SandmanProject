using UnityEngine;
public class Camera : MonoBehaviour
{
  [SerializeField] Transform targetTransform;
    public float IndexZ;
  
  private void LateUpdate()
  {
        transform.position = new Vector3(transform.position.x, transform.position.y, targetTransform.position.z -IndexZ);
  }
}