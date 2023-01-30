using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if(behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Die()
    {
        for (int i = 0; i < 20; i++)
        {
            this.transform.Rotate(1, 0, 0);
            yield return new WaitForSeconds((float)(1.0/75));
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
