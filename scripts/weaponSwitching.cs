using UnityEngine;

public class weaponSwitching : MonoBehaviour
{
    public GameObject weapon01;
    public GameObject weapon02;
    public GameObject weapon03;
    public player_movement player;

    private void Start()
    {
        weapon01.SetActive(true);
        weapon02.SetActive(false);
        weapon03.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            weapon01.SetActive(true);
            weapon02.SetActive(false);
            weapon03.SetActive(false);
        }
        if (Input.GetKeyDown("2") && player.hasDart==true)
        {
            weapon01.SetActive(false);
            weapon02.SetActive(true);
            weapon03.SetActive(false);
        }
        if (Input.GetKeyDown("3") && player.hasShotgun==true)
        {
            weapon01.SetActive(false);
            weapon02.SetActive(false);
            weapon03.SetActive(true);
        }

    }

}
