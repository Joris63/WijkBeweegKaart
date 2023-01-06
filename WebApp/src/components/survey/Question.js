import RadioButton from "./answer-types/RadioButton";
import Checkbox from "./answer-types/Checkbox";
import Textarea from "./answer-types/Textarea";

const defaultAnswers = ["Man", "Vrouw", "Vul ik liever niet in"];

const Question = ({
  id,
  index = 1,
  type = "multiple",
  subType = "",
  question = "Wat is uw geslacht?",
  choices = defaultAnswers,
  answer = "",
  setAnswer = () => {}
}) => {

  const renderAnswerType = (choice, i) => {
    switch (type) {
      default:
        return (
          <RadioButton
            key={`${index}-choice-${i}`}
            index={i}
            choice={choice}
            answer={answer}
            setAnswer={(data) => setAnswer(id, data)}
          />
        );
      case "single":
        return (
          <RadioButton
            key={`${index}-choice-${i}`}
            index={i}
            choice={choice}
            answer={answer}
            setAnswer={(data) => setAnswer(id, data)}
          />
        );
      case "multiple":
        return (
          <Checkbox
            key={`${index}-choice-${i}`}
            index={i}
            choice={choice}
            answer={answer}
            setAnswer={(data) => setAnswer(id, data)}
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
        {!choices && type === "open" && (
          <Textarea answer={answer} setAnswer={(data) => setAnswer(id, data)} />
        )}
        {choices?.map((choice, i) => renderAnswerType(choice, i))}
      </div>
    </div>
  );
};

export default Question;
