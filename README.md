# unity-workflow-improvements
 A repo for testing, implementing, and deploying improvements for Unity development

### How to use the AutoDisable gameobject scene:
- Upon opening the project you'll find a RuntimeScript.cs  file in the Editor folder.
- The script will look for every gameobject tagged as `EditorOnly` and disable before building.
- Hence, you need to ensure that the gameobject is tagged under `EditorOnly` . You could also create your own tag and change the tag in the script as well.
- When all these steps are followed you'll find that once the build is completed all the tagged gameobjects will have been disabled.
- **Please Note:** I haven't worked on the provision to auto-enable it post the build completes, I'm yet to learn how to do that via script.

I hope these pointers help with usage of the build, do let me know if you require anything else from my side I'll be sure to look into it! 
