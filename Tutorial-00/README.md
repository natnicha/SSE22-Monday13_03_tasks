# SSE22-Monday13_03_tasks

# Tutorial 00 - Introduction to C#
## Task 1
The programming language of the tutorial is C#. Read any C#-Tutorial of your choice (e.g. [homeandlearn.co.uk](https://www.homeandlearn.co.uk/csharp/csharp_s1p1.html)) and create a simple "HelloWorld" console application using Visual Studio. Visual Studio Community can be downloaded from Microsoft. We do NOT recommend Visual Studio Code for the tutorial, as it does not provide support for .NET Framework features used later in the tutorial.


## Task 2
Answer the following questions briefly and accurately in your own words:

### 1. What are the responsibilities of the .NET Framework?

.NET framework is a software and also an implementation of .NET, which helps us to create, build and execute many types of applications on Windows. e.g., web applications, services, desktop apps etc. for many programming languages e.g. C#, F#.

### 2. What is common to C#, VB.NET, F# and J#?
All provided programming languages are supported by .NET Framework using Microsoft Visual Studio.


### 3. What are the Lambda-Expressions and LINQ?

#### Lambda-Expressions
A lambda expression is a short block of code which facilitates us to do something more quickly than the normal methods. It is like a method with no method name. So, it can complete within one line of code.
##### Lambda-Expressions Sample
```javascript
ad2 = (int a,int b)->{ return (a+b); }; 
```

#### LINQ 
LINQ (Language Integrated Query) is a library that extends powerful query capabilities in C# to query data of different types. LINQ can use query expressions, lambda expressions, extension methods, anonymous types, and various library functionalities.
##### LinQ with Lambda-Expressions Sample

```javascript
var numbers = new int[] {2, 7, 5, 9, 1, 5, 3, 0, 7, 6};
var count = numbers.Count( x => x==5 );
Console.WriteLine(count);
```
