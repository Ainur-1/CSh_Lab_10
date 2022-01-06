namespace CSh_Lab_10
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}