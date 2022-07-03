using UnityEngine;
using System.Collections.Generic;
public class Character : MonoBehaviour
{
  public static Character Instance;
 
  [SerializeField] float XSpeed;
    [SerializeField] float ZSpeed;
    [SerializeField] Animator Anim;
    [SerializeField] float MaxX;
    float AnimTimer;
    private Vector3 MovementVector;
    private string activeAnim;
    private bool Go;
    [SerializeField] List<LimbControl> limbScriptList = new List<LimbControl>();
    int Difference;
    int MovingSpheresInt;
    

 
  private void Awake()
  {
    Instance = this;
  }
  private void Start()
  {
    
        MovementVector = new Vector3(0, 0, ZSpeed);
    }
  private void FixedUpdate()
  {
        AnimTimer += Time.deltaTime;
        if (AnimTimer > 1)
        {
            AnimTimer = 0;
            ControlAnimation();
        }
    if (!Go)
    {
      if (Input.GetMouseButtonDown(0))
      {
                Anim.SetTrigger("Walk");
        Go = true;
       
      }
      return;
    }
    Movement();
        
  }
 
 
 
  private void Movement()
  {
    if (Input.GetMouseButton(0))
    {
      MovementVector.x = Input.GetAxis("Mouse X");
    }
    else
     {
            MovementVector.x = 0;
     }
    transform.Translate(XSpeed * Time.deltaTime * MovementVector);
    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -MaxX, MaxX), transform.position.y, transform.position.z);
   
  }


 
  public void ControlAnimation()
  {
        
    var emptyLimbList = new List<bool>();
    var nonEmptyCount = 0;
   
    var count = limbScriptList.Count;
        
    for (int i = 0; i < count; i++)
    {
      if (limbScriptList[i].activeItemCount <= limbScriptList[i].totalItemCount/5)
      { emptyLimbList.Add(true); }
      else
      {
        emptyLimbList.Add(false);
        nonEmptyCount++;
      }
    }
    if (nonEmptyCount  == count)
    {
            activeAnim = "Walk";
    }
    if ((emptyLimbList[7] && emptyLimbList[9] && !emptyLimbList[6] && !emptyLimbList[8])|| emptyLimbList[9] && !emptyLimbList[8])
    {
            activeAnim = "JumpRight";
    }
    
    if ((!emptyLimbList[7] && !emptyLimbList[9] && emptyLimbList[6] && emptyLimbList[8])|| emptyLimbList[8] && !emptyLimbList[9])
    {
            activeAnim = "JumpLeft";
    }
   
    if (emptyLimbList[6] && emptyLimbList[7] && emptyLimbList[8] && emptyLimbList[9])
    {
            activeAnim = "Crawl";
    }
    if(Go)
            Anim.SetTrigger(activeAnim);
    
  }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            ControlLimbs(other.transform);
            other.gameObject.SetActive(false);
        }
    }
    private void ControlLimbs(Transform t)
    {
        var count = limbScriptList.Count;
        for (int i = 0; i < count; i++)
        {
            if (limbScriptList[i].activeItemCount < limbScriptList[i].totalItemCount)
            {

                Difference = limbScriptList[i].totalItemCount - limbScriptList[i].activeItemCount;

                if (t.childCount < Difference)
                    MovingSpheresInt = t.childCount;
                else
                    MovingSpheresInt = Difference;

                for (int j = MovingSpheresInt - 1; j >= 0; j--)
                {
                    t.GetChild(j).GetComponent<Sphere>().GoTargetSphere(limbScriptList[i].GetFreeSphere());
                }
            }
        }
    }
}