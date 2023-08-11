<p align="center">
      <img src="https://i.ibb.co/9mDz5t6/Scene-Management-Git-Hub-Logo.png" alt="Project Logo" width="850">
</p>

<p align="center">
    <img src="https://build.burning-lab.com/app/rest/builds/buildType:id:UnityAssets_ComBurningLabScenemanagement_ProductionBuild/statusIcon.svg" alt="Build Status">
    <a href="https://burning-lab.youtrack.cloud/agiles/131-15/current"><img src="https://img.shields.io/badge/Roadmap-YouTrack-orange" alt="Roadmap Link"></a>
    <img src="https://img.shields.io/badge/Engine-{unity_version}-blueviolet" alt="Unity Version">
    <img src="https://img.shields.io/badge/Version-{package_version}-blue" alt="Game Version">
    <img src="https://img.shields.io/badge/License-MIT-success" alt="License">
</p>

## About

The main part of the system is asynchronous loading of scenes. Provides base classes and interfaces for implementing its own database of scenes, as well as components for loading/unloading scenes in groups.

## Installation

1. Add **Burning-Lab Registry** to Unity Project.
2. Add Open **UPM Registry** to Unity Project for importing external dependencies.
3. Install **Scene Management** package via Unity Package Manager.

**Burning-Lab Registry:**

```json
    {
      "name": "Burning-Lab Registry",
      "url": "https://packages.burning-lab.com",
      "scopes": [
        "com.burning-lab"
      ]
    }
```

**Open UPM Registry:**

```json
    {
      "name": "Open UPM Registry",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.mackysoft.serializereference-extensions"
      ]
    }
```

## Core components:

A list of the main components of the system.

### Interfaces:

A list of interfaces provided by the package.

#### Database:

A list of interfaces defining objects storing data for loading scenes.

* `ISceneData` - Interface defining methods for getting data about a scene in a project.
* `IScenesDatabase` - An interface defining the methods of the scene database in the project.
* `IScenesGroup` - Interface defining methods for getting data about a group of scenes.
* `IScenesGroupDatabase` - Interface defining methods for interacting with the database of group scenes in the project.
* `IScenesManagementConfiguration` - An interface defining methods for interacting with the configuration object of the scene management system.

#### References:

* `ISceneDataReference` - An interface defining methods for getting a reference to an interface implementation `ISceneData`.
* `IScenesGroupReference` - An interface defining methods for getting a reference to an interface implementation `IScenesGroup`.

#### Providers:

* `IScenesDatabaseProvider` - An interface defining methods for getting a reference to an interface implementation `IScenesDatabase`.
* `IScenesGroupDatabaseProvider` - An interface defining methods for getting a reference to an interface implementation `IScenesGroupDatabase`.
* `IScenesManagementConfigurationProvider` - An interface defining methods for getting a reference to an interface implementation `IScenesManagementConfiguration`.

## Extensions:

You can see examples of interface implementations in the package examples or in extensions.

* [**SM Local Scenes Database Extension**](https://packages.burning-lab.com/-/web/detail/com.burning-lab.scenesmanagement.extension.localscenesdatabase) - An extension that provides an implementation of the scene database in the form `ScriptableObject` objects.
* [**SM Remote Scenes Database Extension**](https://packages.burning-lab.com/-/web/detail/com.burning-lab.scenesmanagement.extension.remotescenesdatabase) - An extension that provides the implementation of a database of scenes in the form of databases managed by a package [**Remote Database**](). (Burning-Lab SDK access required).

## Distribute

* [packages.burning-lab.com](https://packages.burning-lab.com/-/web/detail/com.burning-lab.scenemanagement)

## Developers

* [n.fridman](https://github.com/n-fridman)

## License

Project **Burning-Lab.SceneManagement** is distributed under the MIT license.