import LevelButton from "./LevelButton";

const LevelSelector = () => {
  return (
    <div>
      <div className="level_container">
        <LevelButton />
      </div>

      <div className="level_container_small">
        <LevelButton />
        <LevelButton />
        <LevelButton complete />
        <LevelButton locked />
      </div>
    </div>
  );
};

export default LevelSelector;
