using System.Collections.Generic;
using UnityEngine;

public class PatlaSise : MonoBehaviour, clickble
{
    

    [SerializeField] private Material seciliMat;
    [SerializeField] private Material normalMat;
    public GameObject[] rafObjects;
    private Renderer childRenderer;
    public List<GameObject> rafObjectss;

    public static GameObject firstobj;
    public static GameObject rafstun;
    public static List<GameObject> removelist = new List<GameObject>();
    public static PatlaSise instancee = null;

    private void Awake()
    {
        if (instancee == null)
        {
            instancee = this;
        }
    }

    private void Start()
    {

        if (firstobj == null || rafstun == null)
        {
            firstobj = patlatraflar.instance.firtobjnGlobal;
            rafstun = patlatraflar.instance.rafstunGlobal;
        }

        rafObjects = GameObject.FindGameObjectsWithTag("raf");
        childRenderer = transform.GetChild(1).GetComponent<Renderer>();

        if (childRenderer != null)
        {
            normalMat = childRenderer.material;
        }
    }

    public void Click()
    {
        ÝsPatla();
    }

    public void ÝsPatla()
    {
        UpdateRemoveList();
        if (patlatraflar.instance.firtobjnGlobal == null || patlatraflar.instance.firtobjnGlobal == gameObject.transform.parent.gameObject)
        {
            TogglePatlaState();
            UpdateRaflist();
        }
        else
        {
            CheckAdjacentObjects();
        }
    }

    private void TogglePatlaState()
    {
        UpdateChildMaterial();
    }

    private void UpdateChildMaterial()
    {
        if (childRenderer != null)
        {
            if (childRenderer.material == normalMat)
            {
                childRenderer.material = seciliMat;
                patlatraflar.instance.gameliste.Add(gameObject);
            }
            else
            {
                if (removelist.Count > 0 &&
                    (gameObject.transform.parent.gameObject == removelist[0] ||
                     gameObject.transform.parent.gameObject == removelist[removelist.Count - 1]))
                {
                    childRenderer.material = normalMat;
                    patlatraflar.instance.gameliste.Remove(gameObject);
                }
            }
        }
    }

    private void UpdateRaflist()
    {
        foreach (GameObject obj in rafObjects)
        {
            rafObjectss = obj.GetComponent<raflar>().siseObj;
            for (int i = 0; i < rafObjectss.Count; i++)
            {
                if (rafObjectss[i] == gameObject.transform.parent.gameObject)
                {
                    if (rafstun == null && firstobj == null)
                    {
                        rafstun = obj;
                        firstobj = gameObject.transform.parent.gameObject;
                        patlatraflar.instance.firtobjnGlobal = firstobj;
                        patlatraflar.instance.rafstunGlobal = rafstun;
                    }
                    else
                    {
                        ResetRafSelection();
                    }
                }
            }
        }
    }

    private void ResetRafSelection()
    {
        rafstun = null;
        firstobj = null;
        patlatraflar.instance.firtobjnGlobal = firstobj;
        patlatraflar.instance.rafstunGlobal = rafstun;
    }

    private void CheckAdjacentObjects()
    {
        for (int j = 0; j < rafstun.GetComponent<raflar>().siseObj.Count; j++)
        {
            foreach (GameObject siseobjesilist in patlatraflar.instance.gameliste)
            {
                if (rafstun.GetComponent<raflar>().siseObj[j] == siseobjesilist.transform.parent.gameObject)
                {
                    if (IsAdjacentObject(j))
                    {
                        TogglePatlaState();
                        return;
                    }
                }
            }
        }
    }

    private bool IsAdjacentObject(int index)
    {
        var raflarComponent = rafstun.GetComponent<raflar>();

        bool isNextObjectValid = index + 1 < raflarComponent.siseObj.Count;
        bool isPreviousObjectValid = index - 1 >= 0;

        if (isNextObjectValid && gameObject.transform.parent.gameObject == raflarComponent.siseObj[index + 1])
        {
            return true;
        }

        if (isPreviousObjectValid && gameObject.transform.parent.gameObject == raflarComponent.siseObj[index - 1])
        {
            return true;
        }

        return false;
    }

    private void UpdateRemoveList()
    {
        removelist.Clear(); // Önceki verileri temizle
        foreach (GameObject obj in patlatraflar.instance.gameliste)
        {
            removelist.Add(obj.transform.parent.gameObject);
        }
        removelist.Sort((a, b) => string.Compare(a.name, b.name));
    }

}
