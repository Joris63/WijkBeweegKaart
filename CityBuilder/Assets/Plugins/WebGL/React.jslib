mergeInto(LibraryManager.library, {
  Test: function (userName) {
    window.dispatchReactUnityEvent("Test", UTF8ToString(userName));
  },
});