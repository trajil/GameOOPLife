namespace GameOOPLife;

public class ExternalForm
{
    private string Name;

    public List<char> Form {  get; set; }
    public int FormWidth;
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
   
}