import "./App.css";
import "./styles/level-selection.scss";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import SurveyQuestions from "./components/survey/SurveyQuestions";
import LevelButton from "./components/level-selection/LevelSelectionItem";

function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route exact path="/" element={<LevelButton />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
