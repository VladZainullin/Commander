namespace Pipeline.Extensions;

public static class PipelineAsyncActionExtensions
{
    public static async Task PipeTo<T>(
        this T arg,
        Func<T, Task> action)
    {
        await action(arg);
    }
    
    public static async Task PipeTo<T1, T2>(
        this T1 arg1,
        Func<T1, T2, Task> action,
        T2 arg2)
    {
        await action(arg1, arg2);
    }
    
    public static async Task PipeTo<T1, T2, T3>(
        this T1 arg1,
        Func<T1, T2, T3, Task> action,
        T2 arg2,
        T3 arg3)
    {
        await action(arg1, arg2, arg3);
    }
    
    public static async Task PipeTo<T1, T2, T3, T4>(
        this T1 arg1,
        Func<T1, T2, T3, T4, Task> action,
        T2 arg2,
        T3 arg3,
        T4 arg4)
    {
        await action(arg1, arg2, arg3, arg4);
    }
    
    public static async Task PipeTo<T1, T2, T3, T4, T5>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, Task> action,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5)
    {
        await action(arg1, arg2, arg3, arg4, arg5);
    }
    
    public static async Task PipeTo<T1, T2, T3, T4, T5, T6>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, T6, Task> action,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6)
    {
        await action(arg1, arg2, arg3, arg4, arg5, arg6);
    }
    
    public static async Task PipeTo<T1, T2, T3, T4, T5, T6, T7>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, T6, T7, Task> action,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7)
    {
        await action(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }
}