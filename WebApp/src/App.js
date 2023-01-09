import { Navigate, Routes, Route, useNavigate } from "react-router-dom";
import RequireAuth from "./components/auth/RequireAuth";
import { setAuthToken } from "./api/axios";
import { getSurvey } from "./api/survey";
import { useState, useEffect } from "react";

// Import pages
import LevelSelectorPage from "./pages/LevelSelectorPage";
import RegisterPage from "./pages/RegisterPage";
import LoginPage from "./pages/LoginPage";
import SurveyPage from "./pages/SurveyPage";
import MapViewerPage from "./pages/MapViewerPage";
import LoginRegisterPage from "./pages/LoginRegisterPage";

// Import stylesheets
import "./styles/index.scss";
import "./styles/phones.scss";
import "./styles/auth.scss";
import "./styles/level.scss";
import "./styles/survey.scss";

function App() {
  const [survey, setSurvey] = useState([]);
  const [pageNumber, setPageNumber] = useState(0);

  const navigate = useNavigate();

  const token = localStorage.getItem("token");
  if (token) {
    setAuthToken(token);
  }

  function FormatSurvey(data) {
    let entireSurvey = data.map((page) => ({
      id: page.id,
      title: page.title,
      description: page.description,
      questions: page.questions.map((question) => {
        let questionType = question.family.split("_");

        return {
          id: question.id,
          type: questionType[0],
          header: question.headings[0].heading,
          subType: question.subtype,
          answer: questionType[0] === "multiple" ? [] : "",
          choices:
            question.answers?.choices?.length > 0
              ? question.answers.choices.map((choice) => ({
                  id: choice.id,
                  text: choice.text,
                }))
              : null,
        };
      }),
    }));

    setSurvey(entireSurvey);
  }

  function LoadSurvey(pageId) {
    setPageNumber(survey.findIndex((page) => page.id === pageId));

    navigate("/");
  }

  useEffect(() => {
    getSurvey().then((res) => {
      FormatSurvey(res.data.pages);
    });
  }, []);

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
            <Routes>
              <Route path="/" element={<LoginRegisterPage />} />
              <Route
                path="/survey"
                element={<SurveyPage survey={survey} pageNumber={pageNumber} />}
              />
              <Route path="/register" element={<RegisterPage />} />
              <Route path="/login" element={<LoginPage />} />
              <Route path="*" element={<Navigate to="/" replace />} />
              <Route element={<RequireAuth />}>
                <Route
                  path="/levels"
                  element={
                    <LevelSelectorPage
                      survey={survey}
                      loadSurvey={LoadSurvey}
                    />
                  }
                />
                <Route path="/map" element={<MapViewerPage />} />
              </Route>
            </Routes>
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
