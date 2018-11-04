namespace CSharpLab1
{
    public class TeamListHandlerEventArgs : System.EventArgs
    {
        public string NameOfCollection { get; set; }
        public string TypeOfChange { get; set; }
        public int IndexOfElement { get; set; }

        public TeamListHandlerEventArgs(string name,string change,int index)
        {
            NameOfCollection = name;
            TypeOfChange = change;
            IndexOfElement = index;
        }
        public override string ToString()
        {
            return $"\nCollection : {NameOfCollection}\n" +
                   $"Type of change : {TypeOfChange}\n" +
                   $"Index of element : {IndexOfElement}";
        }
    }
}
