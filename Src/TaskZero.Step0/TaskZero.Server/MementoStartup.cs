﻿using Memento.Messaging;
using Memento.Messaging.Postie;
using Memento.Messaging.Postie.Unity;
using Memento.Persistence;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskZero.Server
{
    public class MementoStartup
    {
        public static UnityContainer UnityConfig(Type busType, Type eventStoreType) {
            var container = new UnityContainer();
            container.RegisterType<ITypeResolver, UnityTypeResolver>(new InjectionConstructor(container));
            container.RegisterType(typeof(IBus), busType);
            container.RegisterType(typeof(IEventDispatcher), busType);
            container.RegisterType<IRepository, Repository>(new InjectionConstructor(eventStoreType));
            container.RegisterType(typeof(IEventStore), eventStoreType, new InjectionConstructor(typeof(IEventDispatcher)));
            return container;
        }
        public static UnityContainer UnityConfig<TBus, TEventStore>()
        {
            var container = new UnityContainer();
            container.RegisterType<ITypeResolver, UnityTypeResolver>(new InjectionConstructor(container));
            container.RegisterType(typeof(IBus), typeof(TBus));
            container.RegisterType(typeof(IEventDispatcher), typeof(TBus));
            container.RegisterType<IRepository, Repository>(new InjectionConstructor(typeof(TEventStore)));
            container.RegisterType(typeof(IEventStore), typeof(TEventStore), new InjectionConstructor(typeof(IEventDispatcher)));
            return container;
        }

    }
}