import _ from "lodash";
import { useEffect, useState } from "react";
import ProgressBar from "./ProgressBar";
import Question from "./Question";
import Register from "../auth/Register";
import { useNavigate } from "react-router-dom";

const Survey = ({ survey = null, pageNumber = 0 }) => {
  const [loading, setLoading] = useState(true);
  const [questions, setQuestions] = useState([]);
  const [questionNumber, setQuestionNumber] = useState(0);

  const navigate = useNavigate();

  useEffect(() => {
    setLoading(survey === null || _.isEmpty(survey));

    if (survey !== null) {
      setQuestions(survey[pageNumber]?.questions);
    }
  }, [survey, pageNumber]);

  function OnChangeAnswer(questionId, data) {
    let updatedQuestions = _.cloneDeep(questions);
    let foundQuestion = updatedQuestions.find(
      (question) => question.id === questionId
    );

    if (!foundQuestion) {
      return;
    }

    if (Array.isArray(foundQuestion.answer)) {
      let answer = foundQuestion.answer.find((ans) => ans === data);

      if (answer) {
        let answers = foundQuestion.answer;
        answers.splice(answers.indexOf(answer), 1);
      } else {
        foundQuestion.answer.push(data);
      }
    } else {
      foundQuestion.answer = data;
    }

    setQuestions(updatedQuestions);
  }

  const handleNextQuestion = () => {
    setQuestionNumber(questionNumber + 1);
  };

  const handlePrevQuestion = () => {
    setQuestionNumber(questionNumber - 1);
  };

  function handlePostSurvey() {
    let surveyJson = { pages: [] };
    questions.forEach((question, index) => {
      surveyJson.pages.push({
        id: question.pageId,
        questions: [{ id: question.id, answers: [] }],
      });

      switch (question.type) {
        default:
          break;
        case "single":
          surveyJson.pages[index].questions[0].answers.push({
            choice_id: question.answer,
          });
          break;
        case "multiple":
          question.answer.forEach((answer) => {
            surveyJson.pages[index].questions[0].answers.push({
              choice_id: answer,
            });
          });
          break;
        case "open":
          surveyJson.pages[index].questions[0].answers.push({
            text: question.answer,
          });
      }
    });

    navigate("/levels");
    // postSurvey(surveyJson)
    // .then(res => {
    //   console.log(res)
    //   handleNextPage();
    // }).catch((error) => {console.log(error)});
  }

  return (
    <div className="survey_wrapper">
      {loading ? (
        <div className="container">
          <div className="bar"></div>
        </div>
      ) : (
        <>
          {questionNumber < questions?.length && (
            <ProgressBar
              progress={(1 * questionNumber) / questions?.length + 1}
              percentage
            />
          )}
          {pageNumber === 0 && questionNumber === questions?.length && (
            <Register />
          )}
          {questionNumber < questions?.length && (
            <Question
              id={questions[questionNumber]?.id}
              index={questionNumber + 1}
              type={questions[questionNumber]?.type}
              subType={questions[questionNumber]?.subType}
              question={questions[questionNumber]?.header}
              choices={questions[questionNumber]?.choices}
              answer={questions[questionNumber]?.answer}
              setAnswer={OnChangeAnswer}
            />
          )}
          <div className="actions">
            {questionNumber > 0 && (
              <button
                className="action_btn"
                style={{ float: "left" }}
                onClick={handlePrevQuestion}
              >
                Terug
              </button>
            )}
            {(questionNumber < questions?.length - 1 || pageNumber === 0) &&
              questions[questionNumber]?.answer && (
                <button
                  className="action_btn"
                  style={{ float: "right" }}
                  onClick={handleNextQuestion}
                >
                  Volgende
                </button>
              )}
            {questionNumber === questions?.length - 1 &&
              pageNumber !== 0 &&
              questions[questionNumber]?.answer && (
                <button
                  className="action_btn"
                  style={{ float: "right" }}
                  onClick={handlePostSurvey}
                >
                  Voltooien
                </button>
              )}
          </div>
        </>
      )}
    </div>
  );
};

export default Survey;
