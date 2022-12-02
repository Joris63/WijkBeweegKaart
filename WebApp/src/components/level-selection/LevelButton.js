const LevelButton = ({ small = false, locked = false, complete = false }) => {
  return (
    <button className={`level_button ${small ? "small" : ""}`}>
      {(locked && <i class="fa-solid fa-lock locked_circle"></i>) ||
        (complete && <i class="fa-solid fa-check complete_circle"></i>)}

      <div>Link jouw email</div>
      <div className="header_coins">
        100
        <i class="fa-duotone fa-coins"></i>
      </div>
    </button>
  );
};

export default LevelButton;
