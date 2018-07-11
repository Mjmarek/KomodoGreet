namespace KomodoGreet.Contracts
{
    public interface IConsole
    {
        void Write(string message);
        void WriteLine(string message);
        void WriteLine(object o);
        string ReadLine();
        void Clear();
    }
}