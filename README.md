
# SimplePrefs

--DESCRIPTION

Asset for Unity.Simplifies working with PlayerPrefs. You no longer need to monitor the life cycle of PlayerPrefs, you do not need to create and store constants to access PlayersPrefs.This asset will do everything for you.

--HOW IT WORKS

 When the game starts, variables marked with the [PrefsSaver] or [PrefsSaver (obj)] attribute will be automatically initialized with the saved values. When the game is turned off, the variables will be saved in PlayersPrefs automatically.
 
 --HOW TO USE IT

SimplePrefs can save int,float and string types variables.

1)To use, you need to connect  VzapertiStudio namespace - use using VzapertiStudio;


<img width="342" alt="Снимок экрана 2021-08-27 в 20 58 57" src="https://user-images.githubusercontent.com/67166773/131169638-63af5ef9-3452-47f3-80ca-4d50b6b402df.png">

2)Аfter that it is necessary to mark the required variable with the attribute  [PrefsSaver] or  [PrefsSaver(arg)] (different in next descritpion)

<img width="342" alt="Снимок экрана 2021-08-27 в 21 02 22" src="https://user-images.githubusercontent.com/67166773/131169979-c01cccbd-d774-40b7-b1b3-337427d1a4d3.png">

<img width="342" alt="Снимок экрана 2021-08-27 в 21 02 00" src="https://user-images.githubusercontent.com/67166773/131170030-1e63c00d-34f1-4bac-83c7-ceb88233284c.png">

