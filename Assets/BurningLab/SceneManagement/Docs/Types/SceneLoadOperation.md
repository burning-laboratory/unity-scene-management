# Scene Load Operation

Wrapper for information about uploaded scenes. It also contains a method for controlling the activation of a scene or a group of scenes.

### Public properties

- **-** **`Loading Progress (float)`** - The progress of loading the scene.

- **-** **`Is Done (bool)`** - Flag for the completion of loading scenes.

### Public Methods

- **-** **`RegisterSceneLoadAsyncOperation(SceneData sceneData, AsyncOperation loadOperation)`** **`void`** - Adds a local scene loading operation to the wrapper.

- **-** **`RegisterSceneLoadAsyncOperationHandle(SceneData sceneData, AsyncOperationHandle<SceneInstance> loadOperation)`** **`void`** - Adds the operation of loading the addressable scene into the wrapper.

- **-** **`ActivateScenes`** **`void`** - Enables auto-activation of scenes.

### Developer contacts:

**Email - [n.fridman@burning-lab.com](mailto://n.fridman@burning-lab.com)**