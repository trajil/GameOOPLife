namespace GameOOPLife;

public class FormFileReader
{
    public string FileContent;
    public int FormWidth;
    
    private string FolderPathToForms = "C:\\Users\\yevgen.gugel\\source\\repos\\GameOOPLife\\GameOOPLife\\externalForms\\";
    private string FormNameExtension = ".txt";


    public FormFileReader(string fileName)
    {
        var fullFileNameWithFolderPath = FolderPathToForms + fileName + FormNameExtension;
        this.FileContent = File.ReadAllText(fullFileNameWithFolderPath);
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

    public List<char> GetForm()
    {
        char alive = 'X';
        char dead = 'O';
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