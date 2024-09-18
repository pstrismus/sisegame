using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonclick : MonoBehaviour, clickble
{
    public int sayýý = 16;
    public static buttonclick instance = null;
    [SerializeField] GameObject knifeObje;
    public bool isknife;
    public bool isdelete;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        sayýý = 16;
    }

    public void Click()
    {
        if (patlatraflar.instance.gameliste != null && patlatraflar.instance.gameliste.Count > 0)
        {
            StartCoroutine(SilmeIslemi(patlatraflar.instance.gameliste));
        }
    }

    private void particleControl(GameObject bomsise)
    {
        bomsise.SetActive(true);
    }

    public IEnumerator SilmeIslemi(List<GameObject> patlayacaklar)
    {
        isdelete = true;
        foreach (var patla in patlayacaklar)
        {
            if (isknife == false)
            {
                knifeCreator(patla.transform.position.x, patla.transform.position.y);
                isknife = true;
  
                yield return new WaitUntil(() => isknife == false);
                yield return new WaitForSeconds(1.2f);
            }
        }
        isdelete = false;
        patlatraflar.instance.gameliste.Clear();
        PatlaSise.removelist.Clear();
        gamenager.instance.setPlayer();
        gamenager.instance.player();
    }

   public void knifeCreator(float x, float y)
    {
        Instantiate(knifeObje, new Vector3(x, y, -15.74215f), Quaternion.identity);
    }

    public void selectdelete(GameObject patla)
    {
        particleControl(patla.transform.parent.gameObject.transform.GetChild(1).gameObject);
        Destroy(patla, 0.1f);
        sayýý--;

        PatlaSise.firstobj = null;
        PatlaSise.rafstun = null;
        patlatraflar.instance.firtobjnGlobal = null;
        patlatraflar.instance.rafstunGlobal = null;
    }
}
