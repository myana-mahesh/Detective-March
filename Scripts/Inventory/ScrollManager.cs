using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    


    [SerializeField] ScrollRect sRect;
    [SerializeField] float speedfactor = 0.4f;
    

    

   

    public void ScrollUp()
    {

        sRect.verticalNormalizedPosition += speedfactor;
            
    }

    public void ScrollDown()
    {
        sRect.verticalNormalizedPosition -= speedfactor;



    }


}
