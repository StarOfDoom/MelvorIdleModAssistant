﻿using MelvorIdleModAssistant.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;

namespace MelvorIdleModAssistant.ViewModels {
    public class ModsViewModel : ReactiveObject, IRoutableViewModel {
        public MainWindowViewModel MainWindowVM { get; }

        // Reference to IScreen that owns the routable view model.
        public IScreen HostScreen { get; }

        // Unique identifier for the routable view model.
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

        //The list of mods
        private List<Mod> modList;
        public List<Mod> ModList
        {
            get
            {
                return modList;
            }
            set
            {
                modList = value;
                MainWindowVM.OnPropertyChanged(nameof(ModList));
            }
        }

        public ModsViewModel(MainWindowViewModel MainWindowVM) {
            this.MainWindowVM = MainWindowVM;
            HostScreen = MainWindowVM;

            modList = ModModel.LoadMods();

            Test();
        }

        private async void Test() {
            await ModModel.DownloadGitRepository();
        }
    }
}