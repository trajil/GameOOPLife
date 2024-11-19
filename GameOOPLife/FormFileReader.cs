namespace GameOOPLife;

public class FormFileReader
{
    public string FileContent;
    public List<char> Form;
    public int FormWidth;
    public FormFileReader(string name, char alive, char dead)
    {
        this.FileContent = File.ReadAllText(name);
        this.Form = GetForm(alive, dead);
        this.FormWidth = GetFormWidth();
    }

    public int GetFormWidth()
    {
        string number = "";

        foreach (var element in FileContent)
        {
            if (char.IsDigit(element))
            {
                number += element;
            }
            else if (!string.IsNullOrEmpty(number))
            {
                break;
            }
        }

        return !string.IsNullOrEmpty(number) ? int.Parse(number) : 0;
    }

    public List<char> GetForm(char alive, char dead)
    {
        List<char> result = [];
        foreach (var element in FileContent)
        {
            if (element == alive)
            {
                result.Add(element);
            }
            else if (element == dead)
            {
                result.Add(element);
            }
        }
        return result;
    }
}
