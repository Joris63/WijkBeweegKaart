const RadioButton = ({ index, choice, answer, setAnswer }) => {
  return (
    <div className="answer">
      <input
        id={`r-${index}`}
        type="radio"
        name="radio"
        checked={choice.id === answer}
        onChange={(e) => setAnswer(choice.id)}
      />
      <label htmlFor={`r-${index}`}>{choice.text}</label>
    </div>
  );
};

export default RadioButton;
