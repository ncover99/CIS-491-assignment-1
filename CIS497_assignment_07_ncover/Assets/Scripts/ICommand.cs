/*
* Nathan Cover
* ICommand.cs
* assignment 7
* Interface for commands
*/

namespace Assets.Scripts.Assignment_07
{

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

}
