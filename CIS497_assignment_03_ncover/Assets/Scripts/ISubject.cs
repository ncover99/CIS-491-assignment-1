/*
 * Nathan Cover
 * ISubject.cs
 * Assignment_03
 * Interface for any object that wants to act as a subject to an observer
 */

namespace Assets.Scripts.Assignment_03
{

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }


}
