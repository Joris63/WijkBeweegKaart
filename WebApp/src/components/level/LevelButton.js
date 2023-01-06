const LevelButton = ({
  title = "",
  reward = 0,
  small = false,
  locked = false,
  complete = false,
  onClick = (index) => {},
}) => {
  return (
    <div
      className={`level_button${small ? " small" : ""}${
        locked ? " locked" : ""
      }${complete ? " complete" : ""}`}
      onClick={onClick}
    >
      <div className="level_button_title">{title}</div>
      <div className="level_button_reward">
        {reward}
        <i className="fa-duotone fa-coins"></i>
      </div>
    </div>
  );
};

export default LevelButton;
