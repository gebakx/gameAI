using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Rules : MonoBehaviour
{
    public GameObject cop;
    public GameObject treasure;
    public float dist2steal;
    public NavMeshAgent agent;

    HashSet<string> datum;
    List<(Func<bool>,Action)> rules;

    private WaitForSeconds wait = new WaitForSeconds(0.25f); 

    void Start()
    {
        // datum: only bools
        datum = new HashSet<String>();
        rules = new List<(Func<bool>,Action)>();
        // priority: order
        // Hiding
        rules.Add((
            () => datum.Contains("stolen"),
            () => { 
                    gameObject.SendMessage("Hide"); 
                  }
            ));
        // Steal    
        rules.Add((
            () => datum.Contains("approaching") &&
                  (Vector3.Distance(this.transform.position, treasure.transform.position) < 2f),
            () => {
                    datum.Remove("approaching");
                    datum.Add("stolen");
                    treasure.SetActive(false);
                    agent.speed = 2f;
                    gameObject.SendMessage("Hide");
                  }
            ));
        // goto Approaching
        rules.Add((
            () => !datum.Contains("approaching") && 
                  (Vector3.Distance(cop.transform.position, treasure.transform.position) >= dist2steal),
            () => { 
                    datum.Add("approaching");
                    agent.speed = 3f;
                    gameObject.SendMessage("Seek", treasure.transform.position); 
                  }
            ));
        // goto Wander
        rules.Add((
            () => datum.Contains("approaching") && 
                  (Vector3.Distance(cop.transform.position, treasure.transform.position) < dist2steal),
            () => { 
                    datum.Remove("approaching");
                    agent.speed = 1.5f;
                    gameObject.SendMessage("Wander"); 
                  }
            ));
        // Wander
        rules.Add((
            () => !datum.Contains("approaching") && 
                  (agent.remainingDistance < 0.5f),
            () => { 
                    gameObject.SendMessage("Wander"); 
                  }
            ));

        // Start Rule-System
        StartCoroutine(inference());
    }


    IEnumerator inference()
    {
        while (true)
        {
            IEnumerable<(Func<bool>,Action)> res = rules.Where(x => x.Item1());
            if (res.Count() > 0)
                res.First().Item2();
            yield return wait;
        }
    }
}
