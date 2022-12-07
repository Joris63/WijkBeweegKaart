const Checkbox = ({ index, answer, setAnswer }) => {
  return (
    <div className="answer">
      <input id={`c-${index}`} type="checkbox" />
      <label htmlFor={`c-${index}`}>{answer.text}</label>
    </div>
  );
};

export default Checkbox;
