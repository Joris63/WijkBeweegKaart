import { useCallback, useEffect, useState } from "react";
import { Unity, useUnityContext } from "react-unity-webgl";

const availableBuildings = [
  { name: "Football", imageName: "Football" },
  { name: "Basketball", imageName: "Basketball" },
  { name: "Tennis", imageName: "Tennis" },
  { name: "Volleyball", imageName: "Volleyball" },
  { name: "Playground", imageName: "Playground" },
];

const MapViewer = ({ mode }) => {
  
  const {
    unityProvider,
    isLoaded,
    sendMessage,
    addEventListener,
    removeEventListener,
  } = useUnityContext({
    loaderUrl: "/map-editor/build/map-editor.loader.js",
    dataUrl: "/map-editor/build/map-editor.data",
    frameworkUrl: "/map-editor/build/map-editor.framework.js",
    codeUrl: "/map-editor/build/map-editor.wasm",
  });

  const handleTest = useCallback(() => {
    console.log("initialized");
  }, []);

  useEffect(() => {
    if (isLoaded) {
      sendMessage(
        "DataController",
        "InitializeData",
        mode,
        {},
        {},
        availableBuildings
      );
    }
  }, [isLoaded]);

  useEffect(() => {
    addEventListener("UnityInitialized", handleTest);
    return () => {
      removeEventListener("UnityInitialized", handleTest);
    };
  }, [addEventListener, removeEventListener, handleTest]);

  return (
    <>
      {!isLoaded && (
        <div className="map container">
          <div className="bar"></div>
        </div>
      )}
      <div className="map">
        <Unity
          unityProvider={unityProvider}
          style={{
            visibility: isLoaded ? "visible" : "hidden",
            width: 591,
            height: 297,
          }}
        />
      </div>
    </>
  );
};

export default MapViewer;
