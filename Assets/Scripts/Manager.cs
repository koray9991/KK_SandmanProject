using System.Collections.Generic;
using UnityEngine;
public class Manager : MonoBehaviour
{
  public static Manager Instance;
  public List<Sphere> sphereActiveObjectList;
  public List<Sphere> sphereDeactiveObjectList;
  private void Awake()
  {
    Instance = this;
  }
  public void DeactiveteObject(Sphere sphere)
  {
    sphere.transform.parent = transform;
    sphereActiveObjectList.Remove(sphere);
    sphereDeactiveObjectList.Add(sphere);
    sphere.gameObject.SetActive(false);
  }
  
}