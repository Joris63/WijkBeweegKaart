const RadioButton = ({ index, answer, setAnswer }) => {
  return (
    <div className="answer">
      <input id={`r-${index}`} type="radio" name="radio" value="1" />
      <label htmlFor={`r-${index}`}>{answer.text}</label>
    </div>
  );
};

export default RadioButton;
