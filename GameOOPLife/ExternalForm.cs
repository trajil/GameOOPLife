namespace GameOOPLife;

public class ExternalForm
{
    public List<char> Form;
    public string Name;
    public int FormWidth;
    public ExternalForm(string name)
    {
        List<char> form = new List<char>();
    }

    public List<char> ReadFormFromFileReader(string formName)
    { 
        FormFileReader fr = new FormFileReader(formName);

        return Form;
    }
}