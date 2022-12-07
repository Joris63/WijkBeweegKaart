import { useEffect, useState } from "react";
import { getSurvey } from "../../api/survey";
import ProgressBar from "./ProgressBar";
import Question from "./Question";


const Survey = () => {

  const [questions, setQuestions] = useState([]);
  const [questionNumber, setQuestionNumber] = useState(0);
  const [json, setJson] = useState({ pages: [] });

  useEffect(() => {
    getSurvey()
      .then(res => {
        FormatQuestions(res.data.pages)

      })
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
                : null
          };

          formattedQuestions.push(formattedQuestion);
        });

        allQuestions.push(...formattedQuestions);
      }
    });
    setQuestions(allQuestions);
  }

  function OnChangeAnswer(questionId, data) {
    let foundQuestion = questions.find(
      (question) => question.id === questionId
    );

    if (foundQuestion === null) {
      return;
    }

    if (Array.isArray(foundQuestion.answer)) {
      let answer = foundQuestion.answer.find((ans) => ans === data);

      if (answer !== null) {
        let answers = foundQuestion.answer;
        answers.splice(answers.indexOf(answer), 1);
      } else {
        foundQuestion.answer.push(data);
      }
    } else {
      foundQuestion.answer = data;
    }

    console.log(foundQuestion);
  }

  const handleNextPage = () => {
    setQuestionNumber(questionNumber + 1)
  }

  const handlePreviousPage = () => {
    setQuestionNumber(questionNumber - 1)
  }

  return (
    <div className="survey_wrapper">
      <ProgressBar progress={1 / (questions.length -1 ) * questionNumber} percentage />
      <Question index={questionNumber + 1}
        type={questions[questionNumber]?.type}
        subType={questions[questionNumber]?.subType}
        question={questions[questionNumber]?.header}
        choices={questions[questionNumber]?.choices}
        answer={questions[questionNumber].answer}
        setAnswer={OnChangeAnswer}
         />

      <div className="actions">
        {questionNumber > 0 &&
        <button className="action_btn" onClick={handlePreviousPage}>Terug</button>
        }
        {questionNumber <= questions.length - 1 &&
        <button className="action_btn" onClick={handleNextPage}>Volgende</button>
        }
      </div>

    </div>
  );
};

export default Survey;