**Navigation:**
- [[#Code]]
	- [[#What is "SequenceCase"?]]
	- [[#Using]]
	- [[#Namespaces]]
	- [[#Methods and functions]]
	- [[#Variables]]
	- [[#Accessors]]
	- [[#Variables - type]]
	- [[#Generics]]
	- [[#Tab-lining]]
	- [[#Classes]]
	- [[#Classes - constructors]]
	- [[#One class - different namespaces]]
	- [[#Using "unchecked"]]
	- [[#Interfaces]]
	- [[#switch-default]]
	- [[#switch-case]]
	- [[#Exceptions]]
	- [[#Inheritance order]]
	- [[#Attributes]]
	- [[#Enums]]
	- [[#Converters]]
- [[#Documentation]]
	- [[#Common rules]]
	- [[#Classes]]
	- [[#Constructors]]
	- [[#Fields, properties (XML)]]
		- [[#Clarifications]]
	- [[#Exceptions]]
	- [[#Enums]]
	- [[#Methods/functions/tasks]]
		- [[#Values in methods]]
	- [[#Arrays, ranges, matrixes]]
- [[#Common commentaries]]
	- [[#First-liners]]
	- [[#Usage of "//"]]
	- [[#Usage of "/ *"]]
	- [[#Usage of "// *"]]
	- [[#Specifications of tags]]

Anything that is not described in this document, at the discretion of the user, is written and implied as in: [.NET Foundation Codestyle Guidelines](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions), it also bases and appends current specification of C#:
- https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/specifications

## Code
### What is "SequenceCase"?

SequenceCase is unique rule of naming that follows with close rules to "PascalCase" naming rule, but allows and uses uppercase in more common way, examples of naming in SequenceCase:
- PostgreSQL
- WriteLN (meaning, "WriteLineNew")
- GenRND (Generate Random and etc.)
- CW (Console Write)
- CWL (Console WriteLine)
- CommonDFN (Common Definitions)

The main conceptual thing about "SequenceCase" that it shifts between itself named nature and "PascalCase", meaning in your code, you combine both "SequenceCase" and "PascalCase" even in one file, this is called "SequeSCAL".
### Using

Keyword "using" can be used in two ways: "using" packages, libraries and namespaces, in this case there are this rules are applied:
1. "using"-array (thereafter as "usings") must start from `System` and from `System` only;
2. usings must create a visual "ladder", from lesser line to bigger line in terms of char count;
3. usings must create subusing hierarchy, meaning if you using one long-path namespace, you also must inlclude their "parent-namespace" until you form "logic-ladder"

Example both for p.2 and p.3:

```csharp
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Example.Data;
using Example.Data.Models;
using Example.Data.Models.Interfaces;
```

If you're using "using" for context definition, it has free usage and doesn't have any direct restrictions in code relative DIRECTLY to it (meaning, rules for brackets and etc. still apply).
### Namespaces

Namespaces must be defined in one line after "usings", and therefore, without brackets, example:

```csharp
namespace Example;

...
```

Namespaces must be also typed in "SequenceCase" as any generalizing object in .NET, meaning:

```csharp
namespace PostgreSQL;

...
```

### Methods and functions

Methods and functions naming works under the terms of "SequeSCAL" and works in the context of the code and common view of it.

Private methods/functions can be named in "snake_case", if method/function is not part of public API, but also not private (`internal` and etc.), use "\_SequeSCAL"

Private system functions, that created for "closed compact situtations of code", must be in "SequeSCAL_{id}".

Every private static method/function must start `sv_`

### Variables

- Public variables must be in "SequeSCAL" and only in "SequeSCAL".
- Private variables must be in "\_pascalCase"
	- Any static field must be started with `s_`
	- Any thread static field must be started with `t_`
- Internal variables must be in "pascalCase" and start with `i_`
- Local variables (like when you create local variable for function, constructor and etc.) in "sneak_case"
- Local temp variables must be typed in "sneak_case" and start with `tmp_`
- Const variables must be written in upper case;
### Accessors

- You must use `readonly` only with private variables if it is readonly;
- You must use `=> ...` everytime with public accessor to private readonly variable;
	- If public field returns everytime only one instance/value (like `IsFalse => true`), also use `=>`
- For any field priorite auto-declarations (`{ get; set; }`) and only in one line and must be in one-step without throwing exceptions;
	- If you combine two different "get-set" (`get; internal set;`), use `get => ...; internal set { ... }`
### Variables - type

It is unrecommended, but it is not restricted to use BCL types instead of language keywords (string, bool, long instead of String, Boolean, Int64), one common example where BCL type is good use provided:

```csharp
public class Singleton : Singleton<Object>
{
	...
}

public class Singleton<T>
{
	...
}
```

Except using "var" even in local fields, `var` is allowed only for temp local variables within commentary about it.

Order of types: `public,private,protected,internal,static,extern,new,virtual,abstract,sealed,override,readonly,unsafe,volatile,async`
### Generics

Generic types have multiple complex rules:
- If it is key-value use `TKey, TValue` and only them
- If it is one variable-one type, use `T`:
	- if two, use `K, V`
	- if three, use `K, V, U`
- In case of "cloning" or having multiple generic type representing common purpose variables (for example, in class for just containing pairs and etc.), add numerization to the generic params in every rule setted above (`T1, T2`, `TKey1, TValue1, TKey2...`)

When declaring generic fields anywhere, always assign them with "default" at the declaring (`T value = default`), don't do this only if you already value to assign (assign value instead)
### Tab-lining

This guideline moves its style toward philosophy of "tab-lining", meaning code lines, code blocks and etc. tries to create a view composition when multiple lines and blocks ends/starts/splits with the same position, example provided:

```csharp
public class Singleton<T> : IData, IEquatable<Singleton<T>>,

                            IEqualityComparer<Singleton<T>>

{
	public static bool operator ==(Singleton<T>? singleton1,
								   Singleton<T>? singleton2)
	{
		...
	}
}
```

This rule of "tab-lining" applied to every space of code and applied to every possible code, creating a compact "packed" code in short space in terms of length, by sacrificing amount of lines.

### Rule of "ladder"

Rule of ladder defines, that functions, methods, usings, classes, namespaces and code must be create commin view like "ladder", for example:

> Commentary: keeping methods, constructors and other code blocks of same parameters (either two constructors from tuples) together is more important than rule of "ladder"

```csharp
using System;
using System.Text;

using Example.Data;
using Example.Data.Arrays;

namespace Example.Logic;

public class Logics
{
	public Logics(string name)
	{
		...
	}
	
	public Logics(string name, int iq)
	{
		...
	}

	public Logics(string name, int iq, bool alive)
	{
		...
	}
}
```
### Classes

Classed must be named in "SequeSCAL" and only in it.

### Classes - constructors

Constructors must be group by order of the fields they use and also apply to "ladder rule".

- When required, use `: base(...)`
- Always try to compact constructors and use correspondive `: this(...)`
	- in case of override class from parent class, when writing one within new parameters, assign new parameters first and then parameters for old constructors and always use new parameters, example:

```csharp
public class Logics
{
	public Logics(string name)
	{
		...
	}
	
	public void Think(int iq) => ...
}

public class Logics<T> : Logics
{
	public T? Thought { get; set; } = default;

	public Logics(T? thought, string name) : this(name)
	{
		...
	}

	public void Think(T? thought, string name)
	{
		...
	}
}
```

### One class - different namespaces

In this case, keep the name the same (until extreme cases) and always type namespace of each class, example:

```csharp
// namespace Example

public class Example.Broker
{
	...
}

// namespace Example.Sub

public class Example.Sub.Broker
{
	...
}
```
### Using "unchecked"

Use `unchecked` case only for extreme cases (int calcs) and everytime you override `GetHashCode()` and write your own calculations for hash instead of using hashes from different objects/base.
### Interfaces

When naming interfaces, just like with classes, use "SequeSCAL", but name interfaces starting with "I" (`IData`, `IBroker`).

- If you want to write interface for "just template"/"just common instance" situations, start naming with "T" (`TData, TBroker`)

### switch-default

Default case must always be at the start of switch-sequences.

### switch-case

Switch-sequence must always form "recursive ladder" and be short, if code starts to look complext (more than ~5-6 semifull lines), compact this code into "private system" function and use it.

### Exceptions

Always provide exceptions either with message or inner exception.

### Inheritance order

When using inheritance, order of modules from which inheritance is made is:
- `System->Predefined (Packages)->Custom`

### Attributes

Try to avoid attribute spam attributes to fields and etc., try to assign one attribute to one line if it can be compacted.

### Enums

Enums always must be named in one word, otherwise it's bad smell code scenario, every value of enum must be in upper case.
- Try to always use `uint, ulong` and other unsigned numbers in enums.
- If you have complex logic behind enums (IDs, enums for requests and etc.), always assign number values;
- If you start from negative (and/or signed numbers), always assign number values.

### Converters

When you write converters to `long`, `string` and other types, use BCL types to define (`ToInt64`, `ToString` and etc.)

When you're converting one object to other one (`GigaExample1` -> `GigaExample2`), use their different in naming and mark converting method as difference in names, for example:
- `Example->GigaExample` = `Example.ToGiga()`

## Documentation

When documenting .NET code, you are writing commentaries in XML format, so therefore, this block is add-on to:
- https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
- https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/specifications

### Common rules

- Tags and their contents must be on different lines, example:

```xml
/// <summary>
/// This method changes the point's location by the given x- and y-offsets.
/// <example>
/// For example:
/// <code>
/// Point p = new Point(3,5);
/// p.Translate(-1,3);
/// </code>
/// results in <c>p</c>'s having the value (2,8).
/// </example>
/// </summary>
```
- **Only exception to this rules, are alternatives to special symbols in markdown for XML commentaries**: like "\`" -> `<c>` (spec. D3.3) and etc.
- XML commentaries MUST NOT end on special symbols;
- XML commentaries MUST NOT contain unformatted unspecificated code;
- XML commentaries must always give either direct explanation of what does entity does/represents and etc. or give link to the advanced documentation.
- Commentaries always must say what type of this entity is (what is that entity) for clarifications and assigning with specifications of C#.
- Every instance comment (field, class, property) must start with "A"/"An" for common reference of the type;
	- BAD DOCS SMELL: in extreme cases it is allowed to write "The", but it must be tagged as "BDS" and be marked.
- Method, functions doesn't apply to rule above.
- References of code, references to the class/objects are applied to Common Codestyle (spec. "Code" of current docs);

```xml
<summary>
An unsigned 32-bit integer value which represents ID of user
</summary>
```
```csharp
public uint ID => _id;
```
### Classes

- Must have `A class which represents an instance for` + what class represents;
	- "Of"/"for" differs between acting of the class, example:
		- If class is just representation for already written class, use `of` and specify instance (example: custom exception with spec. `<see cref="Exception"/>`)
		- Otherwise, use `for` for anything
- if class is representation of another one in a specific case (for example, generic subtype of type, like with `Stack<T>` and `Stack<object>` in .NET), specify, like in this example:

```xml
/// <summary>
/// A non-generic dynamic representation of <see cref="Jenga{T}"/> which holds <see cref="Object"/> as it's primary type
/// </summary>
```
```csharp
public sealed class Jenga : Jenga<object> { ... }
```
```xml
/// <summary>
/// A class which represents an unique array data structure reminiscent of the structure of the same name
/// </summary>
/// <typeparam name="T">
/// A generic type which defines type of value which array structure will storage as it's values
/// </typeparam>
```
```csharp
public class Jenga<T> : ICollection<T>, ICloneable { ... }
```
#### Constructors

Constructors have 3-sided notation formula:

- for public constructors, just type 
	- `Instance constructor for the class`
- for empty "init" constructors (`public ClassConstr() {}`), type 
	- `Instance init of the class constructor
- for private constructors, just type 
	- `Private init constructor for the instance of class`
### Fields, properties (XML)

Variables documentation have multiple layers of complexity:

- Public fields of private fields must inherit documentation from private fields they are accessing data from (use `<inheritdoc>`)
- Private fields also must have full written documentation even if they are not part of public API ecosystem;
- Fields/properties change behaviour of their documentation from type correspondive from this table:

|   Type    | .NET/BCL type | Doc specification                                               |
| :-------: | :-----------: | :-------------------------------------------------------------- |
|  `bool`   |    Boolean    | Boolean parameter which indicates whether/represents\* ...      |
|  `byte`   |     Byte      | An unsigned 8-bit integer value which represents...             |
|  `sbyte`  |     SByte     | A signed 8-bit integer value which represents...                |
|  `char`   |     Char      | A character unit which represents                               |
| `decimal` |    Decimal    | A decimal floating-point number which represents...             |
| `double`  |    Double     | A double-precision floating-point number which represents...    |
|  `float`  |    Single     | A single-precision floating-point number which represents...    |
|   `int`   |     Int32     | A signed 32-bit integer value which represents...               |
|  `uint`   |    UInt32     | An unsigned 32-bit integer value which represents...            |
|  `nint`   |    IntPtr     | A signed pointerbit-width integer value which represents...\*\* |
|  `nuint`  |    UIntPtr    | An usigned pointerbit-width integer value which represents...   |
|  `long`   |     Int64     | A signed 64-bit integer value which represents...               |
|  `ulong`  |    UInt64     | An unsigned 64-bit integer value which represents...            |
|  `short`  |     Int16     | A signed 16-bit integer value which represents...               |
| `ushort`  |    UInt16     | An unsigned 16-bit integer value which represents...            |
\*- different between two status are pure logic/illogical functionalities, if boolean parameter represents field like `is_async`, use represents + `status of ...`, otherwise indicates (logic `=>`);
\*\*- https://learn.microsoft.com/en-us/dotnet/api/system.intptr?view=net-8.0

**Reference-type specifications:**

| Type | .NET/BCL type | Doc specification |
| :--: | :--: | :--- |
| `object` | Object | An object which represents... |
| `string` | String | String parameter of charseq* whihc represents... |
| `dynamic` | Object | Dynamic type-object which represents... |
\*- the reference to character sequence is referring to the idea of string inside the C#, must enter because of the specifications;

**Not-built-in:**

| Type | .NET/BCL type | Doc specification |
| :--: | :--: | :--- |
| Class/interface/etc | `{Object}`(none)  | An instance of a class/interface/etc `<see cref="CLASS SPEC."/>` which represents...* |
| Generic | `{T}` (none) | A generic type <typeparamref name="T"/> value representing ... |
\*- always use correspondive references, for example: `Dictionary<int, string>` -> `<see cref="Dictionary{TKey, TValue}"/>`;

#### Clarifications

- When referring to classes, interfaces and etc., you MUST NOT treat them as objects in any case.
- When referring to delegates, type the "parent-method" in tag `see`
- Do not clarify `cref` when referencing reference-types;
- In one class, all generic types must have patternized familliar code-docs from specifications inside the class (direct example: generic types from class comment to methods share same doc);
- Internal fields/properties must start with `Intern` and remove `a/an/the` from the introduction of the field;
- Private fields/properties must start with `Static` and remove `a/an/the` from the introduction of the field;
- Unmanaged fields/properties must start with `Unmanaged` and remove `a/an/the` from the introduction of the field;
### Exceptions

Any exception as thrown object from any codeblock is shown in API docs via
```xml
<exception cref="{ExceptionRef}">
</exception>
```

You must always declare exceptions in codeblocks which are thrown them and type what causes them with the same message that exception contains:

```xml
<exception cref="{ExceptionRef}">
Thrown when /{exception message}/
</exception>
```

### Enums

Enum has mixed specification because of its integral nature:
- When documenting enum in its declaration, use this pattern: `An enum of {INTEGRAL TYPE, see specs.} which represents`;
- For values of enum, write commentaries: `Predefined value of enum which represents ...`
### Methods/functions/tasks

- Methods must start with `Method which [ACTION in Present]`
- Tasks must start with `Task which [ACTION in Present]`
- If methods, tasks, functions are async or unsafe, add as the start:
	- Async: `Async method/task which [ACTION in Present]`
	- Unsafe: `Unsafe method/task which [ACTION in Present]`
	- Unchecked: `Unchecked method/task which [ACTION in Present]
- If methods, tasks, functions are override, add after the "type" of action: `override`
	- `Method override which ...`
- Functions are more complex because they are return values, so:
	- Start with `Function which [ACTION in -ING]` + (in terms of common idea) `and returns...`
	- In block `<returns>` you clarify return data as field (see fields/properties specs.);
- Delegate parents must be assured as it is: `Delegate parent which represents [GROUP OF ACTION]`
- Operators must be writte
#### Values in methods

- Values in methods must behave like fields or properties;
	- MEANING: always define type;
	- MEANING: always give direct representation;
	- MUST: always try to inherit documentation (`<inheritdoc`) for values;

### Arrays, ranges, matrixes

- Arrays of fields (`Array<T>` or `T[]` equally) or etc., must start and create construct of docs like this:
	`An array of {FIELD SPECS.} which represents...`
- Custom ranges and etc., simillarly:
	`Range of {FIELD SPECS.} which represents...`
- Matrixes (default):
	`Matrix by [{AxB}] which represents...`
- Matrix (custom):
	`Matrix of custom {FIELD SPECS.} by [{AxB}] which represents...`



## Common commentaries

Convention of this also checks the styling of common commentaries, there are global rules for them:

- Comments MUST share same rules with Code of Conduct (if it exists);
- Comments MUST also share the rules and applications of code guideline (rule of ladder and tablining);
- Comments MUST NOT include code in them;
- For marking lines, use Github's line marking system (`L#53` and etc.)
- For marking codeblocks, you can mark it two ways:
	- `L#53->L#64` (range of lines, hard-set)
	- Generate tag with special marker and assign it later, example:

```csharp
/* [TO-DO]: @G34
...


/* [MARK]: @G34
```

- For marking classes, specify with tag `see cref={CLASS}`;
### First-liners

First-liners commentaries are reserved for two purposes:
1. Defining licenses: author's distribution license and .NET foundation reference;
2. Author's copyright (MIT)

First-liners are head of the file and written by "/\*" with multilining by "\*".

See the reference for .NET Foundation here: https://dotnet.microsoft.com/en-us/platform/free
### Usage of "//"

One-line commentaries are reserved for system/pragma commentaries, or indirect commentaries within systematic specification, example:

```csharp
// Updating REGISTRY: 0x0007f84e
...

// CS0886
...

// @lint-expect-exception
```

### Usage of "/\*"

"Star-aligned" commentaries are the most common commentaries, they are used most of the time, but there are some rules about them:
1. Always split long sentences, follow the tab-lining and ladder rules;
2. They are always end by dot;
3. They can contain links, references and etc., but no author ref, systematic messages or code;

- One-line star-commentaries are used often between "if-statements" and etc., also they are used for commenting temp and local variables.
- Multi-lined commentaries used everywhere.
### Usage of "//\*"

This "JSDocs" commentaries are used for referencing someone's other codeblock, that are used in your project, by the same tags from JSDocs you specify from who, under what license.

```csharp
//* [REF]:
	@author name
	@license mit
	@year 2023-2024
  *//
```

### Specifications of tags

There are multiple tags for different situtation for your project:

| Tag | Comment's usage | Meaning | Example |
| :--: | :--: | :--- | ---- |
| `[+]:`/`[TO-DO]` | Everywhere | Tag for work to-do (it is recommended to specify which lines/block/class and etc.) | `/* [+]: Implement magic. */` |
| `[&]:`/`[DEBUG]:` | `/*` and `//` | Debug code/line, case | `// [&]: Don't touch.` |
| `[#]:`/`[PROD]:` | Everywhere | Goes to production (release) | ... |
| `[SEEK]:`/`[?]:` | Everywhere | Commentary with just link (for ref) | ... |
| `[REFACTOR]:`/`[*]:` | Everywhere | Refactoring tag, requires lines/block/class to refer. | ... |
| `[REF]:`/`[>]:` | `//*` | Refercing to author. | check prev. specs |
| `[MARK]:`/`[^]` | Everywhere | Special marking for other tags. | ... |
| `[!]:`/`[MUST]:` | `/*` and `//` | Important comment | `/* [!]: SECURITY ISSUE` |
