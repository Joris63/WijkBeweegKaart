mergeInto(LibraryManager.library, {
  UnityInitialized: function () {
    window.dispatchReactUnityEvent("UnityInitialized");
  },
  SendRegionsData: function (data) {
    window.dispatchReactUnityEvent("SendRegionsData", UTF8ToString(data));
  },
  SendBuildingsData: function (data) {
    window.dispatchReactUnityEvent("SendBuildingsData", UTF8ToString(data));
  },
});