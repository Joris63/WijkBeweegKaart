import {
  BrowserRouter as Router,
  Navigate,
  Routes,
  Route,
} from "react-router-dom";
import RequireAuth from "./components/auth/RequireAuth";

// Import pages
import LevelSelectorPage from "./pages/LevelSelectorPage";
import RegisterPage from "./pages/RegisterPage";
import LoginPage from "./pages/LoginPage";
import SurveyPage from "./pages/SurveyPage";

// Import stylesheets
import "./styles/index.scss";
import "./styles/phones.scss";
import "./styles/auth.scss";
import "./styles/level.scss";
import "./styles/survey.scss";
import MapViewerPage from "./pages/MapViewerPage";
import LoginRegisterPage from "./pages/LoginRegisterPage";

function App() {
  return (
    <div
      className={`iphone${
        window.location.pathname === "/map" ? " flipped" : ""
      }`}
    >
      <div className="iphone__inner">
        <div className="iphone__content">
          <div className="iphone__content__header">
            <div className="iphone_header_top">
              <div className="iphone_header_time">17:51</div>
              <div className="iphone_header_icons">
                <i className="fa-solid fa-signal-bars"></i>
                <i className="fa-solid fa-wifi"></i>
                <i className="fa-solid fa-battery-full"></i>
              </div>
            </div>
            <div className="iphone_header_bottom">survey.nl</div>
          </div>
          <div className="iphone__content__wrapper">
            <Router>
              <Routes>
                <Route path="/survey" element={<SurveyPage />} />
                <Route path="/" element={<LoginRegisterPage />} />
                <Route path="/register" element={<RegisterPage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="*" element={<Navigate to="/" replace />} />
                <Route element={<RequireAuth />}>
                  <Route path="/levels" element={<LevelSelectorPage />} />
                  <Route path="/map" element={<MapViewerPage />} />
                </Route>
              </Routes>
            </Router>
          </div>
        </div>
        <div className="iphone-header-button">
          <div className="iphone-header-button__left">
            <span></span>
            <span></span>
            <span></span>
          </div>
          <div className="iphone-header-button__right">
            <span></span>
          </div>
        </div>
        <div className="iphone-header">
          <div className="iphone-header__inner">
            <div className="iphone-header__item"></div>
            <div className="iphone-header-circle">
              <div className="iphone-header-circle__inner">
                <div className="iphone-header-circle__item"></div>
                <div className="iphone-header-circle__item"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
