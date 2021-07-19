using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    private GameObject _door;
    public int _openCheck = 1;
    [SerializeField] private float x = 90f;
    [SerializeField] private float y = 90f;
    [SerializeField] private float xPos = 1f;
    [SerializeField] private float yPos = 1f;
    [SerializeField] private float zPos = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _door = (GameObject)this.gameObject;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            if (_openCheck == 1)
            {
                _door.transform.Rotate(y, x, 0);
                _door.transform.position = _door.transform.position + new Vector3(xPos, yPos, zPos);
                _door.GetComponent<BoxCollider>().isTrigger = false;
                _openCheck -= 1;
            }
            else if(_door.GetComponent<BoxCollider>().isTrigger = true)
            {
                _door.GetComponent<BoxCollider>().isTrigger = false;
            }
            
        }
    }
}
