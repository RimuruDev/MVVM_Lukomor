# Lukomor - Unity Architectural Template

**Discussing here:**
https://discord.gg/yX3cKpvaGC

## WARNING
Versions older than 4.0.0 are deprecated. (version 2.x.x moved to branch version_2). **Version 4 doesn't support backward compatibility**, and you shouldn't update your project from the package manager with clicking Update button (it will download version 4). For updating version 2 (is will have a support for a some time) please reimport asset with the link:

```
https://github.com/vavilichev/Lukomor.git#version_2
```

## Installation

Copy next line:

```
https://github.com/vavilichev/Lukomor.git
```

Open Window/Package Manager, click **+** button, choose "Add package from git URL..." and past link here. Then click the "Add" button.

![image](https://user-images.githubusercontent.com/22970240/166225114-30e8cb9d-0b20-44cd-9e7d-d2e13cabd40e.png)

That's it! Asset ready to use.

## Example

If you want to learn the example of the project used the Lukomor Architecture - just choose the Lukomore Architecture in the Package Manager and click "Import" in the "Samples" dirrectory on the right.

![image](https://user-images.githubusercontent.com/22970240/166225335-f83cbda1-193c-44cd-8518-0a721a3a436c.png)

**WARNING**

To make example work properly you must add all scenes from the folder Example/TagsGame/Scenes/ to the BuildSettings.

![image](https://user-images.githubusercontent.com/22970240/208266469-2f999603-a067-4cbd-a4eb-cc3e590d2ae7.png)

Full documentation coming soon..

Table of content:
- [Short description](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#short-description)
- [What is the MVVM](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#what-is-the-mvvm)
- [What are the Binder and the View components](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#what-are-the-binder-and-the-view-components)
- [How to setup View and SubView](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#how-to-setup-view-and-subview)
- [Using Observables in the Lukomor](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#how-to-setup-view-and-subview)
- [Basic set of binders in Lukomor](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#basic-set-of-binders-in-lukomor)
- [How to expand the set of binders](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#how-to-expand-the-set-of-binders)
- [How to setup binders](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#how-to-expand-the-set-of-binders)
- [DI in the Lukomor](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#di-in-the-lukomor)
- [Recommendations](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#di-in-the-lukomor)


## Short description

Lukomor is an architectural framework for Unity game engine that helps you apply MVVM pattern to your project easy and convenient reducing the leaks of Model into View. This framework suits to any kind of project: small and large. The most cool part of this framework (in my opinion) is separating programmers part of work from artists. Programmers can write ViewModels for features and artists can just setup binders and get a workable feature. For more information read documentation and watch [the example](https://github.com/vavilichev/LukomorExample)

## What is the MVVM
MVVM (Model - View - ViewModel) is a simple architectural programming pattern. You can find a lot of information about it in the internet. For example in [Wikipedia](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel). Therefore, I just place a scheme of work here without any additional info.

![image](https://github.com/vavilichev/Lukomor/assets/22970240/9aef4881-09b9-4012-acc3-84b09b13db44)

## What are the Binder and the View components

## How to setup View and SubView

## Using Observables in the Lukomor

## Basic set of binders in Lukomor

## How to expand the set of binders

## How to setup binders

## DI in the Lukomor

## Recommendations
