import { Unity, useUnityContext } from "react-unity-webgl";

const MapViewer = () => {
  const { unityProvider, loadingProgression, isLoaded } = useUnityContext({
    loaderUrl: "/build/map-editor.loader.js",
    dataUrl: "/build/map-editor.data",
    frameworkUrl: "/build/map-editor.framework.js",
    codeUrl: "/build/map-editor.wasm",
  });

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
