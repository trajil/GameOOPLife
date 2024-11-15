using GameOOPLife;

Overseer omni = new Overseer();
int generationCounter = 0;

while (true)
{
    omni.ForwardCurrentGeneration();
    var gen2d = new GenerationWrapper(omni.CurrentGeneration, omni.Rowlength);
    Screen.Show(gen2d, generationCounter);
    Thread.Sleep(100);
    generationCounter++;
}