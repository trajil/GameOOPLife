using GameOOPLife;

int generationCounter = 0;


// game speed
double fps = 60;
double sleepTimer = 1000 / fps;

// configuration for the map
GenerationWrapper.DoBordersExist = false;
int rowLength = 160;
int colLength = 40;
int generationSize = rowLength * colLength;

// configuration for random spawn
int survivalPercantage = 12;

// configuration for custom spawn
string folderPathToForms = "C:\\Users\\yevgen.gugel\\source\\repos\\GameOOPLife\\GameOOPLife\\externalForms\\";

Overseer omni = new Overseer(rowLength, generationSize);

omni.ReviveSomeRandomCells(survivalPercantage);
// spawn Forms


while (true)
{
    var gen2d = new GenerationWrapper(omni.CurrentGeneration, omni.Rowlength);
    Screen.Show(gen2d, generationCounter);
    Thread.Sleep((int)sleepTimer);
    omni.ForwardCurrentGeneration();
    generationCounter++;
}