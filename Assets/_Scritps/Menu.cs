using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject PlayerFire;
    public GameObject PlayerWater;
    public GameObject PlayerGrass;
    public GameObject Canvas;

    public void HideCanvas()
    {
        Canvas.SetActive(false);
    }

    public void Fire()
    {
        PlayerFire.SetActive(true);
    }

    public void Water()
    {
        PlayerWater.SetActive(true);
    }
    public void Grass()
    {
        PlayerGrass.SetActive(true);
    }

}
