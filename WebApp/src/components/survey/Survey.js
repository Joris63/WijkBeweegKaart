import _, { indexOf } from "lodash";
import { Fragment, useEffect, useState } from "react";
import { getSurvey, postSurvey } from "../../api/survey";
import ProgressBar from "./ProgressBar";
import Question from "./Question";
import Register from "../auth/Register";

const Survey = ({ surveyId = null }) => {
  const [loading, setLoading] = useState(true);
  const [questions, setQuestions] = useState([]);
  const [questionNumber, setQuestionNumber] = useState(0);

  useEffect(() => {
    getSurvey().then((res) => {
      setLoading(false);
      FormatQuestions(res.data.pages);
    });
  }, []);

  function FormatQuestions(data) {
    let allQuestions = [];

    data.forEach((page) => {
      if (page.questions.length > 0) {
        let formattedQuestions = [];

        page.questions.forEach((question) => {
          let questionType = question.family.split("_");
          let formattedQuestion = {
            id: question.id,
            pageId: page.id,
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

          formattedQuestions.push(formattedQuestion);
        });

        allQuestions.push(...formattedQuestions);
      }
    });
    setQuestions(allQuestions);
  }

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

  const handleNextPage = () => {
    setQuestionNumber(questionNumber + 1);
  };

  const handlePreviousPage = () => {
    setQuestionNumber(questionNumber - 1);
  };

  function handlePostSurvey()
  {
    let surveyJson = { pages: [] }
    questions.forEach((question, index) => {
      surveyJson.pages.push({"id" : question.pageId, "questions":[{"id": question.id, "answers":[]}]})
  
      switch(question.type)
      {
        case "single": 
        surveyJson.pages[index].questions[0].answers.push({"choice_id": question.answer})
        break;
        case"multiple":
        question.answer.forEach(answer =>
          {
            surveyJson.pages[index].questions[0].answers.push({"choice_id": answer})
          })
        break;
        case"open":
        surveyJson.pages[index].questions[0].answers.push({"text": question.answer})
      }
    })  
    handleNextPage();
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
          {questionNumber < questions.length && (
            <ProgressBar
              progress={(1 / questions.length) * questionNumber}
              percentage
            />
          )}
          {surveyId === null && questionNumber === questions.length && (
            <Register />
          )}
          {questionNumber < questions.length && (
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
                onClick={handlePreviousPage}
              >
                Terug
              </button>
            )}
            {questionNumber <= questions.length - 2 &&
              questions[questionNumber]?.answer && (
                <button
                  className="action_btn"
                  style={{ float: "right" }}
                  onClick={handleNextPage}
                >
                  Volgende
                </button>
              ) }
            {questionNumber === questions.length - 1 && (
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
