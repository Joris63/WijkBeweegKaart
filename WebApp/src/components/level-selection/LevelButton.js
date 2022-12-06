const LevelButton = ({
  id = 0,
  name = "level name",
  locked = false,
  complete = false,
  reward = 100,
}) => {
  return (
    <button
      id={id}
      className={`level_button ${locked || complete ? "small" : ""}`}
    >
      {complete && <i class="fa-solid fa-check complete_circle"></i>}
      {locked && <i class="fa-solid fa-lock locked_circle"></i>}

      <div>{name}</div>
      <div className="header_coins">
        {reward}
        <i class="fa-duotone fa-coins"></i>
      </div>
    </button>
  );
};

export default LevelButton;
