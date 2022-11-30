const LevelButton = () => {
  return (
    <div>
      <button className="level_button">
        <div className="level_name">Level name</div>
        <div className="level_status">
          <i class="fa-regular fa-star"></i>
        </div>
        <div className="level_reward_cointainer">
          <div className="element">100</div>
          <div className="level_reward_icon element">
            <i class="fa-regular fa-coin"></i>
          </div>
        </div>
      </button>
    </div>
  );
};

export default LevelButton;
