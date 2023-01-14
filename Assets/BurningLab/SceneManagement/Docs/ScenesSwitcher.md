## Scenes Switcher

A component with logic for switching scenes.

### Settings:
- **-** **`Database (ScenesDatabase)`** - A link to an asset with a database of scenes.

- **-** **`Main Camera Handling (bool)`** - Enable this check box if you want to move the main camera to the active scene when loading scenes.

### Static fields
- **-** **`Instance (ScenesSwitcher)`** - Link to the scene switcher instance.


### Public fields
- **-** **`Loaded Scenes (List<SceneData>)`** - A list of currently loaded scenes.

- **-** **`Database (List<ScenesDatabase>)`** - Scenes database reference.

### Events:
- **-** **`On Scene Loaded (Action<SceneData>)`** - Called after loading the scene.

- **-** **`On Scene Unloaded (Action<SceneData>)`** - Called after unloading the scene.

### Methods:
- **-** **`UnloadScene(SceneData sceneData)`** **`void`** - Unloads the scene.

- **-** **`UnloadScene(string sceneName)`** **`void`** - Unloads the scene.

- **-** **`UnloadScene(int sceneBuildIndex)`** **`void`** - Unloads the scene.

- **-** **`LoadScene(SceneData sceneData)`** **`ScenesLoadOperation`** - Loads the scene.

- **-** **`LoadScene(string sceneName)`** **`ScenesLoadOperation`** - Loads the scene.

- **-** **`LoadScene(int sceneBuildIndex)`** **`ScenesLoadOperation`** - Loads the scene.

### Developer contacts:

**Email - [n.fridman@burning-lab.com](mailto://n.fridman@burning-lab.com)**
