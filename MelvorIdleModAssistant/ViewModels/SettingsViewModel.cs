﻿using MelvorIdleModAssistant.Models;
using ReactiveUI;
using System;

namespace MelvorIdleModAssistant.ViewModels {
    public class SettingsViewModel : ReactiveObject, IRoutableViewModel {
        public MainWindowViewModel MainWindowVM { get; }

        // Reference to IScreen that owns the routable view model.
        public IScreen HostScreen { get; }

        // Unique identifier for the routable view model.
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

        //The settings model
        private Settings settings;

        public SettingsViewModel(MainWindowViewModel MainWindowVM) {
            this.MainWindowVM = MainWindowVM;
            HostScreen = MainWindowVM;
            settings = SettingsModel.LoadSettings();

        }

        //Whether the user has accepted the terms
        public bool AcceptedTerms
        {
            get
            {
                return settings.AcceptedTerms;
            }
            set
            {
                settings.AcceptedTerms = value;
            }
        }
    }
}