# Lukomor - Unity Architectural Template

**Discussing here:**
https://discord.gg/yX3cKpvaGC

Table of content:
- [Short description](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#short-description)
- [What is the MVVM](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#what-is-the-mvvm)
- [ViewModels](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#viewmodels)
- [Views](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#views)
- [Binders](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#binders)
- [What are the View and the Binder components](https://github.com/vavilichev/Lukomor/tree/dev?tab=readme-ov-file#what-are-the-binder-and-the-view-components)
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

## ViewModels
ViewModels is a non MonoBehaviour class that connects View and Model. In the Lukomor you must implement the IViewModel interface in each of your ViewModel realization. It's required because the Editor scripts works with interfaces for showing relevant information about existing ViewModels. Therefore your class can be look like this:
```csharp
public class MyCoolViewModel : IViewModel 
{

}
```

## Views
View is a basic MonoBehaviour component that must be attached to a GameObject that represents the visualization of some ViewModel`s work. It can be object on scene or prefab.

![image](https://github.com/vavilichev/Lukomor/assets/22970240/6d7bc465-f22f-4e7c-b6df-766e518220d1)

Every View can be a parent View (root) or SubView (child). The **IsParentView** checkbox in View component shows you the state. It calculates automatically.

![image](https://github.com/vavilichev/Lukomor/assets/22970240/6a398e83-a213-413c-8d51-34165a27ed61)
![image](https://github.com/vavilichev/Lukomor/assets/22970240/f885f804-618f-4c26-a48c-69859e06e80e)

Parent View and child View look simmilar but work really different. First of all, both: parent View and child View awaits binding of IViewModel.

#### Parent View
Parent View awaits ViewModel that you choose in the ViewModel property in the Editor. And then sends this ViewModel to it's child views and binders that registered in this View.

![image](https://github.com/vavilichev/Lukomor/assets/22970240/be6c1240-6721-4f75-aabb-553d0b3998bf)

#### Child View
Child View shows you other field in the Editor - PropertyName. It's because child view awaits IViewModel that contains another ViewModel inside (SubViewModel or child ViewModel). Therefore this View gets this SubViewModel from received ViewModel (directly from **property field** with the name you picked in the Editor) and do the same work: sends it to it's child Views and Binders. You also can see that all binders and child views register automatically when you add or remove them from objects, it's for optimizing runtime work.

```csharp
public class MyCoolViewModel : IViewModel
{
    public SubViewModel MyCoolSubViewModel { get; }    // must be a property with public "get" for defining by Editor scripts

    public MyCoolViewModel()
    {
        MyCoolSubViewModel = new SubViewModel();
    }
}

```

![Parent View](https://github.com/vavilichev/Lukomor/assets/22970240/556fa715-d2f3-4aca-9e03-af28b40c295c)

![Child View](https://github.com/vavilichev/Lukomor/assets/22970240/42834a0d-d684-4c14-bbd2-84fc10275c6e)

> [!TIP]
> The Search feature helps you find your ViewModels and property names really quick. 

> [!WARNING]
> When you are going to make a prefab with parent View, you have to place it outside of other View. Otherwise prefab View defines like **child View** and you cannot choose ViewModel, only property names of ViewModel.




## Binders
Binders is the main feature of this framework. Binders help you to connect View and ViewModel: visualize data from ViewModel and send signals to the ViewModel for interacting with Model for example.

```csharp
public class MyCoolViewModel : IViewModel
{
    public IObservable<string> SomeObservableText => _someObservableText;
    public IObservable<string> SomeReactivePropertyText => _someReactivePropertyText;

    private readonly Subject<string> _someObservableText = new();
    private readonly ReactiveProperty<string> _someReactivePropertyText = new();

    public MyCoolViewModel()
    {
        _someObservableText.OnNext("Your awesome observableText");
        _someReactivePropertyText.Value = "Your awesome reactivePropertyText";
    }
}

```

![image](https://github.com/vavilichev/Lukomor/assets/22970240/74e4d884-2028-4b7e-b16f-f0ad863b5a21)



There are two types of binders:

### Observable property binder (ObservableBinder<T>)

This binder subscribes on public property that implements the IObservable<T> interface. When IObservable does "next", then binder handles the changed data and changes the visual that has been setupped in the editor. 
You can create your own binders, just inherit from ObservableBinder<T> and write your type instead of T. By the way, there are a bunch of prepared binders in the Lukomor.

It's recommendet to pay attention to **UnityEventBinder<T>** type of binders. That binders use UnityEvents for handling data from ViewModel. It's very convenient for using in editor. Watch the example above. 

Also you can use implementation of **IReadonlyReactiveCollection<T>** for your binders, it's convinient for creating and destroying Views depending on collection content. For example **VMCollectionToGameObjectCreationBinder** instantiates View from picked Prefab and bind added to collection ViewModel to the created View.

```csharp
public class MyCoolViewModel : IViewModel
{
    public IReadOnlyReactiveCollection<SubViewModel> SubViewModels => _subViewModels;

    private readonly ReactiveCollection<SubViewModel> _subViewModels = new();

    public MyCoolViewModel()
    {
        var subViewModelA = new SubViewModel();
        var subViewModelB = new SubViewModel();
        
        _subViewModels.Add(subViewModelA);
        _subViewModels.Add(subViewModelB);
    }
}
```

![image](https://github.com/vavilichev/Lukomor/assets/22970240/3884728f-d153-4c12-884b-471725eb5c9d)



### MethodBinder (that named the same)
When Binder received the ViewModel, this binder grabs the method from that ViewModel with the name you picked in the editor and caches it. When you call **Perform()** method of the Binder, this binder invokes the cached method. 

```csharp
public class MyCoolViewModel : IViewModel
{
    public void EmptyMethod()
    {
        
    }

    public void FloatArgMethod(float value)
    {
        
    }
}
```

Next two variants are the same, but **ButtonMerhodBinder** is more convenient for using with Unity Buttons.

![image](https://github.com/vavilichev/Lukomor/assets/22970240/5f741c12-b369-4e60-8569-543a642d34c3)

![image](https://github.com/vavilichev/Lukomor/assets/22970240/b78251eb-a2d7-463c-bc77-95476ffd50bf)

Lukomor also suppots G**enericMethodBinder<T>** that can invoke methods with arguments. You should use Perform(T value) instead of Perform(). It's convenient for cases when player does some input actions, for example moving a handle of the Slider

![image](https://github.com/vavilichev/Lukomor/assets/22970240/afad3725-8bbd-427b-b4f6-a4d93d85aed0)

> [!IMPORTANT]
> Full list of prepared binders you can see in the **Packages/Lukomor Architecture/Lukomor/Scripts/MVVM/Binders section**.
> 
>![image](https://github.com/vavilichev/Lukomor/assets/22970240/578216e2-1a28-465f-99be-1254673bd87e)

## How to setup View and SubView

## Using Observables in the Lukomor

## Basic set of binders in Lukomor

## How to expand the set of binders

## How to setup binders

## DI in the Lukomor

## Recommendations
