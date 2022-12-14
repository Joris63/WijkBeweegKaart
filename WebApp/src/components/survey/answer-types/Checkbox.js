const Checkbox = ({ index, choice, answer, setAnswer }) => {
  return (
    <div className="answer">
      <input
        id={`c-${index}`}
        type="checkbox"
        checked={answer.includes(choice.id)}
        onChange={(e) => setAnswer(choice.id)}
      />
      <label htmlFor={`c-${index}`}>{choice.text}</label>
    </div>
  );
};

export default Checkbox;
