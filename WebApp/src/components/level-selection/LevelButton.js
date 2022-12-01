const LevelButton = () => {
  return (
    <button className="level_button">
      <div className="level_name">Level name</div>
      <i class="fa-regular fa-star level_status"></i>
      <div className="level_reward_cointainer">
        <div className="element">100</div>
        <div className="level_reward_icon element">
          <i class="fa-regular fa-coin"></i>
        </div>
      </div>
    </button>
  );
};

export default LevelButton;
