namespace Pipeline.Extensions;

public static class FunctionExtensions
{
    public static Func<T1, Func<T2, TResult>> Carry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
    {
        return t1 => t2 => func(t1, t2);
    }
    
    public static Func<T1, Func<T2, Func<T3, TResult>>> Carry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
    {
        return t1 => t2 => t3 => func(t1, t2, t3);
    }
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Carry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func)
    {
        return t1 => t2 => t3 => t4 => func(t1, t2, t3, t4);
    }
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> Carry<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func)
    {
        return t1 => t2 => t3 => t4 => t5 => func(t1, t2, t3, t4, t5);
    }
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> Carry<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func)
    {
        return t1 => t2 => t3 => t4 => t5 => t6 => func(t1, t2, t3, t4, t5, t6);
    }
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> Carry<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
    {
        return t1 => t2 => t3 => t4 => t5 => t6 => t7 => func(t1, t2, t3, t4, t5, t6, t7);
    }
}