using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSense;
    [SerializeField] Transform player, playerArms;

    float xAxisClamp = 0;

    [SerializeField]
    private Camera fpsCamera;
    
   
    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float rotateX = Input.GetAxis("Mouse X") * mouseSense;
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense;

        xAxisClamp -= rotateY;
    
        Vector3 rotPlayerArms = playerArms.rotation.eulerAngles;
        
        Vector3 rotCamera = fpsCamera.transform.localRotation.eulerAngles;
        Vector3 rotPlayer = player.rotation.eulerAngles;

        rotPlayerArms.x -= rotateY;
        rotCamera.x -= rotateY;
        
        rotPlayerArms.z = 0;
        rotPlayer.y += rotateX;
        
        rotCamera.y = rotPlayer.y;
        

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            
            rotCamera.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            
            rotCamera.x = -90;
        }
        
        
       
        
        player.rotation = Quaternion.Euler(rotPlayer);
        fpsCamera.transform.rotation = Quaternion.Euler(rotCamera);
    }
}
