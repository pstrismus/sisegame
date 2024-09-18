using System.Collections.Generic;
using UnityEngine;

public class patlatraflar : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private LayerMask clickableLayer;
    public List<GameObject> gameliste;
    public static patlatraflar instance = null;
    public GameObject rafstunGlobal;
    public GameObject firtobjnGlobal;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        clickableLayer = LayerMask.GetMask("Default");
    }

    private void Update()
    {
        if (gamenager.instance.BotActive)
        {
            if (gamenager.instance.mevcutPlayer == gamenager.instance.player1)
            {
                if (Input.GetMouseButtonDown(0) && buttonclick.instance.isdelete == false)
                {
                    Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clickableLayer))
                    {
                        clickble clickblee = hit.collider.GetComponent<clickble>();
                        clickblee?.Click();
                    }
                }
            }
        }
        else if (!gamenager.instance.BotActive)
        {
            if (Input.GetMouseButtonDown(0) && buttonclick.instance.isdelete == false)
            {
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clickableLayer))
                {
                    clickble clickblee = hit.collider.GetComponent<clickble>();
                    clickblee?.Click();
                }
            }
        }
        
    }
}
