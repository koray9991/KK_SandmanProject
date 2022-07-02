using System.Collections.Generic;
using UnityEngine;

public class LimbControl : MonoBehaviour
{
  public int activeItemCount;
  public int totalItemCount;
  private List<Sphere> activeSphereList = new List<Sphere>();
  private List<Sphere> deactiveSphereList = new List<Sphere>();
  private void Start()
  {
    for (int i = 0; i < transform.childCount; i++)
    {
      activeSphereList.Add(transform.GetChild(i).GetComponent<Sphere>());
    }
    activeItemCount = activeSphereList.Count;
    totalItemCount = activeItemCount;
  }
  public void ActivateItem(Sphere sphere)
  {
    if (deactiveSphereList.Contains(sphere))
      deactiveSphereList.Remove(sphere);
    activeSphereList.Add(sphere);
        sphere.gameObject.SetActive(true);
    activeItemCount++;
  }
  public void DeactivateItem(Sphere sphere)
  {
    activeItemCount--;
    activeSphereList.Remove(sphere);
    deactiveSphereList.Add(sphere);
  }
  public Sphere GetFreeSphere()
  {
    
    var sphere = deactiveSphereList[0];
    ActivateItem(sphere);
    return sphere;
  }
  
}