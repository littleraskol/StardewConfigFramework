﻿using StardewModdingAPI;
using StardewConfigFramework.Options;
using System.Collections.Generic;
using System.IO;
using System;

namespace StardewConfigFramework {
	public class SimpleModOptions: IModOptions {
		public SimpleModOptions(Mod mod) {
			this.ModManifest = mod.ModManifest;
		}

		public IManifest ModManifest { get; private set; }
		public IList<ModOptionsTab> Tabs => _Tabs.AsReadOnly();
		private List<ModOptionsTab> _Tabs => new List<ModOptionsTab> { Tab };
		public IList<ModOption> OptionList => Tab.OptionList;
		private ModOptionsTab Tab = new ModOptionsTab("");
		public int TabCount { get; } = 1;

		public T GetOptionWithIdentifier<T>(string identifier) where T : ModOption {
			return Tab.GetOptionWithIdentifier<T>(identifier);
		}

		public ModOption GetOptionWithIdentifier(string identifier) {
			return Tab.GetOptionWithIdentifier(identifier);
		}

		public Type GetTypeOfIdentifier(string identifier) {
			return Tab.GetTypeOfIdentifier(identifier);
		}

		public void AddOption(ModOption option) {
			Tab.AddOption(option);
		}

		public void InsertOption(ModOption option, int optionIndex) {
			Tab.InsertOption(option, optionIndex);
		}

		public ModOption RemoveOptionAtIndex(int optionIndex) {
			return Tab.RemoveOptionAtIndex(optionIndex);
		}

		public ModOption RemoveOptionWithIdentifier(string identifier) {
		[Obsolete("Saving/Loading settings within the framework is deprecated. Please use SMAPI methods for saving mod settings and use initial values when populating settings menu", true)]
		public static SimpleModOptions LoadUserSettings(Mod mod) {
			mod.Monitor.Log("[StardewConfigFramework] This mod is using deprecated saving & loading methods which will no longer work. Please alert the mod author");
			return new SimpleModOptions(mod);
			return Tab.RemoveOptionWithIdentifier(identifier);
		}

		[Obsolete("Saving/Loading settings within the framework is deprecated. Please use SMAPI methods for saving mod settings and use initial values when populating settings menu", true)]
		public void SaveUserSettings() { }

		[Obsolete("Saving/Loading settings within the framework is deprecated. Please use SMAPI methods for saving mod settings and use initial values when populating settings menu", true)]
		public static SimpleModOptions LoadCharacterSettings(Mod mod, string farmerName) {
			mod.Monitor.Log("[StardewConfigFramework] This mod is using deprecated saving & loading methods which will no longer work. Please alert the mod author");
			return new SimpleModOptions(mod);
		}

		[Obsolete("Saving/Loading settings within the framework is deprecated. Please use SMAPI methods for saving mod settings and use initial values when populating settings menu", true)]
		public void SaveCharacterSettings(string farmerName) { }
	}
}
