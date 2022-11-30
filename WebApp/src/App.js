import {
  BrowserRouter as Router,
  Navigate,
  Routes,
  Route,
} from "react-router-dom";
import RequireAuth from "./components/auth/RequireAuth";

// Import pages
import AuthPage from "./pages/AuthPage";
import LevelSelectPage from "./pages/LevelSelectPage";
import MapViewerPage from "./pages/MapViewerPage";
import SurveyPage from "./pages/SurveyPage";

// Import stylesheets
import "./styles/index.scss";
import "./styles/survey.scss";
import "./styles/level-select.scss";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<SurveyPage />} />
        <Route path="/login" element={<AuthPage />} />
        <Route element={<RequireAuth />}>
          <Route path="/levels" element={<LevelSelectPage />} />
          <Route path="/map" element={<MapViewerPage />} />
          <Route path="*" element={<Navigate to="/" replace />} />
        </Route>
      </Routes>
    </Router>
  );
}

export default App;