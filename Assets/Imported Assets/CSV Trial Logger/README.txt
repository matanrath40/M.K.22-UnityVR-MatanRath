Allows simple .csv logging of data for research/QA.
Logging is done on a 'trial' basis, where each row of the output is a different trial.
Each measurement point is a different column ('long format')
By default, this asset logs trial number, participant ID, trial start and end time. Time is relative to the start.
Data is logged to StreamingAssets, which is accessible from the game folder (even when built)
https://docs.unity3d.com/Manual/StreamingAssets.html


Instructions to use:

1. Open the example scene to get familiar with the different components.
2. In your own scene, if you don't have one create an empty GameObject which will control your experiment
3. Add the TrialLogger script to this GameObject.

You can now use the public methods and properties of the TrialLogger class elsewhere in your system. Check the "ExampleExperimentController" on the "Experiment" GameObject in the Example Scene for tips.

You will need to run the Initialize public method to start the logging - here is where you can add custom columns to your output.
Basically, you need to call the public methods "StartTrial" and "EndTrial" when you define the trial to have started and ended respectively.
During the trial, you can set your custom datapoints (as strings) in the "trial" dictionary (a public property of TrialLogger).
The default columns will be logged automatically.

The .csv file will be closed automatically and saved when the game is exited.
