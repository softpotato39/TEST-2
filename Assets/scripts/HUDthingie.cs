using UnityEngine;

public class HUDthingie : MonoBehaviour
{
    public static HUDthingie instance;
    public GameObject promty;    // this is gonna be the game object we use for the prompt ! i didnt use textmpro or whatever cuz i wanted to use pretty images for promts from canva >:3

    private void Awake() 
    {
        instance = this;  //the second the game starts we make this an instance ! so we can talk to it from other scripts >:)
    }    

    public void Start()
    {
        promty.SetActive(false); // hide the prompt once game starts >:( 
    }

    public void ShowMeDaWay()
    { 
        promty.SetActive(true); 
    }
    public void HideDaWay()
    {
        promty.SetActive(false);
    }

}
