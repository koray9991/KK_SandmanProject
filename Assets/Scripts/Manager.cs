using System.Collections.Generic;
using UnityEngine;
public class Manager : MonoBehaviour
{
  public static Manager Instance;
  public List<Sphere> ActiveSpheres;
  public List<Sphere> DeactiveSpheres;
  private void Awake()
  {
    Instance = this;
  }
  public void DeactiveteObject(Sphere sphere)
  {
    sphere.transform.parent = transform;
        ActiveSpheres.Remove(sphere);
        DeactiveSpheres.Add(sphere);
    sphere.gameObject.SetActive(false);
  }
  
}