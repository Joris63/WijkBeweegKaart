const Textarea = ({ answer = "", setAnswer = () => {}, placeholder = "" }) => {
  function autoGrow(e) {
    e.target.style.height = "0px";
    e.target.style.height = e.target.scrollHeight + 7 + "px";
  }

  return (
    <textarea
      placeholder={placeholder}
      value={answer}
      onInput={autoGrow}
      onChange={(e) => setAnswer(e.target.value)}
    ></textarea>
  );
};

export default Textarea;
