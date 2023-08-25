﻿using System;
using System.Reactive.Disposables;
using Lukomor.Reactive;
using UnityEngine;

namespace Lukomor.MVVM
{
    public class ObservableBinder<T> : MonoBehaviour
    {
        protected IDisposable BindObservable(string propertyName, IViewModel viewModel, Action<T> callback)
        {
            var property = viewModel.GetType().GetProperty(propertyName);
            var observable = (IObservable<T>)property.GetValue(viewModel);
            var subscription = observable.Subscribe(callback);

            return subscription;
        }
        
        protected IDisposable BindCollection(string propertyName, IViewModel viewModel, Action<T> addedCallback, Action<T> removedCallback)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var reactiveCollection = (IReactiveCollection<T>)propertyInfo.GetValue(viewModel);

            var addedSubscription = reactiveCollection.Added.Subscribe(addedCallback);
            var removedSubscription = reactiveCollection.Removed.Subscribe(removedCallback);
            var compositeDisposable = new CompositeDisposable();
            
            compositeDisposable.Add(addedSubscription);
            compositeDisposable.Add(removedSubscription);

            return compositeDisposable;
        }
    }
}