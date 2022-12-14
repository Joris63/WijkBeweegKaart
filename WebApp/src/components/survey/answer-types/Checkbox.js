const Checkbox = ({ index, choice, answer, setAnswer }) => {
  return (
    <div className="answer">
      <input
        id={`c-${index}`}
        type="checkbox"
        checked={answer.includes(choice.text)}
        onChange={(e) => setAnswer(choice.text)}
      />
      <label htmlFor={`c-${index}`}>{choice.text}</label>
    </div>
  );
};

export default Checkbox;
