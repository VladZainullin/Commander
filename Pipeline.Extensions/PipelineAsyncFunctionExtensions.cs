namespace Pipeline.Extensions;

public static class PipelineAsyncFunctionExtensions
{
    public static async Task<TResult> PipeTo<T, TResult>(
        this T arg,
        Func<T, Task<TResult>> func)
    {
        return await func(arg);
    }
    
    public static async Task<TResult> PipeTo<T1, T2, TResult>(
        this T1 arg1,
        Func<T1, T2, Task<TResult>> func,
        T2 arg2)
    {
        return await func(arg1, arg2);
    }
    
    public static async Task<TResult> PipeTo<T1, T2, T3, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, Task<TResult>> func,
        T2 arg2,
        T3 arg3)
    {
        return await func(arg1, arg2, arg3);
    }
    
    public static async Task<TResult> PipeTo<T1, T2, T3, T4, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, T4, Task<TResult>> func,
        T2 arg2,
        T3 arg3,
        T4 arg4)
    {
        return await func(arg1, arg2, arg3, arg4);
    }
    
    public static async Task<TResult> PipeTo<T1, T2, T3, T4, T5, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, Task<TResult>> func,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5)
    {
        return await func(arg1, arg2, arg3, arg4, arg5);
    }
    
    public static async Task<TResult> PipeTo<T1, T2, T3, T4, T5, T6, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, T6, Task<TResult>> func,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6)
    {
        return await func(arg1, arg2, arg3, arg4, arg5, arg6);
    }
    
    public static async Task<TResult> PipeTo<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>> func,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7)
    {
        return await func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }
}