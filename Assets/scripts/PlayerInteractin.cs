using UnityEngine;

public class PlayerInteractin : MonoBehaviour
{
    public float longHands = 3f;        // how far player can reach to interact :P
    Interactablez lookAtMe;             // the object that player is looking at :O

    void LateUpdate()
    {
        IsItOrIsItNot();             // always be checkin if player looks at stuff they can interact with !

        if(Input.GetKeyDown(KeyCode.E) && lookAtMe != null)   // if player presses E, and the thing is interactable ? Boom = interaction
        {
            lookAtMe.Interact();
        }
    }

    public void IsItOrIsItNot()         //basically a check to see if something is interactable or not, usin raycast boii
    {
        RaycastHit hit;
        Ray laser = new Ray(Camera.main.transform.position, Camera.main.transform.forward);  // raycast casting from the main cam to where player is looking at

        if (Physics.Raycast(laser, out hit, longHands))              // if raycast from cam hits, and its within reach... we check if its interactable or not >:)
        {

            if (hit.collider.tag == "interactable")

            {
                Interactablez mayIBeDaBoss = hit.collider.GetComponent<Interactablez>();        // objects gotta have the "interactablez" script to be interactable !

                if (lookAtMe && mayIBeDaBoss != lookAtMe)       // updates the outline to the current thing player is lookin at !
                { 
                    lookAtMe.GoAwayOutline();
                }

                if (mayIBeDaBoss.enabled)   //makes object highlighteeed !!
                {
                    MakeThisObjTheNewBoss(mayIBeDaBoss);
                }

                else                // if main cam raycast aint hitting stuff, nothing is highlighted :(
                {
                    NoLongerDaBoss();
                }

            }

            else                // also also if main cam raycast aint hitting stuff, nothing is highlighted :(
            {
                NoLongerDaBoss();
            }

        }

        else                    // also also here if main cam raycast aint hitting stuff, nothing is highlighted :(
        {
            NoLongerDaBoss();
        }

    }

    public void MakeThisObjTheNewBoss(Interactablez mayIBeDaBoss)
    {
        lookAtMe = mayIBeDaBoss;            // the new boss object is the thing player is looking at now (cuz its the boss in our eyes :3)
        lookAtMe.ShowMeOutline();           // make the outline show up on the new boss interactable >:D
        HUDthingie.instance.ShowMeDaWay();   // show the promt to interact with the new boss >:D
    }

    public void NoLongerDaBoss()
    {
        HUDthingie.instance.HideDaWay();     // hide promt if player aint looking at anything interactable x-x
        if (lookAtMe)                       // make da boss go away and hide its outline >:(
        {
            lookAtMe.GoAwayOutline();
            lookAtMe = null;
        }
    }

}