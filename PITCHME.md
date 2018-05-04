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
for (int x = 2; x < 29; x++) {
  GameObject pd = Instantiate(PacDotPrefab);
  pd.transform.position = new Vector2(x, 2);
}
```

@[2-3](Steps to repeat.)
@[2-3](The X value will change.)
@[1,4](Wrapping with a loop.)
@[1-4](Finished loop to create a single row.)

Note:

+++

**for** loops - repeat a predictable number of times. They look like this:

```csharp
for (_loop control goes here_) {
  // Code to repeat goes here.
}
```

+++

### Loop control

```csharp
for (***initialize***; ***check***; ***recalculate***) {
  // Repeating code.
}
```

* Initialize: `int x = 2`
* Check: `x < 29`
* Recalculate: `x++`

The code `x++` means add one to X.

+++

### The Final Loop

```csharp
for (int x = 2; x < 29; x++) {
  GameObject pd = Instantiate(PacDotPrefab);
  pd.transform.position = new Vector2(x, 2);
}
```

@[1.4]

This reads as:

* Initialize X to 2.
* Check that X is still less than 29.
* Add one to X and repeat the loop.

After the loop completes, execution will continue with the line after the closing curly brace of the loop.

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
