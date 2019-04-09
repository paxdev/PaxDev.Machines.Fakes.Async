# Overview

`PaxDev.Machine.Fakes.Async` is a library to help reduce boiler plate 
code associated with using `Machine.Fakes` method mocking with `Task<T>`.

To use simply reference the NuGet package and then write code like the following:

```csharp
public interface ITestInterface
{
    Task<string> MethodWithTwoParameters(string parameter1, int parameter2);
}

public class When_testing_a_method_that_returns_a_task : WithFakes
{
    Establish context = () =>
        The<ITestInterface>()
            .WhenToldTo(d => d.MethodWithTwoParameters(Param<string>.IsAnything, Param<int>.IsAnything))
            .ReturnAsync((string s, int i) => DoFunction(s, i));

    static string DoFunction(string s, int i) => $"Do something with {s} and {i}";
}
``` 

You can, of course, inline the function declaration. Under the hood, the library
will create a `CompletedTask` with the value of the function / return value.

This has an additional benefit when the `Result` type is polymorphic. .Net is able
to infer the correct `Task<T>` from the method signature and cast the `Result` to the 
correct type.
