import { useCallback, useEffect, useState } from "react";
import { Unity, useUnityContext } from "react-unity-webgl";

const MapViewer = () => {
  const [testText, setTestText] = useState("");
  const {
    unityProvider,
    loadingProgression,
    isLoaded,
    sendMessage,
    addEventListener,
    removeEventListener,
  } = useUnityContext({
    loaderUrl: "/build/map-editor.loader.js",
    dataUrl: "/build/map-editor.data",
    frameworkUrl: "/build/map-editor.framework.js",
    codeUrl: "/build/map-editor.wasm",
  });

  function UpdateText() {
    let date = new Date();

    let day = date.getDate();
    let month = date.getMonth() + 1;
    let year = date.getFullYear();

    sendMessage("GameController", "UpdateTextField", `${day}-${month}-${year}`);
  }

  const handleTest = useCallback((name) => {
    setTestText(name);
  }, []);

  useEffect(() => {
    addEventListener("Test", handleTest);
    return () => {
      removeEventListener("Test", handleTest);
    };
  }, [addEventListener, removeEventListener, handleTest]);

  return (
    <>
      {!isLoaded && (
        <div className="map container">
          <div className="bar"></div>
        </div>
      )}
      <div className="map" onClick={UpdateText}>
        <Unity
          unityProvider={unityProvider}
          style={{
            visibility: isLoaded ? "visible" : "hidden",
            width: 591,
            height: 297,
          }}
        />
      </div>
      <div
        style={{
          position: "fixed",
          left: "50%",
          transform: "translateX(-50%)",
        }}
      >
        {testText}
      </div>
    </>
  );
};

export default MapViewer;
