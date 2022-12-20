import LevelSelector from "../components/level/LevelSelector";

const LevelSelectorPage = (props) => {
  return (
    <div style={{ height: "100%" }}>
      <LevelSelector {...props} />
    </div>
  );
};

export default LevelSelectorPage;
