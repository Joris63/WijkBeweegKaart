import './App.css';
import {
  BrowserRouter as Router,
  Routes,
  Route
} from 'react-router-dom';

import SurveyQuestions from './components/survey/SurveyQuestions';

function App() {
  return (
    <div >
     <Router>   
            <Routes>
              <Route exact path='/' element={<SurveyQuestions/>}/>
            </Routes>
    </Router>

    </div>
  );
}

export default App;
