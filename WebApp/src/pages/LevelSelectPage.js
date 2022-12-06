import LevelSelector from "../components/level-selection/LevelSelector";

const LevelSelectPage = () => {
  return (
    <div>
      <div className="header">
        <div className="header_item">Welkom Joris</div>
        <div className="header_coins">
          100
          <i class="fa-duotone fa-coins"></i>
        </div>
      </div>
      <div className="container">
        <h3 className="item">Selecteer level</h3>
      </div>
      <LevelSelector />
    </div>
  );
};

export default LevelSelectPage;
