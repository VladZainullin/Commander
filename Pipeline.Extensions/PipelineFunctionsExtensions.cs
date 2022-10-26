namespace Pipeline.Extensions;

public static class PipelineFunctionsExtensions
{
    public static TResult PipeTo<T, TResult>(
        this T arg,
        Func<T, TResult> func)
    {
        return func(arg);
    }
    
    public static TResult PipeTo<T1, T2, TResult>(
        this T1 arg1,
        Func<T1, T2, TResult> func,
        T2 arg2)
    {
        return func(arg1, arg2);
    }
    
    public static TResult PipeTo<T1, T2, T3, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, TResult> func,
        T2 arg2,
        T3 arg3)
    {
        return func(arg1, arg2, arg3);
    }
    
    public static TResult PipeTo<T1, T2, T3, T4, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, T4, TResult> func,
        T2 arg2,
        T3 arg3,
        T4 arg4)
    {
        return func(arg1, arg2, arg3, arg4);
    }
    
    public static TResult PipeTo<T1, T2, T3, T4, T5, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, TResult> func,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5)
    {
        return func(arg1, arg2, arg3, arg4, arg5);
    }
    
    public static TResult PipeTo<T1, T2, T3, T4, T5, T6, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, T6, TResult> func,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6)
    {
        return func(arg1, arg2, arg3, arg4, arg5, arg6);
    }
    
    public static TResult PipeTo<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this T1 arg1,
        Func<T1, T2, T3, T4, T5, T6, T7, TResult> func,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7)
    {
        return func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }
}