using GameOOPLife;

Overseer omni = new Overseer(Settings.RowLength, Settings.ColLength);
GameMode.RunMode(omni,"custom");

int generationCounter = 0;
while (true)
{
    var gen2d = new GenerationWrapper(omni.CurrentGeneration, omni.RowLength);
    Screen.Show(gen2d, generationCounter);
    Thread.Sleep(Settings.GetSleepTimerFromFpsInput());
    omni.ForwardCurrentGeneration();
    generationCounter++;
}