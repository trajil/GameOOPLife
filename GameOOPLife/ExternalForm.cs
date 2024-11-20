namespace GameOOPLife;

public class ExternalForm
{
    private string Name;

    public List<char> Form { get; set; }
    private int FormWidth;
    public ExternalForm(string name)
    {
        this.Name = name;
        CreateForm();
    }

    public void CreateForm()
    {
        FormFileReader fr = new FormFileReader(Name);

        this.Form = fr.ExtractFormFromFileContent();
        this.FormWidth = fr.ExtractFormWidthFromFileContent();
    }

    public int GetFormWidth()
    {
        return this.FormWidth;
    }
}