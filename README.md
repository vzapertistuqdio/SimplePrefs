
# SimplePrefs

--DESCRIPTION

Asset for Unity.Simplifies working with PlayerPrefs. You no longer need to monitor the life cycle of PlayerPrefs, you do not need to create and store constants to access PlayersPrefs.This asset will do everything for you.

--HOW IT WORKS

 When the game starts, variables marked with the [PrefsSaver] or [PrefsSaver (obj)] attribute will be automatically initialized with the saved values. When the game is turned off, the variables will be saved in PlayersPrefs automatically.
 
 --HOW TO USE IT
 
To use, you need to connect  VzapertiStudio namespace - use using VzapertiStudio;


<img width="342" alt="Снимок экрана 2021-08-27 в 20 58 57" src="https://user-images.githubusercontent.com/67166773/131169638-63af5ef9-3452-47f3-80ca-4d50b6b402df.png">

1) PREFS SAVER

It is necessary to mark the required VARIABLE with the attribute  [PrefsSaver] or  [PrefsSaver(arg)] (different in next descritpion)

<img width="342" alt="Снимок экрана 2021-08-27 в 21 02 22" src="https://user-images.githubusercontent.com/67166773/131169979-c01cccbd-d774-40b7-b1b3-337427d1a4d3.png">

<img width="342" alt="Снимок экрана 2021-08-27 в 21 02 00" src="https://user-images.githubusercontent.com/67166773/131170030-1e63c00d-34f1-4bac-83c7-ceb88233284c.png">

2) ROTATION AND POSITION SAVERS

It is necessary to mark the required CLASS with the attribute [PositionSave] for save postion and [RotationSave] for save rotation.

<img width="538" alt="Снимок экрана 2021-10-21 в 20 36 17" src="https://user-images.githubusercontent.com/67166773/138328744-13f373d8-7424-4563-a654-7bbb9ca3fa7e.png">

<img width="538" alt="Снимок экрана 2021-10-21 в 20 36 53" src="https://user-images.githubusercontent.com/67166773/138328830-c34ae6fe-df16-4ac7-aa7f-e83c08260199.png">

<img width="538" alt="Снимок экрана 2021-10-21 в 20 37 20" src="https://user-images.githubusercontent.com/67166773/138328876-e7cbbe8e-5e98-4c09-af24-ce8116ac59aa.png">

--OBJECTS WHICH SPAWN AFTER SCENE INITIALIZATION
If the object spawns after initializing the scene and needs the saved data, you can request it. Use this:

<img width="576" alt="Снимок экрана 2021-12-01 в 13 42 52" src="https://user-images.githubusercontent.com/67166773/144220268-32b6aade-ad28-45f6-a5bf-9995a88f4b7a.png">


--DIFFERENCE BETWEEN PREFS SAVER ATTRIBUTES  

If at the first start of the game the variable must be initialized, use this [PrefsSaver (initializedValue)],
in other cases use this [PrefsSaver] the variable will be initialized to the default value.

--IMPORTANT INFORMATION

1)SimplePrefs can save int,float and string types variables

2)If you need use the attribute for the first initialization like this

 <img width="342" alt="Снимок экрана 2021-08-27 в 21 13 23" src="https://user-images.githubusercontent.com/67166773/131171180-7a6aff10-5188-4801-9e9e-713c4f40b20a.png">
 
 but not like here
 
 <img width="342" alt="Снимок экрана 2021-08-27 в 21 14 48" src="https://user-images.githubusercontent.com/67166773/131171324-691aee6a-d6fb-498b-9694-5ffbde6bc32f.png">
 
3)You can disable SimplePrefs.On top panel press VzapertiStudio->SimplePrefsSetting and press on toggle

4)All classes that use attributes from SimplePrefs must have Monobehavior at the root of inheritance.

5)Please use different name for gameobjects which use PrefsSavers,because the save algorithm uses the name


