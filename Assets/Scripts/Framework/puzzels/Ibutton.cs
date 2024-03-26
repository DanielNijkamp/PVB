using UnityEngine.Events;
/// <summary>
/// this interface will handle all the button behaviours 
/// </summary>
/// <typeparam name="T"> can be any type</typeparam>
public interface Ibutton<T>
{
    public T buttonValue { get; set; } 
    public UnityEvent<T> onActivate { get; }

    
}
