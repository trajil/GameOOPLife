using GameOOPLife;

int generationCounter = 0;


// game speed
double fps = 60;
double sleepTimer = 1000 / fps;

// configuration for the map
GenerationWrapper.DoBordersExist = false;
int rowLength = 160;
int colLength = 40;

// configuration for random spawn
int survivalPercantage = 12;

Overseer omni = new Overseer(rowLength, colLength);
// configuration for custom spawn
List<(string, int)> forms = new List<(string, int)>();
GenerationWrapper wrapper = new GenerationWrapper(omni.CurrentGeneration, rowLength);

//forms.Add(("simpleCell", wrapper.GetIndex(0,0)));
//forms.Add(("glider", wrapper.GetIndex(90, 3)));
//forms.Add(("octagon", wrapper.GetIndex(70, 5)));
forms.Add(("pulsator", wrapper.GetIndex(70, 5)));
//forms.Add(("tuemmler", wrapper.GetIndex(70, 25)));
forms.Add(("gosper_glider_gun", wrapper.GetIndex(0, 0)));
//forms.Add(("glider", wrapper.GetIndex(0, 0)));

foreach (var item in forms)
{
    omni.SpawnFormOnSpecificPlace(item.Item1, omni.CurrentGeneration, item.Item2);
}




omni.ReviveSomeRandomCells(survivalPercantage);
// spawn Forms


while (true)
{
    var gen2d = new GenerationWrapper(omni.CurrentGeneration, omni.RowLength);
    Screen.Show(gen2d, generationCounter);
    Thread.Sleep((int)sleepTimer);
    omni.ForwardCurrentGeneration();
    generationCounter++;
}