using GameOOPLife;

int generationCounter = 0;

string spawnMode = "custom"; // options: "custom", "random"

// game speed
double fps = 15;
double sleepTimer = 1000 / fps;

// configuration for the map
bool doBordersExist = false;
int rowLength = 160;
int colLength = 40;
int generationSize = rowLength * colLength;

// configuration for random spawn
int survivalPercantage = 12;

// configuration for custom spawn
string folderPathToForms = "C:\\Users\\yevgen.gugel\\source\\repos\\GameOOPLife\\GameOOPLife\\externalForms\\";

Overseer omni = spawnMode == "custom"
    ? new Overseer(doBordersExist, rowLength, generationSize, folderPathToForms)
    : new Overseer(doBordersExist, rowLength, generationSize, survivalPercantage);



while (true)
{
    var gen2d = new GenerationWrapper(omni.CurrentGeneration, omni.Rowlength);
    Screen.Show(gen2d, generationCounter);
    Thread.Sleep((int)sleepTimer);
    omni.ForwardCurrentGeneration();
    generationCounter++;
}