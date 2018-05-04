## Algorithms

* _Algorithms_ describe the process that we use to accomplish a goal.
* In computer science (and game development) algorithms:
  - **Always** complete, and
  - **Always** produce a correct result.

Note:

---

### Building Blocks

* Sequences
* Loops
* Branches

These three builing blocks are sufficient to create _any_ algorithm.

Note:

---

### Sequences

A _sequence_ is set of instructions that are executed in order.

Note:

+++

```csharp
GameObject pd = Instantiate(PacDotPrefab);
pd.transform.position = new Vector2(2, 2);
```

---

### Loops

_Loops_ are sequences that are repeated to accomplish the task while keeping the algorithm shorter and clearer.

Note:

+++

Use loops when you want to repeat a sequence of steps:
1. Identify the steps you want to repeat.
2. Decide what, if anything, should change each time the steps are repeated. Replace constants with variables.
3. Wrap the repeating steps in a loop.
4. Calculate the new value(s) for variables that change

+++

```csharp
for (int x = 2; x < maxX; x++) {
  GameObject pd = Instantiate(PacDotPrefab);
  pd.transform.position = new Vector2(x, 2);
}
```

@[2-3](Steps to repeat.)
@[2-3](The X value will change.)
@[1,4](Wrapping with a loop.)
@[1-4](Finished loop to create a single row.)

Note:

---

### Branches

_Branches_ are used when the algoritm requires you to make decisions.

Think of the decisions as yes/no or true/false questions.

Note:

+++

```csharp
```

---

### Flow Charts

Note:

---

### Pseudocode

Note:

+++

```csharp
```
