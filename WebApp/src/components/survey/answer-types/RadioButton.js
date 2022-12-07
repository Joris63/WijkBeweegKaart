const RadioButton = ({ index, choice, answer, setAnswer }) => {
  return (
    <div className="answer">
      <input
        id={`r-${index}`}
        type="radio"
        name="radio"
        checked={choice.text === answer}
        onChange={(e) => setAnswer(choice.text)}
      />
      <label htmlFor={`r-${index}`}>{choice.text}</label>
    </div>
  );
};

export default RadioButton;
