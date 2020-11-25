class: center, middle

## Artificial Intelligence

# Linq Cookbook

<br>

Gerard Escudero, 2020

<br>

![:scale 35%](figures/complexity.jpg)

.footnote[[source](https://www.ouarzy.com/2017/08/31/why-functional-programming/) ]

---

# Introduction

.blue[repl]: programming shell

- [Repl.it](https://repl.it/languages/csharp)

.cols5050[
.col1[
.blue[Showing a list]:

```
int[] v = { 3, 2, -3, 5 };
string.Join(",", v)
👉 3,2,-3,5
```

.blue[Lambda Functions]:

```
Func<int, int> inc = a => a + 1;
inc(4)) 👉 5
```
]
.col2[
.blue[Lambda Actions]:

```
// IEnumerable requirement
using System.Collections.Generic;
```

```
int[] v = { 3, 2, -3, 5 };
Action<IEnumerable<int>> show = x => {
    Console.WriteLine(
        string.Join(",", x));
};
show(v);  👉  3,2,-3,5
```
]]

---

# Linq I

.blue[Select]: application of a function to a sequence

```
// Linq requirement
using System.Linq;
```

.cols5050[
.col1[
```
int[] v = { 3, 2, -3, 5 };
IEnumerable<int> res = v.Select(inc);
show(res);  👉  4,3,-2,6
```
]
.col2[
```
IEnumerable<int> res = v.Select(
    x => x + 1);
```
]]

.blue[Zip]: `Select` to 2 sequences

```
int[] v = { 3, -2, -3, 5 };
int[] w = { 2, 2, 2, 2, 2, 2};
IEnumerable<int> res = v.Zip(w, (x, y) => x + y);
show(res);  👉  5,4,-1,7
```

---

# Linq II

.blue[Where]: filter a sequence

```
int[] v = { 3, -2, -3, 5 };
IEnumerable<int> res = v.Where(x => x % 2 != 0);
show(res);  👉  3,-3,5
```

```
int res = v.Where(x => x % 2 != 0).First();
Console.WriteLine(res.ToString());  👉  3
```

.blue[Aggregate]: single value from a sequence and an binary function

- Min, Max, Sum, Count, Average

```
int[] v = { 3, 2, -3, 5 };
Console.WriteLine(v.Min().ToString());  👉  -3
```

```
string[] v = { "Pep", "John" };
string res = v.Select(x => (x.Count(), x)).Max().Item2;
Console.WriteLine(res);
```

---

# Linq III

.blue[Aggregate]: user defined functions

```
int[] v = { 3, 2, -3, 5 };
int res = v.Sum();
Console.WriteLine(res.ToString());  👉  7
```

```
int res = v.Aggregate((x, y) => x + y);  👉  7
```

.blue[Identity element]:

```
int[] v = { 3, 2, -3, 5 };
int[] w = { 2, 2, 2, 2 };
int res = v.Zip(w, (x, y) => x * y).Aggregate(-5, (x, y) => x + y);
Console.WriteLine(res.ToString());  👉  9
```

---

# C# data structures

.blue[HashSet]:

```
int[] v = { 3, 2, 3, 2, 3 };
HashSet<int> hs = v.ToHashSet();
show(hs);  👉  3,2
```

.blue[Dictionary]:

```
int[] v = { 2, 3, 2, 3, 2 };
Dictionary<int,int> d = v.GroupBy(x=>x).ToDictionary(
    g => g.Key, 
    g => g.Count()
    );
Console.WriteLine(string.Join(",", 
    d.Select(p => p.Key.ToString() + ":" + 
        p.Value.ToString())));
👉  2:3,3:2
```

