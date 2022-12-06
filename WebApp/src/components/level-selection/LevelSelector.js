import LevelButton from "./LevelButton";

const levels = [
  {
    id: 1,
    name: "link uw email addres",
    locked: false,
    complete: true,
    reward: 50,
  },
  {
    id: 2,
    name: "Creeër uw account",
    locked: false,
    complete: true,
    reward: 100,
  },
  {
    id: 3,
    name: "Richt je eigen sportpark in",
    locked: false,
    complete: false,
    reward: 150,
  },
  {
    id: 4,
    name: "Waardeer een ander sportpark",
    locked: true,
    complete: false,
    reward: 50,
  },
];

const LevelSelector = () => {
  return (
    <div>
      <div className="level_container">
        {levels
          .filter((lvl) => !lvl.complete && !lvl.locked)
          .map((lvl) => (
            <LevelButton
              key={`lvl-button-${lvl.id}/>`}
              name={lvl.name}
              locked={lvl.locked}
              complete={lvl.complete}
              reward={lvl.reward}
            />
          ))}
      </div>

      <div className="level_container_small">
        {levels
          .filter((lvl) => lvl.complete || lvl.locked)
          .map((lvl) => (
            <LevelButton
              key={`lvl-button-${lvl.id}/>`}
              name={lvl.name}
              locked={lvl.locked}
              complete={lvl.complete}
              reward={lvl.reward}
            />
          ))}
      </div>
    </div>
  );
};

export default LevelSelector;
