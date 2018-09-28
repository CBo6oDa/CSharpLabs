namespace CSharpLab1.Interfaces
{
    public interface INameAndCopy
    {
        string Name
        {
            get;
            set;
        }
        object DeepCopy();
    }
}