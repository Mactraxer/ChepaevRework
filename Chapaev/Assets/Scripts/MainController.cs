using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
    public float force = 50f;
    // Use this for initialization
    private Vector3 startPosition;
    private Vector3 endPosition;

    private LineRenderer lineRend;
    private Rigidbody rg;

    private bool isSelected;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    
                    if (rg = hit.transform.GetComponent<Rigidbody>())
                    {
                        startPosition = rg.position;
                    }
                    
                    if (lineRend = hit.transform.GetComponent<LineRenderer>())
                    {
                        isSelected = true;
                        lineRend.SetPosition(0, startPosition);
                        lineRend.SetPosition(1, startPosition);
                        
                    }
                }
            }
        }
        if (isSelected)
        {
            Vector3 newVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newVec.z = rg.position.z;

            lineRend.SetPosition(1, newVec);
            //print("MousePosition X =" + Input.mousePosition.x + 
              //  "\n"+ "MousePosition Y =" + Input.mousePosition.x);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isSelected)
            {
                endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                endPosition.z = rg.position.z;
                move(rg, (startPosition - endPosition));
            }
            isSelected = false;
        }

	}
    private void move(Rigidbody rig, Vector3 direction)
    {
        //direction.y = rg.position.y;
        rig.AddForce(direction,ForceMode.Impulse);

    }
    private void printName(GameObject obj)
    {
        print(obj.name);
    }
}
