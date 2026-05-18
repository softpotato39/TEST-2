using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Interactablez : MonoBehaviour
{
    public GameObject gameHuddy;              // the object in the players hud as if they are holding it >:D
    Outline highlighter;                    // this is the outline that will be around the object once the player is looking at it :3
    public UnityEvent onInteraction;        // the trigger to make something happens once the player interacts with the object >:)

    void Start()                            // get the outline component and hide it once game starts > o<
        {
            highlighter = GetComponent<Outline>();
            GoAwayOutline();
        }

    public void ShowMeOutline()             // make outline visible to player once they lock in >:)
        {
            highlighter.enabled = true;
        }

    public void GoAwayOutline()             //make outline invisible to player if they be lookin away >:(
        {
            highlighter.enabled = false;
        }

    public void Interact()                 // trigger whatever we want once player interacts with the object >:D
        {
            //onInteraction.Invoke();
            Destroy(gameObject);
            gameHuddy.SetActive(true);
        }

}
