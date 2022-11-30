import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import SurveyQuestions from "./components/survey/SurveyQuestions";
import LevelButton from "./components/levelSelection/LevelButton";

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
