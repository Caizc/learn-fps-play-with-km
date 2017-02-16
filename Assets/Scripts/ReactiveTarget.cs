using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReactToHit()
    {
        WanderingAI behaviour = this.GetComponent<WanderingAI>();
        if (null != behaviour)
        {
            behaviour.SetIsAlive(false);
        }

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
