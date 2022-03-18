/// <summary>
/// This class describes all properties of a single input that an input buffer needs to know.
/// </summary>
public class Input
{
    public enum Type { JUMP, DASH };
    
    private int age;
    public int Age
    { get; }

    private Type inputType;
    public Type InputType
    { get; set; }


    public Input(Type type)
    {
        age = 0;
        inputType = type;
    }

    public void incrementAge()
    {
        age++;
    }
}
