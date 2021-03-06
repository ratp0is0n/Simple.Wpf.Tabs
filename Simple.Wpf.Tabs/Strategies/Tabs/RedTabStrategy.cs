﻿namespace Simple.Wpf.Tabs.Strategies.Tabs
{
    using System;
    using Models;
    using ViewModels.Tabs;

    public sealed class RedTabStrategy : ITabStrategy
    {
        private readonly Func<Tab, IRedTabViewModel> _factory;
        public static readonly Tab Default = new Tab(Guid.Parse("{E991A450-EE34-4D02-93F8-2CFAFC653159}"), "Red");

        public Guid TypeId { get; }

        public string Name { get; }

        public RedTabStrategy(Func<Tab, IRedTabViewModel> factory)
        {
            _factory = factory;

            TypeId = Default.TypeId;
            Name = Default.Name;
        }

        public bool CanHandle(Tab tab, out ITabViewModel tabViewModel)
        {
            tabViewModel = null;
            if (tab.TypeId == Default.TypeId)
            {
                tabViewModel = _factory(tab);
                return true;
            }

            return false;
        }

        public ITabViewModel Create()
        {
            return new RedTabViewModel(new Tab(TypeId, Name));
        }
    }
}