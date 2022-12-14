namespace Pipeline.Extensions;

public static class PipelineActionExtensions
{
    public static void PipeTo<T>(
        this T arg,
        Action<T> action)
    {
        action(arg);
    }
    
    public static void PipeTo<T1, T2>(
        this T1 arg1,
        Action<T1, T2> action,
        T2 arg2)
    {
        action(arg1, arg2);
    }
    
    public static void PipeTo<T1, T2, T3>(
        this T1 arg1,
        Action<T1, T2, T3> action,
        T2 arg2,
        T3 arg3)
    {
        action(arg1, arg2, arg3);
    }
    
    public static void PipeTo<T1, T2, T3, T4>(
        this T1 arg1,
        Action<T1, T2, T3, T4> action,
        T2 arg2,
        T3 arg3,
        T4 arg4)
    {
        action(arg1, arg2, arg3, arg4);
    }
    
    public static void PipeTo<T1, T2, T3, T4, T5>(
        this T1 arg1,
        Action<T1, T2, T3, T4, T5> action,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5)
    {
        action(arg1, arg2, arg3, arg4, arg5);
    }
    
    public static void PipeTo<T1, T2, T3, T4, T5, T6>(
        this T1 arg1,
        Action<T1, T2, T3, T4, T5, T6> action,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6)
    {
        action(arg1, arg2, arg3, arg4, arg5, arg6);
    }
    
    public static void PipeTo<T1, T2, T3, T4, T5, T6, T7>(
        this T1 arg1,
        Action<T1, T2, T3, T4, T5, T6, T7> action,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7)
    {
        action(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }
}