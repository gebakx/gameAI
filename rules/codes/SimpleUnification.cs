using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Fact
{
    public string identifier { get; }
    public string content;
    public List<Fact> childs { get; }

    public Fact(string id, string cnt)
    {
        identifier = id;
        content = cnt;
        childs = new List<Fact>();
    }

    public Fact child(int i)
    {
        return childs[i];
    }

    public void addChild(Fact f)
    {
        childs.Add(f);
    }

    public bool contains(string id, Func<string,bool> p)
    {
        if (identifier == id)
            return p(content);
        if (content == "")
            return childs.Select(x => x.contains(id, p)).Aggregate((x, y) => x || y);
        return false;
    }

    public override string ToString()
    {
        if (content != "")
            return "(" + identifier + " " + content + ")";
        else 
            return "(" + identifier + " " + String.Join(" ", childs.Select(x => x.ToString())) +")";
    }
}

public class SimpleUnification : MonoBehaviour
{
    List<Fact> datum;
    List<(Func<bool>,Action)> rules;

    void Start()
    {
        initialDatum();
        initialRules();        
        // execution
        Debug.Log("Initial:\n" + String.Join("\n", datum.Select(x => x.ToString())));
        inference();
        // Whisker dies
        innerFact("Whisker", "health").content = "0";
        Debug.Log("Die:\n" + String.Join("\n", datum.Select(x => x.ToString())));
        inference();
        Debug.Log("Radio:\n" + String.Join("\n", datum.Select(x => x.ToString())));        
    }

    void inference()
    {
        IEnumerable<(Func<bool>,Action)> res = rules.Where(x => x.Item1());
//        Debug.Log("Rules: " + res.Count().ToString());
        if (res.Count() > 0)
            res.First().Item2();
    }

    Fact innerFact(string id, string cnt)
    {
        return datum.Where(
            x => x.identifier == id).First().childs.Where(
                x => x.identifier == cnt).First();
    }

    HashSet<string> outerList(string id, Func<string,bool> f)
    {
        return new HashSet<string>(datum.Where(x => x.contains(id,f)).Select(x => x.identifier));
    }

    void initialDatum()
    {
        /*
        (Johnson (health 38))
        (Sale (health 15))
        (Whisker (health 25))
        (Radio (held-by Whisker))
        */
        datum = new List<Fact>();
        Fact f = new Fact("Johnson", "");
        f.addChild(new Fact("health", "38"));
        f.addChild(new Fact("ammo", "127"));
        datum.Add(f);
        f = new Fact("Sale", "");
        f.addChild(new Fact("health", "10"));
        f.addChild(new Fact("ammo", "89"));
        datum.Add(f);
        f = new Fact("Whisker", "");
        f.addChild(new Fact("health", "25"));
        f.addChild(new Fact("ammo", "72"));
        datum.Add(f);
        f = new Fact("Radio", "");
        f.addChild(new Fact("held-by", "Whisker"));
        datum.Add(f);
    }

    void initialRules()
    {
        rules = new List<(Func<bool>,Action)>();
        /*
        (?person (health 0-15))
        AND
        (Radio (held-by ?person))
        */
        /* More vars => Intersection */
        rules.Add((
            () => outerList("health", y => int.Parse(y) <= 10).Contains(innerFact("Radio","held-by").content),
            () => { 
                    innerFact("Radio", "held-by").content = outerList("health", y => int.Parse(y) > 15).First();
                  }
            ));
    }
}
