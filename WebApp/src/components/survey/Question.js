import { useState } from "react";
import RadioButton from "./answer-types/RadioButton";
import Checkbox from "./answer-types/Checkbox";
import Textarea from "./answer-types/Textarea";

const defaultAnswers = ["Man", "Vrouw", "Vul ik liever niet in"];

const Question = ({
  index = 1,
  type = "multiple",
  question = "Wat is uw geslacht?",
  answers = defaultAnswers,
}) => {
  const [answer, setAnswer] = useState("");

  const renderAnswerType = (answer, i) => {
    switch (type) {
      default:
        return (
          <RadioButton
            key={`${index}-answer-${i}`}
            index={i}
            answer={answer}
            setAnswer={setAnswer}
          />
        );
      case "single":
        return (
          <RadioButton
            key={`${index}-answer-${i}`}
            index={i}
            answer={answer}
            setAnswer={setAnswer}
          />
        );
      case "multiple":
        return (
          <Checkbox
            key={`${index}-answer-${i}`}
            index={i}
            answer={answer}
            setAnswer={setAnswer}
          />
        );
    }
  };

  return (
    <div className="question_wrapper">
      <div className="question">
        {index}. {question}
      </div>
      <div className="answers">
        {answers.length === 0 && type === "open" && (
          <Textarea answer={answer} setAnswer={setAnswer} />
        )}
        {answers.map((answer, i) => renderAnswerType(answer, i))}
      </div>
      <div className="actions">
        <button className="action_btn">Terug</button>
        <button className="action_btn">Volgende</button>
      </div>
    </div>
  );
};

export default Question;
